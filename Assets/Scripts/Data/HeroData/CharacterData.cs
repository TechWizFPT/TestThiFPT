using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New Character", menuName = "ScriptableObjects/Character", order = 3)]

public class CharacterData : ScriptableObject
{
    public string characterName;
    public Sprite characterImg;

    public GameObject characterPrefab;
    //public int maxHP;
}
