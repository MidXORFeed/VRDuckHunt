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
            case Type.Audio:
                break;
            case Type.Graphics:
                break;
            case Type.LevelSelect:
                break;
            case Type.LoadGame:
                break;
            case Type.LocalMultiplayer:
                break;
            case Type.MainMenu:
                break;
            case Type.Multiplayer:
                break;
            case Type.NewGame:
                break;
            case Type.OnlineMultiplayer:
                break;
            case Type.Options:
                break;
            case Type.Postgame:
                break;
            case Type.Pregame:
                break;
            case Type.QuickShot:
                break;
            case Type.RoundCompleted:
                break;
            case Type.RoundInProgress:
                break;
            case Type.RoundStarted:
                break;
            case Type.Scoreboard:
                break;
            case Type.SharedMultiplayer:
                break;
            case Type.SinglePlayer:
                break;
            case Type.TimeAttack:
                break;
            case Type.WaveProgression:
                break;
        }
    }

    public Type GetStateType()
    {
        return assignedState;
    }

    void AudioAction()
    {
        // Render Audio Menu
    }

    void GraphicsAction()
    {
        // Render Graphics Menu
    }

    void LevelSelectAction()
    {
        // Render LevelSelect Menu
    }

    void LocalMultiplayerAction()
    {
        // Render LocalMultiplayer Menu
    }

    void MainMenuAction()
    {
        // Render Main Menu
    }

    void MultiplayerAction()
    {
        // Render Multiplayer Menu
    }

    void NewGameAction()
    {
        // Render NewGame Menu
    }

    void OnlineMultiplayerAction()
    {
        // Render OnlineMultiplayer Menu
    }

    void OptionsAction()
    {
        // Render Options Menu
    }

    void PostGameAction()
    {
        // Offer method of restarting game
        // Display restart button somewhere?
        // Pressing restart button should transition state back to RoundStarting

    }

    void PregameAction()
    {
        // No game mode currently selected
        // User is free to interact with their environment without points
    }

    void QuickShotAction()
    {
        // Quickshot mode selected
        // Should transition state to RoundStarting
    }

    void RoundCompletedAction()
    {
        // Offer a small down time before transitioning to RoundStarting
        // Display overlay stats for that round?
    }

    void RoundInProgressAction()
    {
        // Spawn ducks to shoot while timer > 0 or all ducks have been eliminated
        // Transition to RoundCompleted when 
    }

    void RoundStartedAction()
    {

    }

    void ScoreBoardAction()
    {

    }

    void SharedMultiplayerAction()
    {

    }

    void SinglePlayerAction()
    {

    }

    void TimeAttackAction()
    {

    }

    void WaveProgressionAction()
    {

    }
}
