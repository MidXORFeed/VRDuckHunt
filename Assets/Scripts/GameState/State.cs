using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour, IState
{
    private StateManager stateManager;
    private Type assignedState;
    private IEnumerator currentCoroutine;
    private float preRoundTimerDuration = 5.0f;

    public State(Type StateType)
    {
        assignedState = StateType;
    }

    public enum Type
    {
        MainMenu,
        NewGame,
        SinglePlayer,
        WaveProgression,
        QuickShot,
        TimeAttack,
        LoadGame,
        LevelSelect,
        Multiplayer,
        SharedMultiplayer,
        OnlineMultiplayer,
        LocalMultiplayer,
        Options,
        Graphics,
        Audio,
        Scoreboard,
        Pregame,
        RoundStarting,
        RoundStarted,
        RoundInProgress,
        RoundCompleted,
        Postgame,
    }

    // Use this for initialization
    void Start()
    {
        stateManager = FindObjectOfType<StateManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void Pause()
    {
        throw new NotImplementedException();
    }

    public virtual void Resume()
    {
        throw new NotImplementedException();
    }

    public virtual IEnumerator PerformAction()
    {
        switch(assignedState)
        {
            case Type.MainMenu:
                yield return StartCoroutine(MainMenuAction());
                break;
            case Type.NewGame:
                NewGameAction();
                break;
            case Type.SinglePlayer:
                SinglePlayerAction();
                break;
            case Type.WaveProgression:
                WaveProgressionAction();
                break;
            case Type.QuickShot:
                QuickShotAction();
                break;
            case Type.TimeAttack:
                TimeAttackAction();
                break;
            case Type.LoadGame:
                LoadGameAction();
                break;
            case Type.LevelSelect:
                LevelSelectAction();
                break;
            case Type.Multiplayer:
                MultiplayerAction();
                break;
            case Type.SharedMultiplayer:
                SharedMultiplayerAction();
                break;
            case Type.OnlineMultiplayer:
                OnlineMultiplayerAction();
                break;
            case Type.LocalMultiplayer:
                LocalMultiplayerAction();
                break;
            case Type.Options:
                OptionsAction();
                break;
            case Type.Graphics:
                GraphicsAction();
                break;
            case Type.Audio:
                AudioAction();
                break;
            case Type.Scoreboard:
                ScoreBoardAction();
                break;
            case Type.Pregame:
                PregameAction();
                break;
            case Type.RoundStarting:
                RoundStartingAction();
                break;
            case Type.RoundStarted:
                RoundStartedAction();
                break;
            case Type.RoundInProgress:
                RoundInProgressAction();
                break;
            case Type.RoundCompleted:
                RoundCompletedAction();
                break;
            case Type.Postgame:
                PostGameAction();
                break;
        }
    }

    public Type GetStateType()
    {
        return assignedState;
    }

    IEnumerator MainMenuAction()
    {
        // Render Main Menu
        yield return null;
    }

    IEnumerator NewGameAction()
    {
        // Render NewGame Menu
        yield return null;
    }

    IEnumerator SinglePlayerAction()
    {
        // Render SinglePlayer Menu
        yield return null;
    }

    IEnumerator WaveProgressionAction()
    {
        // Transition state to RoundStarting
        // Set GameMode to WaveProgression
        yield return null;
    }

    IEnumerator QuickShotAction()
    {
        // Transition state to RoundStarting
        // Set GameMode to Quickshot
        yield return null;
    }

    IEnumerator TimeAttackAction()
    {
        // Transition state to RoundStarting
        // Set GameMode to Quickshot
        yield return null;
    }

    IEnumerator LoadGameAction()
    {
        // Render LoadGame Menu
        yield return null;
    }

    IEnumerator LevelSelectAction()
    {
        // Render Level Select Menu
        yield return null;
    }

    IEnumerator MultiplayerAction()
    {
        // TBD
        yield return null;
    }

    IEnumerator SharedMultiplayerAction()
    {
        // TBD
        yield return null;
    }

    IEnumerator OnlineMultiplayerAction()
    {
        // Render OnlineMultiplayer Menu
        yield return null;
    }

    IEnumerator LocalMultiplayerAction()
    {
        // Render LocalMultiplayer Menu
        yield return null;
    }

    IEnumerator OptionsAction()
    {
        // Render Options Menu
        yield return null;
    }

    IEnumerator GraphicsAction()
    {
        // Render Graphics Menu
        yield return null;
    }

    IEnumerator ScoreBoardAction()
    {
        yield return null;
    }

    IEnumerator PregameAction()
    {
        // No game mode currently selected
        // User is free to interact with their environment without points
        yield return null;
    }

    IEnumerator RoundStartingAction()
    {
        float currentPreRoundTimer = preRoundTimerDuration;
        while (currentPreRoundTimer >= 0)
        {
            currentPreRoundTimer -= Time.deltaTime;
            yield return null;
        }
        
        if (stateManager != null)
        {
            assignedState = Type.RoundStarted;
            stateManager.PushState(this);
        }
    }

    IEnumerator RoundStartedAction()
    {
        if (stateManager != null)
        {
            assignedState = Type.RoundInProgress;
            stateManager.PushState(this);
        }
        yield return null;
    }

    IEnumerator RoundInProgressAction()
    {
        // Spawn ducks to shoot while timer > 0 or all ducks have been eliminated
        // Transition to RoundCompleted when 
        yield return null;
    }

    IEnumerator RoundCompletedAction()
    {
        // Offer a small down time before transitioning to RoundStarting
        // Display overlay stats for that round?
        yield return null;
    }

    IEnumerator AudioAction()
    {
        // Render Audio Menu
        yield return null;
    }

    IEnumerator PostGameAction()
    {
        // Offer method of restarting game
        // Display restart button somewhere?
        // Pressing restart button should transition state back to RoundStarting
        yield return null;
    }
}
