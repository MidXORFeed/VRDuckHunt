using UnityEngine;

public class ResourceDeserializer : MonoBehaviour
{
    public string levelResourcePath;
    LevelCollection levelData;
    // Use this for initialization

    public LevelCollection getLevelData()
    {
        return levelData;
    }

    public LevelCollection getLevelData(string resourcePath)
    {
        levelResourcePath = resourcePath;
        string json = Resources.Load(levelResourcePath).ToString();
        levelData = JsonUtility.FromJson<LevelCollection>(json);
        return levelData;
    }

    private void Awake()
    {
        string json = Resources.Load(levelResourcePath).ToString();
        levelData = JsonUtility.FromJson<LevelCollection>(json);
    }
}
