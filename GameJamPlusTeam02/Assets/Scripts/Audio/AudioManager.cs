using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    public FMODUnity.EventReference musicPath;
    public EventInstance musicInstance;
    public static AudioManager instance;
    public float fmodParam;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        musicInstance = RuntimeManager.CreateInstance(musicPath);
        musicInstance.start();
        musicInstance.setParameterByName("Danger", 0f, false);
        Invoke("Danger", 9);
    }
    public void Danger()
    {
        musicInstance.setParameterByName("Danger", 1f, false);
    }

    public void SafeZone()
    {
        musicInstance.setParameterByName("Danger", 0f, false);
    }
    
}
