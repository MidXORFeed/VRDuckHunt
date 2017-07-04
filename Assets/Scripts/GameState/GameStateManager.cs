using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour {

    public MenuInteractions menuInteractions;

    GameState currentGameState;
    MenuState currentMenuState;
    Stack<GameState> gameStateStack;
    Stack<MenuState> menuStateStack;

    enum GameState
    {
        Pregame,
        NewGame,
        WaveProgression,
        TimeAttack,
        RoundStarting,
        RoundStarted,
        RoundInProgress,
        RoundCompleted,
        Postgame
    }

    enum MenuState
    {
        None,
        Options,
        Graphics,
        Audio,
        Scoreboard
    }

    // Use this for initialization
    void Start () {
        gameStateStack = new Stack<GameState>();
        gameStateStack.Push(GameState.Pregame);
        menuStateStack = new Stack<MenuState>();
        menuStateStack.Push(MenuState.None);

        menuInteractions.BackButtonEvent += BackButtonAction;
        menuInteractions.NewGameButtonEvent += NewGameAction;
        menuInteractions.WaveProgressionButtonEvent += WaveProgressionAction;
        menuInteractions.TimeAttackButtonEvent += TimeAttackAction;
        
    }

    IEnumerator ManageMenuStatesCoroutines()
    {
        currentMenuState = menuStateStack.Peek();
        switch (currentMenuState)
        {
            case MenuState.Options:
                yield return StartCoroutine(OptionsAction());
                break;
            case MenuState.Graphics:
                yield return StartCoroutine(GraphicsAction());
                break;
            case MenuState.Audio:
                yield return StartCoroutine(AudioAction());
                break;
            case MenuState.Scoreboard:
                yield return StartCoroutine(ScoreboardAction());
                break;
        }
    }

    IEnumerator ManageGameStatesCoroutines()
    {
        currentGameState = gameStateStack.Peek();
        switch (currentGameState)
        {
            case GameState.NewGame:
                yield return StartCoroutine(NewGameAction());
                break;
            case GameState.WaveProgression:
                yield return StartCoroutine(WaveProgressionAction());
                break;
            case GameState.TimeAttack:
                yield return StartCoroutine(TimeAttackAction());
                break;
            case GameState.Pregame:
                yield return StartCoroutine(PregameAction());
                break;
            case GameState.RoundStarting:
                yield return StartCoroutine(RoundStartingAction());
                gameStateStack.Push(GameState.RoundStarted);
                break;
            case GameState.RoundStarted:
                yield return StartCoroutine(RoundStartedAction());
                break;
            case GameState.RoundInProgress:
                yield return StartCoroutine(RoundInProgressAction());
                break;
            case GameState.RoundCompleted:
                yield return StartCoroutine(RoundCompletedAction());
                break;
            case GameState.Postgame:
                yield return StartCoroutine(PostGameAction());
                break;
        }
    }

	// Update is called once per frame
	void Update () {

        if (menuStateStack.Peek() != MenuState.None)
        {
            StartCoroutine(ManageMenuStatesCoroutines());
        }

        if (gameStateStack.Count > 0)
        {
            StartCoroutine(ManageGameStatesCoroutines());
        }
	}

    /***** Miscellaneous Actions *****/ 

    IEnumerator BackButtonAction()
    {
        if (menuStateStack.Peek() != MenuState.None)
        {
            menuStateStack.Pop();
        }
        yield return null;
    }

    /***** Gameplay Actions *****/
    IEnumerator NewGameAction()
    {
        if (gameStateStack.Peek() != GameState.NewGame)
        {
            gameStateStack.Push(GameState.NewGame);
            Debug.Log("NewGame State");
        }
        yield return null;
    }

    IEnumerator WaveProgressionAction()
    {
        if (gameStateStack.Peek() != GameState.WaveProgression)
        {
            gameStateStack.Push(GameState.WaveProgression);
            Debug.Log("WaveProgression State");
        }
        yield return null;
        // Transition state to RoundStarting
        // Set GameMode to WaveProgression
    }

    IEnumerator TimeAttackAction()
    {
        if (gameStateStack.Peek() != GameState.TimeAttack)
        {
            gameStateStack.Push(GameState.TimeAttack);
            Debug.Log("TimeAttack State");
        }
        yield return null;
        // Transition state to RoundStarting
        // Set GameMode to Quickshot

    }

    IEnumerator PregameAction()
    {
        if (gameStateStack.Peek() != GameState.Pregame)
        {
            gameStateStack.Push(GameState.Pregame);
            Debug.Log("Pregame State");
        }
        yield return null;
        // No game mode currently selected
        // User is free to interact with their environment without points
    }

    IEnumerator RoundStartingAction()
    {
        if (gameStateStack.Peek() != GameState.RoundStarting)
        {
            gameStateStack.Push(GameState.RoundStarting);
            Debug.Log("RoundStarting State");
        }

        float preroundTimerDuration = 3.0f;
        float currentPreroundTimer = preroundTimerDuration;

        while (currentPreroundTimer >= 0)
        {
            currentPreroundTimer -= Time.deltaTime;
            yield return null;
        }
        gameStateStack.Push(GameState.RoundStarted);
    }

    IEnumerator RoundStartedAction()
    {
        if (gameStateStack.Peek() != GameState.RoundStarted)
        {
            gameStateStack.Push(GameState.RoundStarted);
            Debug.Log("RoundStarted State");
        }

        // Play "Go!" audio clip?
        // Display N number of ducks to be spawned this wave
        gameStateStack.Push(GameState.RoundInProgress);
        yield return null;
    }

    IEnumerator RoundInProgressAction()
    {
        if (gameStateStack.Peek() != GameState.RoundInProgress)
        {
            gameStateStack.Push(GameState.RoundInProgress);
            Debug.Log("RoundInProgress State");
        }

        float roundInProgressTimerDuration = 5.0f;
        float currentRoundInProgressTimer = roundInProgressTimerDuration;

        while (currentRoundInProgressTimer >= 0)
        {
            currentRoundInProgressTimer -= Time.deltaTime;
            yield return null;
        }
        gameStateStack.Push(GameState.RoundCompleted);
        // Call function that will spawn N number of ducks periodically
        // Spawn ducks to shoot while timer > 0 or all ducks have been eliminated
        // Transition to RoundCompleted when 

    }

    IEnumerator RoundCompletedAction()
    {
        if (gameStateStack.Peek() != GameState.RoundCompleted)
        {
            gameStateStack.Push(GameState.RoundCompleted);
            Debug.Log("RoundCompleted State");
        }
        yield return null;
        // Offer a small down time before transitioning to RoundStarting
        // Display overlay stats for that round?
    }

    IEnumerator PostGameAction()
    {
        if (gameStateStack.Peek() != GameState.Postgame)
        {
            gameStateStack.Push(GameState.Postgame);
            Debug.Log("Postgame State");
        }
        gameStateStack.Push(GameState.Postgame);
        
        // Offer method of restarting game
        // Display restart button somewhere?
        // Pressing restart button should transition state back to RoundStarting
        yield return null;
    }

    /***** Menu Actions *****/
    IEnumerator OptionsAction()
    {
        if (menuStateStack.Peek() != MenuState.Options)
        {
            menuStateStack.Push(MenuState.Options);
            Debug.Log("Options State");
        }
        yield return null;
        // Render Options Menu

    }

    IEnumerator AudioAction()
    {
        if (menuStateStack.Peek() != MenuState.Audio)
        {
            menuStateStack.Push(MenuState.Audio);
            Debug.Log("Audio State");
        } 
        // Render Audio Menu
        yield return null;
    }

    IEnumerator GraphicsAction()
    {
        if (menuStateStack.Peek() != MenuState.Graphics)
        {
            menuStateStack.Push(MenuState.Graphics);
            Debug.Log("Graphics State");
        }
        yield return null;
        // Render Graphics Menu
    }

    IEnumerator ScoreboardAction()
    {
        if (menuStateStack.Peek() != MenuState.Scoreboard)
        {
            menuStateStack.Push(MenuState.Scoreboard);
            Debug.Log("Scoreboard State");
        }
        yield return null;
    }

}
