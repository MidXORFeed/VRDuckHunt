using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : IGameState
{

    public enum MenuStates
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
        Scoreboard
    }

    public enum GameStates
    {
        Pregame,
        RoundStarting,
        RoundStarted,
        RoundInProgress,
        RoundCompleted,
        Postgame,
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
