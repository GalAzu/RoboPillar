using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class BGM : MonoBehaviour
{
<<<<<<< HEAD
    public FMODUnity.EventReference musicPath;
    public EventInstance musicInstance;
<<<<<<< Updated upstream
=======
    public ThirdPersonCharacter character;

>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {
        musicInstance = RuntimeManager.CreateInstance(musicPath);
        musicInstance.start();
        character = FindObjectOfType<ThirdPersonCharacter>();
=======
    public EventReference musicPath;
   public EventInstance musicInst;
    // Start is called before the first frame update
    void Start()
    {
        musicInst = RuntimeManager.CreateInstance(musicPath);
        musicInst.setParameterByName("Danger", 0f, false);
        musicInst.start();


>>>>>>> main
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
<<<<<<< Updated upstream

=======
        if (character.isPatrol)
        {
            SafeZone();
        }
        if (character.isChased)
        {
            Danger();
        }
>>>>>>> Stashed changes
    }

    public void Danger()
    {
        musicInstance.setParameterByName("Danger", 1f, false);

    }

    public void SafeZone()
    {
        musicInstance.setParameterByName("Danger", 0f, false);
    }
<<<<<<< Updated upstream
=======
    private void OnDestroy()
    {
        musicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

>>>>>>> Stashed changes
=======

    }

    public void MusicParameter()
    {
        musicInst.setParameterByName("Danger", 1f, false);
    }


    private void OnDestroy()
    {
        musicInst.release();
        musicInst.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
>>>>>>> main
}
