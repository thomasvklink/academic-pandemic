using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODExample : MonoBehaviour
{
    FMOD.Studio.EventInstance Ambience;

    FMOD.Studio.EventDescription AmbienceDescription;
    FMOD.Studio.PARAMETER_DESCRIPTION pd;
    FMOD.Studio.PARAMETER_ID pID;

    private void Start()
    {
        Ambience = FMODUnity.RuntimeManager.CreateInstance("event:/Scene");
        Ambience.start();

        AmbienceDescription = FMODUnity.RuntimeManager.GetEventDescription("event:/Scene");
        AmbienceDescription.getParameterDescriptionByName("Level", out pd);
        pID = pd.id;
        Ambience.setParameterByID(pID, 1f);
    }

    void Update()
    {
        
    }
    
}
