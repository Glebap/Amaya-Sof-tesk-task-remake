using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GameLevelsData", menuName = "Game Levels Data", order = 1)]

public class GameLevelsData : ScriptableObject
{
    [SerializeField] private LevelData[] _levelData;

    public LevelData[] LevelData => _levelData;
}

