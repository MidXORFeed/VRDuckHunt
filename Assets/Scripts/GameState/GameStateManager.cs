using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour {

    public MenuInteractions menuInteractions;

    int currentRound = 1;
    int MAX_ROUNDS = 10;
    bool isMenuStateCoroutineRunning;
    bool isGameStateCoroutineRunning;
    GameState selectedGameMode;
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
        menuInteractions.RestartButtonEvent += RestartGameAction;
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
        isMenuStateCoroutineRunning = false;
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
        isGameStateCoroutineRunning = false;
    }

	// Update is called once per frame
	void Update () {

        if (menuStateStack.Peek() != MenuState.None)
        {
            if (!isMenuStateCoroutineRunning)
            {
                isMenuStateCoroutineRunning = true;
                StartCoroutine(ManageMenuStatesCoroutines());
            } 
        }

        if (gameStateStack.Count > 0)
        {
            if (!isGameStateCoroutineRunning)
            {
                isGameStateCoroutineRunning = true;
                StartCoroutine(ManageGameStatesCoroutines());
            }
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

    /***** Gameplay Actions *****/
    IEnumerator NewGameAction()
    {
        if (gameStateStack.Peek() != GameState.NewGame)
        {
            gameStateStack.Push(GameState.NewGame);
        }
        Debug.Log("NewGame State");
        yield return null;
    }

    IEnumerator WaveProgressionAction()
    {
        if (gameStateStack.Peek() != GameState.WaveProgression)
        {
            gameStateStack.Push(GameState.WaveProgression);
        }

        Debug.Log("WaveProgression State");
        selectedGameMode = GameState.WaveProgression;
        
        if (gameStateStack.Peek() != GameState.RoundStarting)
        {
            gameStateStack.Push(GameState.RoundStarting);
        }
        yield return null;
        // Set GameMode to WaveProgression
        // Transition state to RoundStarting
    }

    IEnumerator TimeAttackAction()
    {
        if (gameStateStack.Peek() != GameState.TimeAttack)
        {
            gameStateStack.Push(GameState.TimeAttack);
        }

        Debug.Log("TimeAttack State");
        selectedGameMode = GameState.TimeAttack;
        
        if (gameStateStack.Peek() != GameState.RoundStarting)
        {
            gameStateStack.Push(GameState.RoundStarting);
        }
        yield return null;
        // Set GameMode to TimeAttack
        // Transition state to RoundStarting
    }

    IEnumerator RoundStartingAction()
    {
        Debug.Log("RoundStarting State");
        float preroundTimerDuration = 3.0f;
        float currentPreroundTimer = preroundTimerDuration;

        while (currentPreroundTimer >= 0)
        {
            currentPreroundTimer -= Time.deltaTime;
            yield return null;
        }

        if (gameStateStack.Peek() != GameState.RoundStarted)
        {
            gameStateStack.Push(GameState.RoundStarted);
        }
    }

    IEnumerator RoundStartedAction()
    {
        Debug.Log("RoundStarted State");
        if (gameStateStack.Peek() != GameState.RoundInProgress)
        {
            gameStateStack.Push(GameState.RoundInProgress);
        }
        yield return null;
        // Play "Go!" audio clip?
        // Display N number of ducks to be spawned this wave
    }

    IEnumerator RoundInProgressAction()
    {
        Debug.Log("RoundInProgress State");
        float roundInProgressTimerDuration = 5.0f;
        float currentRoundInProgressTimer = roundInProgressTimerDuration;

        while (currentRoundInProgressTimer >= 0)
        {
            currentRoundInProgressTimer -= Time.deltaTime;
            yield return null;
        }

        if (gameStateStack.Peek() != GameState.RoundCompleted)
        {
            gameStateStack.Push(GameState.RoundCompleted);
        }
        // Call function that will spawn N number of ducks periodically
        // Spawn ducks to shoot while timer > 0 or all ducks have been eliminated
        // Transition to RoundCompleted when 

    }

    IEnumerator RoundCompletedAction()
    {
        Debug.Log("RoundCompleted State");
        if (selectedGameMode == GameState.WaveProgression)
        {
            float roundCompletedTimerDuration = 5.0f;
            float currentRoundCompletedTimer = roundCompletedTimerDuration;
            if (currentRound < MAX_ROUNDS)
            {
                currentRound++;
                while (currentRoundCompletedTimer >= 0)
                {
                    currentRoundCompletedTimer -= Time.deltaTime;
                    yield return null;
                }

                if (gameStateStack.Peek() != GameState.RoundStarting)
                {
                    gameStateStack.Push(GameState.RoundStarting);
                }
            } else
            {
                if (gameStateStack.Peek() != GameState.Postgame)
                {
                    gameStateStack.Push(GameState.Postgame);
                }
            }
        } else if (selectedGameMode == GameState.TimeAttack)
        {
            if (gameStateStack.Peek() != GameState.Postgame)
            {
                gameStateStack.Push(GameState.Postgame);
            }
        }
        // Offer a small down time before transitioning to RoundStarting
        // Display overlay stats for that round?
    }

    IEnumerator PostGameAction()
    {
        Debug.Log("Postgame State");
        
        // Offer method of restarting game
        // Display restart button somewhere?
        // Pressing restart button should transition state back to RoundStarting
        yield return null;
    }

    void RestartGameAction()
    {
        // Called when the player presses the button to restart the game after they lose
        if (selectedGameMode == GameState.WaveProgression)
        {
            currentRound = 1;
        }
        gameStateStack.Push(GameState.NewGame);
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
