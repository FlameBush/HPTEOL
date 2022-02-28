using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Effect", menuName = "ScriptableObjects/Effect")]
public class Effect : Card
{
	[SerializeField] private int cost;

	public int Cost => cost;

	#region Methods

	public override void UseCard()
	{
		// impelment function
	}

	#endregion
}
