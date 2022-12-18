using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "New CardBundleData", menuName = "Card Bundle Data", order = 0)]

public class CardBundleData : ScriptableObject
{
	[SerializeField] private CardData[] _cardData;
	public CardData[] CardData => _cardData;

	private List<int> _unusedAnswers;

	public int GetAnswerIndex()
	{
		if (_unusedAnswers.Count == 0)
		{
			_unusedAnswers = Enumerable.Range(0, _cardData.Length)
					  				   .OrderBy(number => Random.value)
					  				   .ToList();
		}

		int answerIndex = _unusedAnswers[0];
		_unusedAnswers.RemoveAt(0);
		
        Debug.Log(_unusedAnswers.Count);
        
		return answerIndex;
	}

	public void ClearUnusedAnswers()
	{
		_unusedAnswers.Clear();
	}


}
