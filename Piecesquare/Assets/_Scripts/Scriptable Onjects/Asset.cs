using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Asset", menuName = "ScriptableObjects/Asset")]
public class Asset : Card
{
    [SerializeField] private int cost;
    [SerializeField] private int defense;
    [SerializeField] private int loot;

    #region Properties

    public int Cost => cost;
    public int Defense => defense;
    public int Loot => loot;

    #endregion

    #region Methods

    public override void UseCard()
    {
        // impelment function
    }

    #endregion
}
