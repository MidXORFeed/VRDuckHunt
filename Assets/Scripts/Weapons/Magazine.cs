using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Magazine : VRTK_InteractableObject {

    public int currentBullets;
    public int CLIP_SIZE;
    private GameObject bullet;
    private bool bAttached = false;

    public delegate void AttachDelegate();
    public delegate void DetachDelegate();
    public event AttachDelegate attachEvent;
    public event DetachDelegate detachEvent;

	// Use this for initialization
	void Start () {
        currentBullets = CLIP_SIZE;
        bAttached = false;
        InteractableObjectSnappedToDropZone += new InteractableObjectEventHandler(Attach);
        InteractableObjectUnsnappedFromDropZone += new InteractableObjectEventHandler(Detach);
        bullet = transform.FindChild("9mm").gameObject;
    }
	
    void Attach(object sender, InteractableObjectEventArgs e)
    {
        if (attachEvent != null)
        {
            attachEvent();
        }
    }

    void Detach(object sender, InteractableObjectEventArgs e)
    {
        if (detachEvent != null)
        {
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
