using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Magazine : VRTK_InteractableObject {

    public int currentBullets;
    public int CLIP_SIZE;
    private bool bAttached = false;

    public delegate void AttachDelegate();
    public delegate void DetachDelegate();
    public event AttachDelegate attachEvent;
    public event DetachDelegate detachEvent;

	// Use this for initialization
	void Start () {
        currentBullets = CLIP_SIZE;
        bAttached = false;
    }
	
    void Attach()
    {
        if (attachEvent != null)
        {
            attachEvent();
        }
    }

    void Detach()
    {
        if (detachEvent != null)
        {
            detachEvent();
        }
    }

	// Update is called once per frame
	protected override void Update () {
        if (!bAttached && IsInSnapDropZone())
        {
            bAttached = true;
            Attach();
        }

        if (bAttached && !IsInSnapDropZone())
        {
            bAttached = false;
            Detach();
        }
	}
}
