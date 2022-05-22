namespace Script
{
	[System.Serializable]
	public enum ECardType
	{
		PlusMinus,
		Times,
		Dead,
	}

	public enum ECardName
	{
		Sword5,
		Sword10,
		Sword20,
		BrokenSword5,
		BrokenSword10,
		BrokenSword20,
		Orb,
		Dead,
	}
	[System.Serializable]
	public class CardData
	{
		public ECardName eCardName;
		public ECardType eCardType;
		public int power;
	}
}