using UnityEngine.UI;
using UnityEngine;
using System.Linq;


public class TaskCreator : MonoBehaviour
{
    [SerializeField] private Card _card;
    [SerializeField] private TaskTextCreator _taskTextCreator;

    private int[] _random;
    private int _taskAnswer;

    public void Create(LevelData levelData, CardBundleData cardBundle, int bundleAnswerIndex)
    {
        ClearPanel();
        GetComponent<GridLayoutGroup>().constraintCount = levelData.Columns;
        
        _taskAnswer = Random.Range(0, levelData.Quantity);
        RandomShuffle(cardBundle.CardData.Length, bundleAnswerIndex);

        InitializeCards(levelData.Quantity, cardBundle);

        _taskTextCreator.ChangeTaskText(cardBundle.CardData[bundleAnswerIndex].Identifier);

    }

    private void InitializeCards(int cardsToCreate, CardBundleData cardBundle)
    {
        for (int cardIndex = 0; cardIndex < cardsToCreate; cardIndex++)
        {
            Card card = Instantiate(_card,
                                    transform.position,
                                    Quaternion.identity);
            card.transform.SetParent(this.transform, false);

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
        _random = Enumerable.Range(0, max).ToArray();
        AnswerOptionCreator.RemoveAt(ref _random, answerIndex);
        Shuffle(_random);   
        _random[_taskAnswer] = answerIndex;                     
    }

    public static void Shuffle<T>(T[] array)
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
