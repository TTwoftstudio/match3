using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : ScriptableObject
{
    public int BoardSizeX = 5;

    public int BoardSizeY = 5;

    public int MatchesMin = 3;

    public int LevelMoves = 16;

    public float LevelTime = 30f;

    public float TimeForHint = 5f;

    public Sprite[] normalItemSprites;

    public Sprite[] bonusItemSprites;

    public NormalItem normalItemPrefab;

    public BonusItem bonusItemPrefab;

}
