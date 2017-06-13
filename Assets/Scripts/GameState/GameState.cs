using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour, IGameState
{
    public enum GameStates
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

    void IGameState.Pause()
    {
        throw new NotImplementedException();
    }

    void IGameState.Resume()
    {
        throw new NotImplementedException();
    }
}
