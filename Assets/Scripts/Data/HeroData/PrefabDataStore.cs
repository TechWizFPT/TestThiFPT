using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PrefabDataStore", menuName = "ScriptableObjects/PrefabDataStore", order = 1)]

public class PrefabDataStore : ScriptableObject
{
    public PlayerManager playerManagerPrefab;
    public MyCharacterController characterControllerPrefab;

}
