using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int towersOnMap;
    public void Awake()
    {
        instance = this;
        towersOnMap = FindObjectsOfType<Towers>().Length;
    }

}