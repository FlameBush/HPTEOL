using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Being", menuName = "ScriptableObjects/Being")]
public class Being : Card
{
	Card card;

	[Header("Visable Fields")]
	[SerializeField] private int _cost;
	[SerializeField] private int _movement;
	[SerializeField] private int _range;
	[SerializeField] private int _attack;
	[SerializeField] private int _defense;
	[SerializeField] private int _loot;

	#region Properties

	public int Cost => _cost;

	public int Movement => _movement;

	public int Range => _range;

	public int Attack => _attack;

	public int Defense => _defense;

	public int Loot => _loot;

	#endregion

	#region Constructors

	public Being()
	{

	}

	public Being(int Id, string CardName)
	{
		Id = card.Id;
		CardName = card.CardName;
	}

	#endregion

	#region Methods

	public override void UseCard()
	{
		// impelment function
	}

	#endregion
}
