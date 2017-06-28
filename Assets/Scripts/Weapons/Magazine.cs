using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using VRTK;

public class Magazine : VRTK_InteractableObject {

    public int currentBullets;
    public int CLIP_SIZE;
    public float timeToDie;
    private GameObject bullet;
    private bool bAttached = false;
    private BoxCollider collider;

    public delegate void AttachDelegate();
    public delegate void DetachDelegate();
    public event AttachDelegate attachEvent;
    public event DetachDelegate detachEvent;

    public SoundPlayOneshot onMagazineLoadSound;
    public SoundPlayOneshot onMagazineUnloadSound;

    // Use this for initialization
    void Start () {
        currentBullets = CLIP_SIZE;
        bAttached = false;
        bullet = transform.FindChild("9mm").gameObject;
        collider = GetComponent<BoxCollider>();
        InteractableObjectSnappedToDropZone += new InteractableObjectEventHandler(Attach);
        InteractableObjectUnsnappedFromDropZone += new InteractableObjectEventHandler(Detach);
    }
	
    void Attach(object sender, InteractableObjectEventArgs e)
    {
        if (attachEvent != null)
        {
            if (collider != null)
            {
                collider.isTrigger = true;
            }
            attachEvent();
            onMagazineLoadSound.Play();
        }
    }

    void Detach(object sender, InteractableObjectEventArgs e)
    {
        if (detachEvent != null)
        {
            if (collider != null)
            {
                collider.isTrigger = false;
            }
            detachEvent();
            onMagazineUnloadSound.Play();
            if (ShouldDestroy())
            {
                Destroy(this.gameObject, timeToDie);
            }
        }
    }

    bool ShouldDestroy()
    {
        if (currentBullets <= 0)
        {
            return true;
        }
        return false;
    }

    void OnDestroy()
    {
        InteractableObjectSnappedToDropZone -= Attach;
        InteractableObjectUnsnappedFromDropZone -= Detach;
    }

    // Update is called once per frame
    protected override void Update () {
        if (currentBullets <= 0)
        {
            if (bullet != null)
            {
                bullet.SetActive(false);
            }
        }
	}
}
