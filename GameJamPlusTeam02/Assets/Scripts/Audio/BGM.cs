using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class BGM : MonoBehaviour
{
    public FMODUnity.EventReference musicPath;
    public EventInstance musicInstance;
    public EnemyAI enemyAI;

    // Start is called before the first frame update
    void Start()
    {
        musicInstance = RuntimeManager.CreateInstance(musicPath);
        musicInstance.start();
    }

    // Update is called once per frame
    void Update()
    {
        
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
