using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsDatabase : MonoBehaviour
{
	public static List<Card> cardList = new List<Card>();

	private void Awake()
	{
		cardList.Add(new Being(0, "Half Elf"));
		cardList.Add(new Being(1, "Human"));
		cardList.Add(new Being(2, "Night Elf"));
	}
}
