using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideUI : MonoBehaviour
{
    public GameObject tutorial;
    private void Start()
    {
        Invoke("HideTutorial", 10);
    }
    private void HideTutorial()
    {
        tutorial.SetActive(false);
    }
}
