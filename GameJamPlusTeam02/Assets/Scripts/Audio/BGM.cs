using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class BGM : MonoBehaviour
{
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
    }

    // Update is called once per frame
    void Update()
    {
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
}
