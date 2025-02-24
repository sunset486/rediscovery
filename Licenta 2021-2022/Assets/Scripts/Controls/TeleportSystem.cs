/**************************************************************************
 *                                                                        *
 *  File:        TeleportSystem.cs                                        *
 *  Copyright:   (c) 2022, Andrei Petcu                                   *
 *  Description: Teleportation-based movement system used in the          *
 *               Bunny Farm game                                          *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class TeleportSystem : MonoBehaviour
{
    [SerializeField] private InputActionReference teleportSwitch;

    public UnityEvent teleportSwitchEvent;
    public UnityEvent teleportCancelEvent;

    #region Input logic
    /// <summary>
    /// This function is used for enabling the teleportation logic
    /// </summary>
    private void OnEnable()
    {
        teleportSwitch.action.performed += EnableTeleport;
        teleportSwitch.action.canceled += DisableTeleport;
    }

    /// <summary>
    /// This function is used for letting the game know to stop recording the teleport commands
    /// </summary>
    private void OnDisable()
    {
        teleportSwitch.action.performed -= EnableTeleport;
        teleportSwitch.action.canceled -= DisableTeleport;
    }

    /// <summary>
    /// This function is used to completely disable the teleporting references when a new scene is loaded
    /// </summary>
    private void OnDestroy()
    {
        teleportSwitch.action.performed -= EnableTeleport;
        teleportSwitch.action.canceled -= DisableTeleport;
    }
    #endregion

    #region Input events

    /// <summary>
    /// This function enables the teleportation reticle
    /// </summary>
    /// <param name="context"></param>
    private void EnableTeleport(InputAction.CallbackContext context)
    {
        try
        {
            teleportSwitchEvent.Invoke();
        }
        catch(System.Exception e)
        {
            print(e.ToString());
        }
    }

    /// <summary>
    /// This function disables the teleportation reticle
    /// </summary>
    /// <param name="context"></param>
    private void DisableTeleport(InputAction.CallbackContext context)
    {
        try
        {
            Invoke(nameof(TeleportSwitchOff), .1f);
        }
        catch (System.Exception e)
        {
            print(e.ToString());
        }
    }
    /// <summary>
    /// Function for invoking the cancellation of the teleporting action
    /// </summary>
    private void TeleportSwitchOff()
    {
        teleportCancelEvent.Invoke();
    }
    #endregion
}
