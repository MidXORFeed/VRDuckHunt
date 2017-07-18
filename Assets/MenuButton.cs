using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour {

    public enum button
    {
        Back,
        NewGame,
        WaveProgression,
        TimeAttack,
        RestartGame
    }

    public button thisButtonType;
    public MenuInteractions menuInteractions;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            switch (thisButtonType)
            {
                case button.Back:
                    menuInteractions.BackButtonPressed();
                    break;
                case button.NewGame:
                    menuInteractions.NewGameButtonPressed();
                    break;
                case button.WaveProgression:
                    menuInteractions.WaveProgressionButtonPressed();
                    break;
                case button.TimeAttack:
                    menuInteractions.TimeAttackButtonPressed();
                    break;
                case button.RestartGame:
                    menuInteractions.RestartButtonPressed();
                    break;
            }
        }
    }
}
