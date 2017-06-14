using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {

    public MenuInteractions menuInteractions;


    private Stack<State> stateStack;
    private State currentState;

    /* Miscellaneous */
    private void BackButtonPressed()
    {
        if (stateStack.Count > 0)
        {
            stateStack.Pop();
        }
    }

    /* Single Player Menu */
    private void StartButtonPressed()
    {
        currentState = State.GameStates.NewGame;
        stateStack.Push(currentState);
    }

    private void WaveProgressionButtonPressed()
    {
        currentState = State.GameStates.WaveProgression;
        stateStack.Push(currentState);
    }

    private void QuickShotButtonPressed()
    {
        currentState = State.GameStates.QuickShot;
        stateStack.Push(currentState);
    }

    private void TimeAttackButtonPressed()
    {
        currentState = State.GameStates.TimeAttack;
        stateStack.Push(currentState);
    }

    // Use this for initialization
    void Start () {
        menuInteractions.BackButtonEvent += BackButtonPressed;
        menuInteractions.SinglePlayerButtonEvent += StartButtonPressed;
        menuInteractions.WaveProgressionButtonEvent += WaveProgressionButtonPressed;
        menuInteractions.QuickShotButtonEvent += QuickShotButtonPressed;
        menuInteractions.TimeAttackButtonEvent += TimeAttackButtonPressed;
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
