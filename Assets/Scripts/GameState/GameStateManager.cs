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
        switch (currentMenuState)
        {
            case MenuState.None:
                yield return null;
                break;
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
    }

	// Update is called once per frame
	void Update () {

        if (menuStateStack.Count > 0)
        {
            StartCoroutine(ManageMenuStatesCoroutines());
        }

        if (gameStateStack.Count > 0)
        {
            StartCoroutine(ManageGameStatesCoroutines());
        }
	}

    /* Miscellaneous Actions */ 

    IEnumerator BackButtonAction()
    {
        if (menuStateStack.Count > 0)
        {
            Debug.Log(menuStateStack.Peek().ToString() + " popped from menuStack ");
            menuStateStack.Pop();
        }
        yield return null;
    }

    /* Gameplay Actions */
    IEnumerator NewGameAction()
    {
        // Render NewGame Menu
        gameStateStack.Push(GameState.NewGame);
        Debug.Log(gameStateStack.Peek().ToString() + " pushed to gameStack ");
        yield return null;
    }

    IEnumerator WaveProgressionAction()
    {
        gameStateStack.Push(GameState.WaveProgression);
        Debug.Log(gameStateStack.Peek().ToString() + " pushed to gameStack ");
        // Transition state to RoundStarting
        // Set GameMode to WaveProgression
        yield return null;
    }

    IEnumerator TimeAttackAction()
    {
        gameStateStack.Push(GameState.TimeAttack);
        Debug.Log(gameStateStack.Peek().ToString() + " pushed to gameStack ");
        // Transition state to RoundStarting
        // Set GameMode to Quickshot
        yield return null;
    }

    IEnumerator PregameAction()
    {
        gameStateStack.Push(GameState.Pregame);
        Debug.Log(menuStateStack.Peek().ToString() + " pushed to gameStack ");
        // No game mode currently selected
        // User is free to interact with their environment without points
        yield return null;
    }

    IEnumerator RoundStartingAction()
    {
        gameStateStack.Push(GameState.RoundStarting);
        Debug.Log(menuStateStack.Peek().ToString() + " pushed to gameStack ");
        yield return null;
        //float currentPreRoundTimer = preRoundTimerDuration;
        //while (currentPreRoundTimer >= 0)
        //{
        //    currentPreRoundTimer -= Time.deltaTime;
        //    yield return null;
        //}

        //if (stateManager != null)
        //{
        //    assignedState = GameState.RoundStarted;
        //    stateManager.PushState(this);
        //}
    }

    IEnumerator RoundStartedAction()
    {
        gameStateStack.Push(GameState.RoundStarted);
        Debug.Log(menuStateStack.Peek().ToString() + " pushed to gameStack ");
        yield return null;
    }

    IEnumerator RoundInProgressAction()
    {
        gameStateStack.Push(GameState.RoundInProgress);
        Debug.Log(menuStateStack.Peek().ToString() + " pushed to gameStack ");
        yield return null;
        // Spawn ducks to shoot while timer > 0 or all ducks have been eliminated
        // Transition to RoundCompleted when 
        yield return null;
    }

    IEnumerator RoundCompletedAction()
    {
        gameStateStack.Push(GameState.RoundCompleted);
        Debug.Log(menuStateStack.Peek().ToString() + " pushed to gameStack ");
        yield return null;
        // Offer a small down time before transitioning to RoundStarting
        // Display overlay stats for that round?
        yield return null;
    }

    IEnumerator PostGameAction()
    {
        gameStateStack.Push(GameState.Postgame);
        Debug.Log(menuStateStack.Peek().ToString() + " pushed to gameStack ");
        // Offer method of restarting game
        // Display restart button somewhere?
        // Pressing restart button should transition state back to RoundStarting
        yield return null;
    }

    /* Menu Actions */
    IEnumerator OptionsAction()
    {
        menuStateStack.Push(MenuState.Options);
        Debug.Log(menuStateStack.Peek().ToString() + " pushed to menuStack ");
        // Render Options Menu
        yield return null;
    }

    IEnumerator AudioAction()
    {
        menuStateStack.Push(MenuState.Audio);
        Debug.Log(menuStateStack.Peek().ToString() + " pushed to menuStack ");
        // Render Audio Menu
        yield return null;
    }

    IEnumerator GraphicsAction()
    {
        menuStateStack.Push(MenuState.Graphics);
        Debug.Log(menuStateStack.Peek().ToString() + " pushed to menuStack ");
        // Render Graphics Menu
        yield return null;
    }

    IEnumerator ScoreboardAction()
    {
        menuStateStack.Push(MenuState.Options);
        Debug.Log(menuStateStack.Peek().ToString() + " pushed to menuStack ");
        yield return null;
    }

}
