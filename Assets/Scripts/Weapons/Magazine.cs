using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Magazine : VRTK_InteractableObject {

    public int currentBullets;
    public int CLIP_SIZE;
    private GameObject bullet;
    private bool bAttached = false;
    private BoxCollider collider;

    public delegate void AttachDelegate();
    public delegate void DetachDelegate();
    public event AttachDelegate attachEvent;
    public event DetachDelegate detachEvent;

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
        }
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
