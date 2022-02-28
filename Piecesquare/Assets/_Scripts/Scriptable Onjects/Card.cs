using UnityEngine;
using UnityEngine.UI;

public abstract class Card : ScriptableObject
{
	[Header("Visable Fields")]
	[SerializeField] private string _cardName;
	[SerializeField] private elementType _elementType; // Being; Ambience...
	[SerializeField] private string _elementSubtype; // Being: Beast; Animal; Plant...
	[SerializeField] private Sprite _backgroundImage;
	[SerializeField] private string _skills;
	[SerializeField] private rarity _rarity; // normal; special; legendary

	[Header("Invisable Fields")]
	[SerializeField] protected identity _identity; // air; water; fire...
	[SerializeField] private int _id;

	#region Enums

	public enum rarity
	{
		normal,
		epic,
		legendary
	}

	public enum identity
	{
		air,
		earth,
		fire,
		water,
		neutral
	}

	public enum elementType
	{
		Ambience,
		Being,
		Asset,
		Effect
	}

	#endregion

	#region Methods

	public abstract void UseCard();

	#endregion

	#region Constructors

	public Card()
	{

	}

	public Card(int Id, string CardName)
	{
		_id = Id;
		_cardName = CardName;
	}

	#endregion

	#region Properties

	public int Id => _id;
	public string CardName => _cardName;
	public identity Identity => _identity;
	public elementType ElementType => _elementType;
	public string ElementSubtype => _elementSubtype;
	public string Skills => _skills;
	public rarity Rarity => _rarity;

	#endregion

}
