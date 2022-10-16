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
    private void Update()
    {
        musicInstance.setParameterByName("Danger", 1f, false);
        musicInstance.getParameterByName("Danger", out fmodParam);
        print(fmodParam.ToString());
    }
    void Start()
    {
        instance = this;
        musicInstance = RuntimeManager.CreateInstance(musicPath);
        musicInstance.start();
        musicInstance.setParameterByName("Danger", 0f, false);
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
