using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalItem : Item
{
    public int t;
    public enum eNormalType
    {
        TYPE_ONE,
        TYPE_TWO,
        TYPE_THREE,
        TYPE_FOUR,
        TYPE_FIVE,
        TYPE_SIX,
        TYPE_SEVEN
    }

    public eNormalType ItemType;
    private void Start()
    {
       GetComponent<SpriteRenderer>().sprite = gameSettings.normalItemSprites[(int)ItemType];
    }
    public override void UpdateUI()
    {
        GetComponent<SpriteRenderer>().sprite = gameSettings.normalItemSprites[(int)ItemType];

    }
    public void SetType(eNormalType type)
    {
        ItemType = type;
    }

    internal override bool IsSameType(Item other)
    {
        NormalItem it = other as NormalItem;

        return it != null && it.ItemType == this.ItemType;
    }
}
