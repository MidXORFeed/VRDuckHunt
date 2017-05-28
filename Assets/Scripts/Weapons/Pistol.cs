using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Examples;

public class Pistol : VRTK_InteractableObject
{
    public Rigidbody bullet;
    public float bulletForce;
    public float caseEjectionForce;
    public GameObject magazineSlot;
    public GameObject trigger;
    public PistolSlide slide;
    public Transform restTriggerTransform;
    public Transform maxTriggerTransform;
    public Transform bulletSpawn;
    public Transform caseSpawn;
    private Rigidbody slideRigidbody;
    private Collider slideCollider;
    private VRTK_ControllerEvents controllerEvents;
    private bool tMagazineEventHeard;
    private Magazine equippedMagazine;

    public Magazine GetEquippedMagazine()
    {
        return equippedMagazine;
    }

    private float GetRandomFloat(float min, float maximum)
    {
        return Random.Range(min, maximum);
    }

    private void FireBullet()
    {
        Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        bulletClone.AddForce(-bulletSpawn.up * bulletForce, ForceMode.Impulse);
    }

    private void UnchamberBullet()
    {
        float yMagnitude = GetRandomFloat(0f, 2.0f);
        float zMagnitude = GetRandomFloat(0f, 2.0f);

        if (slide.isBulletChambered)
        {
            slide.isBulletChambered = false;
            Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, caseSpawn.position, caseSpawn.rotation);
            bulletClone.AddForce(new Vector3(0, yMagnitude, zMagnitude) * caseEjectionForce, ForceMode.Impulse);
        }
    }

    private void ChamberBullet()
    {
        if (equippedMagazine != null)
        {
            if (equippedMagazine.currentBullets > 0)
            {
                equippedMagazine.currentBullets--;
                slide.isBulletChambered = true;
                slide.canChamberNewBullet = true;
            } else
            {
                slide.canChamberNewBullet = false;
            }
        }
    }

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
        if (slide.isBulletChambered)
        {
            FireBullet();
        }
        VRTK_ControllerHaptics.TriggerHapticPulse(VRTK_ControllerReference.GetControllerReference(controllerEvents.gameObject), 0.63f, 0.2f, 0.01f);
    }

    private void OnMagazineAttach()
    {
        tMagazineEventHeard = true;
    }

    private void OnMagazineDetach()
    {
        tMagazineEventHeard = false;
    }

    private void EquipMagazine()
    {
        if (magazineSlot.GetComponentInChildren<Magazine>() != null)
        {
            equippedMagazine = magazineSlot.GetComponentInChildren<Magazine>();
            tMagazineEventHeard = false;
        }
    }

    void Start()
    {
        for (int i = 0; i < FindObjectsOfType<Magazine>().Length; i++)
        {
            FindObjectsOfType<Magazine>()[i].detachEvent += OnMagazineDetach;
            FindObjectsOfType<Magazine>()[i].attachEvent += OnMagazineAttach;
        }
        FindObjectOfType<PistolSlide>().chamberBulletEvent += ChamberBullet;
        FindObjectOfType<PistolSlide>().unchamberBulletEvent += UnchamberBullet;
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

        if (tMagazineEventHeard)
        {
            EquipMagazine();
        }
    }
}
