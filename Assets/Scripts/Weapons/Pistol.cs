using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Examples;

public class Pistol : VRTK_InteractableObject
{
    public GameObject trigger;
    public PistolSlide slide;
    public Transform restTriggerTransform;
    public Transform maxTriggerTransform;
    private Rigidbody slideRigidbody;
    private Collider slideCollider;

    private VRTK_ControllerEvents controllerEvents;

    private void ToggleCollision(Rigidbody objRB, Collider objCol, bool state)
    {
        objRB.isKinematic = state;
        objCol.isTrigger = state;
    }

    private void ToggleSlide(bool state)
    {
        if (!state)
        {
            slide.ForceStopInteracting();
        }
        slide.isGrabbable = state;
        ToggleCollision(slideRigidbody, slideCollider, state);
    }

    public override void Grabbed(GameObject currentGrabbingObject)
    {
        base.Grabbed(currentGrabbingObject);

        controllerEvents = currentGrabbingObject.GetComponent<VRTK_ControllerEvents>();

        ToggleSlide(true);

        //Limit hands grabbing when picked up
        if (VRTK_DeviceFinder.GetControllerHand(currentGrabbingObject) == SDK_BaseController.ControllerHand.Left)
        {
            allowedTouchControllers = AllowedController.LeftOnly;
            allowedUseControllers = AllowedController.LeftOnly;
            slide.allowedGrabControllers = AllowedController.RightOnly;
        }
        else if (VRTK_DeviceFinder.GetControllerHand(currentGrabbingObject) == SDK_BaseController.ControllerHand.Right)
        {
            allowedTouchControllers = AllowedController.RightOnly;
            allowedUseControllers = AllowedController.RightOnly;
            slide.allowedGrabControllers = AllowedController.LeftOnly;
        }
    }

    public override void Ungrabbed(GameObject previousGrabbingObject)
    {
        base.Ungrabbed(previousGrabbingObject);

        ToggleSlide(false);

        //Unlimit hands
        allowedTouchControllers = AllowedController.Both;
        allowedUseControllers = AllowedController.Both;
        slide.allowedGrabControllers = AllowedController.Both;

        controllerEvents = null;
    }

    public override void StartUsing(GameObject currentUsingObject)
    {
        base.StartUsing(currentUsingObject);
        StartCoroutine(slide.Fire());
        VRTK_ControllerHaptics.TriggerHapticPulse(VRTK_ControllerReference.GetControllerReference(controllerEvents.gameObject), 0.63f, 0.2f, 0.01f);
    }

    protected override void Awake()
    {
        base.Awake();

        if (slide)
        {
            slideRigidbody = slide.GetComponent<Rigidbody>();
            slideCollider = slide.GetComponent<Collider>();
        }
    }

    protected override void Update()
    {
        base.Update();
        if (controllerEvents)
        {
            float pressure = (maxTriggerTransform.localPosition.x - restTriggerTransform.localPosition.x) * controllerEvents.GetTriggerAxis();
            trigger.transform.localPosition = new Vector3(restTriggerTransform.localPosition.x + pressure, trigger.transform.localPosition.y, trigger.transform.localPosition.z);
        } else
        {
            trigger.transform.localPosition = new Vector3(restTriggerTransform.localPosition.x, restTriggerTransform.localPosition.y, restTriggerTransform.localPosition.z);
        }
    }
}
