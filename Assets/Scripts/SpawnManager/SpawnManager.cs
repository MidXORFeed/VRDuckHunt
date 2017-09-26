using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public event Action ADuckHasBeenSlainEvent;

    public GameStateManager gameStateManager;
    public Rigidbody duck;
    public GameObject[] spawnVolumes;
    public GameObject[] exitVolumes;

	// Use this for initialization
	void Start () {
        gameStateManager.SpawnEvent += SpawnEnemyAction;
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void EmitADuckHasBeenSlainEvent()
    {
        if (ADuckHasBeenSlainEvent != null)
        {
            ADuckHasBeenSlainEvent();
        }
    }

    private void SpawnEnemyAction()
    {
        GameObject randomSpawnVolume = GetRandomSpawnVolume();
        GameObject randomExitVolume = GetRandomExitVolume();
        Vector3 randomSpawnVolumePosition = GetRandomPositionInVolume(randomSpawnVolume);
        Vector3 randomExitVolumePosition = GetRandomPositionInVolume(randomExitVolume);
        Rigidbody duckClone = (Rigidbody) Instantiate(duck, randomSpawnVolumePosition, duck.rotation);
        duckClone.GetComponent<DuckBehavior>().targetPlayer = randomExitVolume.transform;
        duckClone.GetComponent<DuckBehavior>().exit = randomExitVolume.transform;
        duckClone.GetComponent<DuckBehavior>().DeathEvent += ADuckHasBeenKilledAction;
    }

    private void ADuckHasBeenKilledAction()
    {
        gameStateManager.numRemainingEnemies -= 1;
        EmitADuckHasBeenSlainEvent();
    }

    private GameObject GetRandomSpawnVolume()
    {
        return spawnVolumes[UnityEngine.Random.Range(0, spawnVolumes.Length)];
    }

    private GameObject GetRandomExitVolume()
    {
        return exitVolumes[UnityEngine.Random.Range(0, exitVolumes.Length)];
    }

    private Vector3 GetRandomPositionInVolume(GameObject volume)
    {
        float volumeXRangeMin = volume.transform.position.x - (0.5f * volume.transform.lossyScale.x);
        float volumeXRangeMax = volume.transform.position.x + (0.5f * volume.transform.lossyScale.x);
        float volumeYRangeMin = volume.transform.position.y - (0.5f * volume.transform.lossyScale.y);
        float volumeYRangeMax = volume.transform.position.y + (0.5f * volume.transform.lossyScale.y);
        float volumeZRangeMin = volume.transform.position.z - (0.5f * volume.transform.lossyScale.z);
        float volumeZRangeMax = volume.transform.position.z + (0.5f * volume.transform.lossyScale.z);
        return new Vector3(UnityEngine.Random.Range(volumeXRangeMin, volumeXRangeMax), UnityEngine.Random.Range(volumeYRangeMin, volumeYRangeMax), UnityEngine.Random.Range(volumeZRangeMin, volumeZRangeMax));
    }
}
