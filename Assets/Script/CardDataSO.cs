using UnityEngine;

namespace Script
{
	[CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/CardDataScriptableObject", order = 1)]
	public class CardDataSO : ScriptableObject
	{
		[SerializeField] public CardData[] cardData;

		public CardData GetRandom()
		{
			int index = Random.Range(0, cardData.Length);
			return cardData[index];
		}
	}
}