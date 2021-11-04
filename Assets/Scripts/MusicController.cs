using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string LevelEvent = "";

    //Reference FMOD Event
    FMOD.Studio.EventInstance level;

    //Reference scene to check where in the game we are
    Scene scene;
    float sceneIndex;
    
    void Start()
    {
        level = FMODUnity.RuntimeManager.CreateInstance(LevelEvent);
        level.start();
        level.setParameterByName("Level Para", 0f);
    }

    void Update()
    {
        //Get active scene
        scene = SceneManager.GetActiveScene();
        //Debug.Log("Active scene: " + scene.name + "\nActive scene index: " + scene.buildIndex);
        //Set local variable to index
        sceneIndex = scene.buildIndex;

        //Check and change parameters
        Change();
    }

    void Change()
    {
        if(sceneIndex == 0)
        {
            level.setParameterByName("Level Para", 0f);
        }

        if(sceneIndex == 1)
        {
            level.setParameterByName("Level Para", 1f);
        }
    }
}
