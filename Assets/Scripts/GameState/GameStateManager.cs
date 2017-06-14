using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour {

    public MenuInteractions menuInteractions;


    private Stack<GameState.GameStates> gameStateStack;
    private GameState.GameStates currentState;

    private void StartButtonPressed()
    {
        currentState = GameState.GameStates.NewGame;
        gameStateStack.Push(currentState);
    }

    private void BackButtonPressed()
    {
        if (gameStateStack.Count > 0)
        {
            gameStateStack.Pop();
        }
    }

	// Use this for initialization
	void Start () {
        menuInteractions.BackButtonEvent += BackButtonPressed;
        menuInteractions.SinglePlayerButtonEvent += StartButtonPressed;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
