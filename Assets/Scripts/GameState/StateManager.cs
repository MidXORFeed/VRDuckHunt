using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {

    public MenuInteractions menuInteractions;
    private IEnumerator currentCoroutine;
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
        stateStack.Push(new State(State.Type.NewGame));
    }

    private void WaveProgressionButtonPressed()
    {
        stateStack.Push(new State(State.Type.WaveProgression));
    }

    private void QuickShotButtonPressed()
    {
        stateStack.Push(new State(State.Type.QuickShot));
    }

    private void TimeAttackButtonPressed()
    {
        stateStack.Push(new State(State.Type.TimeAttack));
    }

    // Use this for initialization
    void Start () {
        stateStack = new Stack<State>();
        stateStack.Push(new State(State.Type.MainMenu));
        currentState = stateStack.Peek();
        Debug.Log(currentState);
        menuInteractions.BackButtonEvent += BackButtonPressed;
        menuInteractions.SinglePlayerButtonEvent += StartButtonPressed;
        menuInteractions.WaveProgressionButtonEvent += WaveProgressionButtonPressed;
        menuInteractions.QuickShotButtonEvent += QuickShotButtonPressed;
        menuInteractions.TimeAttackButtonEvent += TimeAttackButtonPressed;
    }
	
	// Update is called once per frame
	void Update () {
        if (stateStack.Count > 0 && currentCoroutine != null)
        {
            currentCoroutine = stateStack.Pop().PerformAction();
            StartCoroutine(currentCoroutine);
            currentCoroutine = null;
        }
	}

    public void PushState(State newState)
    {
        stateStack.Push(newState);
    }
}
