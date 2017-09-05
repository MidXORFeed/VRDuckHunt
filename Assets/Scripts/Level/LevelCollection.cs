using System;
using System.Collections.Generic;

[Serializable]
public class LevelCollection
{
    public List<Level> easy;
    public List<Level> normal;
}

[Serializable]
public class Level
{
    public int level;
    public int enemySpawns;
    public int roundDuration;
}


