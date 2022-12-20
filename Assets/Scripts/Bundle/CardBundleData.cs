using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "New CardBundleData", menuName = "Card Bundle Data", order = 0)]

public class CardBundleData : ScriptableObject
{
	[SerializeField] private CardData[] _cardData;
	public CardData[] CardData => _cardData;

}
