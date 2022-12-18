using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UImanager : MonoBehaviour
{
    [SerializeField] private Image _restartImage;
    [SerializeField] private Image _blackFade;
    [SerializeField] private float _restartImageScale;
    [SerializeField] private RestartScript _restartScript;

    public void ShowRestartUI()
    {
        gameObject.SetActive(true);
        _blackFade.DOFade(0.5f, 0.6f).OnComplete(() => {
            _restartImage.transform.DOScale(_restartImageScale + 0.05f, 0.3f).OnComplete(() => {
                _restartImage.transform.DOScale(_restartImageScale - 0.07f, 0.3f).OnComplete(() => {
                    _restartImage.transform.DOScale(_restartImageScale, 0.3f);
                });
            });
        });
    }

    public void OnRestartButtonClick()
    {
        _restartScript.LoadGame();
    }
}
