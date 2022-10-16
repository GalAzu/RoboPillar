using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int towersOnMap;
    public void Awake()
    {
        instance = this;
        towersOnMap = FindObjectsOfType<Towers>().Length;
    }
    public void GameOver()
    {
        AudioManager.instance.musicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        SceneManager.LoadScene(2);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}