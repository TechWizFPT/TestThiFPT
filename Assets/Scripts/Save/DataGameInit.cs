using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataGameInit
{
    public bool isSound;
    public bool isMusic;
    public DataGameInit() 
    {
        isSound = true;
        isMusic=true;
    }
}
