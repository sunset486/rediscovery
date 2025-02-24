/**************************************************************************
 *                                                                        *
 *  File:        TwoHandedBall.cs                                         *
 *  Copyright:   (c) 2022, Andrei Petcu                                   *
 *  Description: XR Interactable type script for two-handed game objects  *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TwoHandedBall : XRGrabInteractable
{
    public List<XRSimpleInteractable> secondControllerGrabPointsList = new List<XRSimpleInteractable>();
    private XRBaseInteractor secondInteractor;
    private Quaternion attachIntialRoation;
    public enum TwoHandRotationType { None, First, Second }
    public TwoHandRotationType twoHandRotationType;
    public bool snapToSecondController = true;
    private Quaternion intialRotationOffset;

    #region Setting up the two handed interaction script
    void Start()
    {
        foreach (var item in secondControllerGrabPointsList)
        {
            item.selectEntered.AddListener(GrabbingSecondHand);
            item.selectExited.AddListener(ReleasingSecondHand);
        }
    }
    #endregion

    #region Grabbing logic

    /// <summary>
    /// This function overrides XR Process Interactable function to recognize all of the secondary grabbing points
    /// </summary>
    /// <param name="updatePhase"></param>
    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if (secondInteractor && selectingInteractor)
        {
            if (snapToSecondController)
                selectingInteractor.attachTransform.rotation = GetTwoHandRotation();
            else
                secondInteractor.attachTransform.rotation = GetTwoHandRotation() * intialRotationOffset;
        }
        base.ProcessInteractable(updatePhase);
    }

    /// <summary>
    /// This function checks the rotation of the object when it's held by the first grabbing point
    /// </summary>
    /// <returns> rotation of the object </returns>
    private Quaternion GetTwoHandRotation()
    {
        Quaternion targetRotation;

        if (twoHandRotationType == TwoHandRotationType.None)
        {
            targetRotation = Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position);
        }

        else if (twoHandRotationType == TwoHandRotationType.First)
        {
            targetRotation = Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position, selectingInteractor.transform.up);
        }
        else
        {
            targetRotation = Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position, secondInteractor.transform.up);
        }
        return targetRotation;
    }

    /// <summary>
    /// This functions enables the two-handed logic
    /// </summary>
    /// <param name="args"></param>
    public void GrabbingSecondHand(SelectEnterEventArgs args)
    {
        secondInteractor = args.interactor;
        intialRotationOffset = Quaternion.Inverse(GetTwoHandRotation()) * secondInteractor.attachTransform.rotation;
    }

    /// <summary>
    /// This function disables the two-handed logic
    /// </summary>
    /// <param name="args"></param>
    public void ReleasingSecondHand(SelectExitEventArgs args)
    {
        secondInteractor = null;
    }

    /// <summary>
    /// This function overrides the XR Interactable script by attaching the second grabbing point to the controller
    /// </summary>
    /// <param name="args"></param>
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        attachIntialRoation = args.interactor.attachTransform.localRotation;
        base.OnSelectEntered(args);
    }

    /// <summary>
    /// This function overrides the XR Interactable script by deattaching the second grabbing point from the controller
    /// </summary>
    /// <param name="args"></param>
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        secondInteractor = null;
        args.interactor.attachTransform.localRotation = attachIntialRoation;
        base.OnSelectExited(args);
    }

    /// <summary>
    /// This function overrides the XR Interactable script by checking if the second grabbing point is already attached
    /// </summary>
    /// <param name="interactor"></param>
    /// <returns> status of grabbed object </returns>
    public override bool IsSelectableBy(XRBaseInteractor interactor)
    {
        bool isalreadygrabbed = selectingInteractor && !interactor.Equals(selectingInteractor);
        return base.IsSelectableBy(interactor) && !isalreadygrabbed;
    }
    #endregion
}
