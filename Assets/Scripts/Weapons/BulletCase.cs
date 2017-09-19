using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class BulletCase : MonoBehaviour {

    public SoundPlayOneshot playOneShot;
    public float timeToDie;

    Vector3 previousFramePosition;
    Vector3 currentPosition;

    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, timeToDie);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (playOneShot != null)
        {
            playOneShot.Play();
        }
    }
}
