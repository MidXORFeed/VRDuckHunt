﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : State {

    public enum GameStates
    {
        Pregame,
        RoundStarting,
        RoundStarted,
        RoundInProgress,
        RoundCompleted,
        Postgame
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
