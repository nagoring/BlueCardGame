using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;
using UnityEngine.UI;

public class Game : Singleton<Game>
{
	protected override bool DontDestroy => true;
	public GameObject gridPanel;
	public CardDataSO cardDataSo;
	public List<CardData> playerCardList = new List<CardData>();
	public GameObject cardUi;
	public GameObject[] cardUiBtnArray = new GameObject[15];
	private int _totalPower = 0;

	// Start is called before the first frame update
	void Start()
	{
		// cardUi = Instantiate(cardUi);
		PushReset();
	}
	public void CreateCardUi()
	{
		for (int i = 0; i < 15; i++)
		{
			cardUiBtnArray[i] = Instantiate(cardUi);
			cardUiBtnArray[i].transform.SetParent(gridPanel.transform, false);
			int index = i;
			cardUiBtnArray[i].GetComponent<Button>().onClick.AddListener(() => ClickCard(index));
		}
	}

	public void ClickCard(int index)
	{
		CardData cardData = playerCardList[index];
		cardUiBtnArray[index].GetComponentInChildren<Text>().text = cardData.eCardName.ToString();
		if (cardData.eCardType == ECardType.PlusMinus)
		{
			_totalPower += cardData.power;
		}
		else if (cardData.eCardType == ECardType.Times)
		{
			_totalPower *= cardData.power;
		}
		else if (cardData.eCardType == ECardType.Dead)
		{
			_totalPower = 0;
		}
		Debug.Log($"かくとく:{_totalPower}");
		if (_totalPower <= 0)
		{
			Debug.Log($"あなたの負け");
		}
	}

	public void PushReset()
	{
		DeleteCard();
		CreateCardUi();
		for (int i = 0; i < 15; i++)
		{
			CardData cardData = cardDataSo.GetRandom();
			playerCardList.Add(cardData);
		}
		
	}
	public void PushOpen()
	{
		for (int i = 0; i < 15; i++)
		{
			int index = i;
			CardData cardData = playerCardList[index];
			cardUiBtnArray[index].GetComponentInChildren<Text>().text = cardData.eCardName.ToString();
		}
	}

	public void DeleteCard()
	{
		for (int i = 0; i < 15; i++)
		{
			Destroy(cardUiBtnArray[i]);
		}
	}
}
