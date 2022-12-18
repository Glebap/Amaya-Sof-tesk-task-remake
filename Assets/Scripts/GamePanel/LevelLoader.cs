using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(TaskCreator))]
public class LevelLoader : MonoBehaviour
{

    [SerializeField] private GameLevelsData _gameLevelsData;
    [SerializeField] private CardBundleData[] _cardBundleData;
    [SerializeField] private UImanager _uiManager;
    
    private TaskCreator _taskCreator;

    private int _level = 0;
    private int _maxLevel => _gameLevelsData.LevelData.Length -1;
    private int _bundles => _cardBundleData.Length;

    void Start()
    {
        _taskCreator = GetComponent<TaskCreator>();
        CreateNewLevel();
        Debug.Log(_bundles);
    }


    public void CreateNewLevel()
    {
        if (_level > _maxLevel)
        {
            foreach(CardBundleData cardBundle in _cardBundleData)
            {
                cardBundle.ClearUnusedAnswers();
            }
            _uiManager.ShowRestartUI();
            return;
        }

        CardBundleData bundleData = _cardBundleData[Random.Range(0, _bundles)];
        _taskCreator.Create(_gameLevelsData.LevelData[_level], bundleData);
        _level++;
    }
}
