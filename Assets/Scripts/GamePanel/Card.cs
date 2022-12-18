using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Card : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] ParticleSystem _particleSystem;
    private bool _isAnswer;
    private GameObject _content;
    private Image _contentImage;
    private bool _canClick = true;

    public bool IsAnswer => _isAnswer;

    public void Init(Sprite sprite, bool isAnswer = false)
    {
        SetColor();
        SetContent(sprite);
        _isAnswer = isAnswer;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_canClick)
        {
            _canClick = false;
            if (_isAnswer)
            {
                _particleSystem.Play();
                _content.transform.DOScale(1.05f, 0.4f).OnComplete(() => {
                    _content.transform.DOScale(0.825f, 0.5f).OnComplete(() => {
                        _content.transform.DOScale(0.85f, 0.1f);
                    });
                });
                StartCoroutine(LoadNextLevel());
            }
            else
            {
                _content.transform.DOLocalMoveX(25f, 0.15f).OnComplete(() => {
                    _content.transform.DOLocalMoveX(-25f, 0.3f).OnComplete(() => {
                        _content.transform.DOLocalMoveX(0f, 0.15f).OnComplete(() => {
                            _canClick = true;
                        });
                    });
                });
            }
        }
    }

    private void SetContent(Sprite sprite)
    {
        _content = transform.GetChild(0).gameObject;
        _contentImage = _content.GetComponent<Image>();
        _contentImage.sprite = sprite;
        float ratio = sprite.rect.width / sprite.rect.height;
        _content.GetComponent<AspectRatioFitter>().aspectRatio = ratio;
    }

    private void SetColor()
    {
        int[] rgb = {255,255,255};
        int constant = Random.Range(0,3);
        for (int i = 0; i < 3; i++)
        {
            if(i == constant){continue;}
            else{rgb[i] = Random.Range(150,256);}
        }

        GetComponent<Image>().color = new Color32((byte)rgb[0],
                                                  (byte)rgb[1],
                                                  (byte)rgb[2],
                                                    255);
    }

    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(1.0f);
        FindObjectOfType<LevelLoader>().CreateNewLevel();
    }



}
