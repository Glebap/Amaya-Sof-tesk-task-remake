using UnityEngine.UI;
using UnityEngine;
using System.Linq;


public class TaskCreator : MonoBehaviour
{
    [SerializeField] private Card _card;
    [SerializeField] private TaskTextCreator _taskTextCreator;

    private int[] _random;
    private int _taskAnswer;
    private int bundleAnswerIndex;

    public void Create(LevelData levelData, CardBundleData cardBundle)
    {
        ClearPanel();

        GetComponent<GridLayoutGroup>().constraintCount = levelData.Columns;

        bundleAnswerIndex = cardBundle.GetAnswerIndex();
        RandomShuffle(cardBundle.CardData.Length, bundleAnswerIndex);
        _taskAnswer = Random.Range(0, levelData.Quantity);
        _random[_taskAnswer] = bundleAnswerIndex;
        InitializeCards(levelData.Quantity, cardBundle);
        _taskTextCreator.ChangeTaskText(cardBundle.CardData[bundleAnswerIndex].Identifier);

    }

    private void InitializeCards(int cardsToCreate, CardBundleData cardBundle)
    {
        for (int cardIndex = 0; cardIndex < cardsToCreate; cardIndex++)
        {
            Card card = Instantiate(_card,
                                    transform.position,
                                    Quaternion.identity,
                                    transform);

            card.Init(cardBundle.CardData[_random[cardIndex]].Sprite, cardIndex == _taskAnswer ? true : false);

        }
    }

    private void ClearPanel()
    {
         foreach (Transform child in transform)
         {
             Destroy(child.gameObject);
         }
    }

    private void RandomShuffle(int max, int answerIndex)
    {
        var numberList = Enumerable.Range(0, max).ToList();
        numberList.RemoveAt(answerIndex);
        _random = numberList.ToArray();  
        Shuffle(_random);                        
    }

    private void Shuffle<T>(T[] array)
    {
        int n = array.Length;
        for (int i = 0; i < (n - 1); i++)
        {
            int r = i + Random.Range(0,n - i - 1);
            T t = array[r];
            array[r] = array[i];
            array[i] = t;
        }
    }
}
