/**************************************************************************
 *                                                                        *
 *  File:        UserInterfaceInteraction.cs                              *
 *  Copyright:   (c) 2022, Andrei Petcu                                   *
 *  Description: Script for determining whether the XR controller is      *
 *               pointing towards a user interface                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/
using UnityEngine;
using UnityEngine.Events;

public class UserInterfaceInteraction : MonoBehaviour
{
    [SerializeField] private Transform linkedHandPosition;
    [SerializeField] private LayerMask layerForTouch;
    [SerializeField] private float distFromCanvas;

    public UnityEvent onHoverStart;
    public UnityEvent onHoverFinish;

    #region Interaction state managers and enums
    enum InteractionStates
    { 
        defaultSet,
        uiSet
    }

    private InteractionStates currentState;
    #endregion

    #region UI interaction logic

    /// <summary>
    /// This function sets the current state of controller ray interaction to the default value
    /// </summary>
    private void Awake()
    {
        currentState = InteractionStates.defaultSet;
    }

    /// <summary>
    /// This function checks if the controllers are pointed towards the UI interaction area
    /// </summary>
    private void FixedUpdate()
    {
        if (Physics.Raycast(linkedHandPosition.position, linkedHandPosition.forward, out RaycastHit hit, distFromCanvas, layerForTouch))
        {
            if (currentState != InteractionStates.uiSet)
            {
                onHoverStart.Invoke();
                currentState = InteractionStates.uiSet;
            }
        }
        else
        {
            if (currentState == InteractionStates.uiSet)
            {
                onHoverFinish.Invoke();
                currentState = InteractionStates.defaultSet;
            }
        }
    }
    #endregion
}
