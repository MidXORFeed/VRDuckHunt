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
        throw new NotImplementedException();
    }

    public Type GetStateType()
    {
        return assignedState;
    }
}
