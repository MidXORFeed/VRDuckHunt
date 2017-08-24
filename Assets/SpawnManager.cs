using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public GameObject[] spawnVolumes;
    public GameObject[] exitVolumes;

	// Use this for initialization
	void Start () {
        GameObject randomSpawnVolume = GetRandomSpawnVolume();
        GameObject randomExitVolume = GetRandomExitVolume();
        Vector3 randomSpawnVolumePosition = GetRandomPositionInVolume(randomSpawnVolume);
        Vector3 randomExitVolumePosition = GetRandomPositionInVolume(randomExitVolume);
        Debug.Log("Random Point" + randomSpawnVolumePosition);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    private GameObject GetRandomSpawnVolume()
    {
        return spawnVolumes[Random.Range(0, spawnVolumes.Length - 1)];
    }

    private GameObject GetRandomExitVolume()
    {
        return exitVolumes[Random.Range(0, exitVolumes.Length - 1)];
    }

    private Vector3 GetRandomPositionInVolume(GameObject volume)
    {
        float volumeXRangeMin = volume.transform.position.x - (0.5f * volume.transform.lossyScale.x);
        float volumeXRangeMax = volume.transform.position.x + (0.5f * volume.transform.lossyScale.x);
        float volumeYRangeMin = volume.transform.position.y - (0.5f * volume.transform.lossyScale.y);
        float volumeYRangeMax = volume.transform.position.y + (0.5f * volume.transform.lossyScale.y);
        float volumeZRangeMin = volume.transform.position.z - (0.5f * volume.transform.lossyScale.z);
        float volumeZRangeMax = volume.transform.position.z + (0.5f * volume.transform.lossyScale.z);

        Debug.Log("Volume: " + volume);
        Debug.Log("XER[" + volumeXRangeMin + ", " + volumeXRangeMax + "]");
        Debug.Log("YER[" + volumeYRangeMin + ", " + volumeYRangeMax + "]");
        Debug.Log("ZER[" + volumeZRangeMin + ", " + volumeZRangeMax + "]");

        return new Vector3(Random.Range(volumeXRangeMin, volumeXRangeMax), Random.Range(volumeYRangeMin, volumeYRangeMax), Random.Range(volumeZRangeMin, volumeZRangeMax));
    }
}
