using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CardDisplay : MonoBehaviour
{
	// getting refrence to the base card
	[SerializeField] private Being being;

	#region unnecessary

	// Fields for Visual Elements
	[Header("Visual Elements")]
	private string cardName;
	private Card.elementType elementType; // Being; Ambience...
	private string elementSubtype; // Being: Beast; Animal; Plant...
	private Sprite backgroundImage;
	private string skills;
	private Card.rarity rarity; // normal; special; legendary
	private int cost;
	private int movement;
	private int range;
	private int attack;
	private int defense;
	private int loot;

	#endregion

	// UI refrences
	[SerializeField] private TextMeshProUGUI thisCardName;
	[SerializeField] private TextMeshProUGUI thisElementType;
	[SerializeField] private TextMeshProUGUI thisElementSubtype;
	[SerializeField] private Image thisBackgroundImage;
	[SerializeField] private TextMeshProUGUI thisSkills;
	[SerializeField] private TextMeshProUGUI thisRarity;
	//[SerializeField] private Text thisCost;
	[SerializeField] private TextMeshProUGUI thisMovement;
	[SerializeField] private TextMeshProUGUI thisRange;
	[SerializeField] private TextMeshProUGUI thisAttack;
	[SerializeField] private TextMeshProUGUI thisDefense;
	[SerializeField] private TextMeshProUGUI thisLoot;

	private void Awake()
	{
		// saving the local variables that we need
		thisCardName.text = "" + being.CardName;
		thisElementType.text = "" + being.ElementType;
		thisElementSubtype.text = "" + being.ElementSubtype;
		thisSkills.text = "" + being.Skills;
		//thisRarity.text = "" + being.Rarity;
		//thisCost.text = "" + being.Cost;
		thisMovement.text = "" + being.Movement;
		thisRange.text = "" + being.Range;
		thisAttack.text = "" + being.Attack;
		thisDefense.text = "" + being.Defense;
		thisLoot.text = "" + being.Loot;
	}
}
