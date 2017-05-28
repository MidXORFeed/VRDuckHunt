using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Bullet : MonoBehaviour {

    public SoundPlayOneshot playOneShot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (playOneShot != null)
        {
            playOneShot.Play();
        }
    }
}
