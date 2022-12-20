using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(TaskCreator))]
public class LevelLoader : MonoBehaviour
{

    [SerializeField] private GameLevelsData _gameLevelsData;
    [SerializeField] private CardBundleData[] _cardBundleData;
    [SerializeField] private UImanager _uiManager;
    [SerializeField] private AnswerOptionCreator _answerOptionCreator;
    
    private TaskCreator _taskCreator;

    private int _level = 0;
    private int _maxLevel => _gameLevelsData.LevelData.Length -1;
    private int _bundles => _cardBundleData.Length;

    void Start()
    {
        _answerOptionCreator.SetOptionsCapacity(_cardBundleData);
        _taskCreator = GetComponent<TaskCreator>();
        CreateNewLevel();
    }


    public void CreateNewLevel()
    {
        if (_level > _maxLevel)
        {
            _uiManager.ShowRestartUI();
            return;
        }

        int bundleIndex = Random.Range(0, _bundles);
        CardBundleData bundleData = _cardBundleData[bundleIndex];
        int bundleAnswerIndex = _answerOptionCreator.GetUnusedAnswerOption(bundleIndex);

        _taskCreator.Create(_gameLevelsData.LevelData[_level], bundleData, bundleAnswerIndex);
        _level++;
    }
}
