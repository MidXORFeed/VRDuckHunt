using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class UIManager : MonoBehaviour {

    public GameStateManager gameStateManager;
    public SpawnManager spawnManager;
    public InputField[] inputFields;
    float currentRoundTime;
    int numEnemiesLeftThisRound;

    // Use this for initialization
    void Start () {
        gameStateManager.SendNumEnemiesToSpawnEvent += SendNumEnemiesToSpawnAction;
        gameStateManager.SendCurrentRoundEvent += SendCurrentRoundAction;
        gameStateManager.SendRoundDurationEvent += SendRoundDurationAction;
        gameStateManager.SendCurrentGameStateEvent += SendCurrentGameStateAction;
        spawnManager.ADuckHasBeenSlainEvent += ADuckHasBeenSlainAction;
    }

    void ADuckHasBeenSlainAction()
    {
        if (numEnemiesLeftThisRound > 0)
        {
            numEnemiesLeftThisRound--;
            inputFields[0].text = "Enemies this round: " + numEnemiesLeftThisRound;
        }
    }

    void SendNumEnemiesToSpawnAction(int numEnemiesToSpawn)
    {
        numEnemiesLeftThisRound = numEnemiesToSpawn;
        inputFields[0].text = "Enemies this round: " + numEnemiesLeftThisRound;
    }

    void SendCurrentRoundAction(int currentRound)
    {
        inputFields[1].text = "Current Round: " + currentRound; 
    }

    void SendRoundDurationAction(float roundDuration)
    {
        currentRoundTime = roundDuration;
        inputFields[2].text = "Round Duration: " + string.Format("{0:.##}", currentRoundTime);
    }

    void SendCurrentGameStateAction(string currentGameState)
    {
        inputFields[3].text = "GameState: " + currentGameState;
    }

    public void ClickKey(string character)
    {
        inputFields[0].text += character;
    }

    // Update is called once per frame
    void Update () {
        if (currentRoundTime > 0)
        {
            currentRoundTime -= Time.deltaTime;
            inputFields[2].text = "Round Duration: " + string.Format("{0:.##}", currentRoundTime);
        } else
        {
            currentRoundTime = 0.0f;
            inputFields[2].text = "Round Duration: " + string.Format("{0:.##}", currentRoundTime);
        }
    }


}
