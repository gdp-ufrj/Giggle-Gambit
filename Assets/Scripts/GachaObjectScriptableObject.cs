using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/GachaObjectScriptableObject", order = 1)]
public class GachaObjectScriptableObject : ScriptableObject
{
    public string itemName;

    public Color itemColor;
    public Sprite ItemSprite;
    public TextAsset choice1Text, choice1Result,choice2Text,choice2Result,choice3Text,choice3Result;
    public int choice1change, choice2Change, choice3change;
}

