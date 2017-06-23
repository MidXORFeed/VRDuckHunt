using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour, IState
{
    private Type assignedState;

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

    public virtual void PerformAction()
    {
        switch(assignedState)
        {
            case Type.MainMenu:
                MainMenuAction();
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

    void MainMenuAction()
    {
        // Render Main Menu
    }

    void NewGameAction()
    {
        // Render NewGame Menu
    }

    void SinglePlayerAction()
    {
        // Render SinglePlayer Menu
    }

    void WaveProgressionAction()
    {
        // Transition state to RoundStarting
        // Set GameMode to WaveProgression
    }

    void QuickShotAction()
    {
        // Transition state to RoundStarting
        // Set GameMode to Quickshot
    }

    void TimeAttackAction()
    {
        // Transition state to RoundStarting
        // Set GameMode to Quickshot
    }

    void LoadGameAction()
    {
        // Render LoadGame Menu
    }

    void LevelSelectAction()
    {
        // Render Level Select Menu
    }

    void MultiplayerAction()
    {
        // TBD
    }

    void SharedMultiplayerAction()
    {
        // TBD
    }

    void OnlineMultiplayerAction()
    {
        // Render OnlineMultiplayer Menu
    }

    void LocalMultiplayerAction()
    {
        // Render LocalMultiplayer Menu
    }

    void OptionsAction()
    {
        // Render Options Menu
    }

    void GraphicsAction()
    {
        // Render Graphics Menu
    }

    void ScoreBoardAction()
    {

    }

    void PregameAction()
    {
        // No game mode currently selected
        // User is free to interact with their environment without points
    }

    void RoundStartingAction()
    {
        // Initialize Pre-Round countdown
    }

    void RoundStartedAction()
    {
        // Initialize Round countdown
    }

    void RoundInProgressAction()
    {
        // Spawn ducks to shoot while timer > 0 or all ducks have been eliminated
        // Transition to RoundCompleted when 
    }

    void RoundCompletedAction()
    {
        // Offer a small down time before transitioning to RoundStarting
        // Display overlay stats for that round?
    }

    void AudioAction()
    {
        // Render Audio Menu
    }

    void PostGameAction()
    {
        // Offer method of restarting game
        // Display restart button somewhere?
        // Pressing restart button should transition state back to RoundStarting
    }
}
