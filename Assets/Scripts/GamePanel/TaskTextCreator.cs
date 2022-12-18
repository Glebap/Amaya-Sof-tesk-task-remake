using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class TaskTextCreator : MonoBehaviour
{
    [SerializeField] private TMP_Text _taskText;
    private bool _visible = false;


    public void ChangeTaskText(string identifier)
    {
        _taskText.text = "Find: " + identifier;
        if(!_visible)
        {
            _taskText.DOFade(1, 2f);
        }
    }
}
