using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTap : Interactable
{
    [SerializeField] private AudioSource myAudioSource;
    [SerializeField] private Interactable[] requiredObjects;
    public override void onFocus()
    {
        if(!this.Unlocked || this.interacted) 
            return;
        this.description = "Press E to drink water (Required: Cup)";

        for(int i = 0; i < requiredObjects.Length; i ++)
        {
            requiredObjects[i].Unlocked = true;
        }
    }

    public override void onInteract()
    {
        if(!this.Unlocked || this.interacted)
            return;

        for(int i = 0; i < requiredObjects.Length; i ++)
        {
            if(!requiredObjects[i].interacted)
                return;
        }

        Debug.Log("Drink Water");
        myAudioSource.Play();
        this.interacted = true;
    }

    public override void onLoseFocus()
    {
        
    }
}
