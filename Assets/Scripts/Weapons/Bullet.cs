using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Bullet : MonoBehaviour {

    public SoundPlayOneshot playOneShot;
    public float timeToDie;

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, timeToDie);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (playOneShot != null)
        {
            playOneShot.Play();
        }
    }
}
