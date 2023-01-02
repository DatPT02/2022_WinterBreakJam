using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerTap : Interactable
{
    [SerializeField] AudioSource myAudioSource;
    [SerializeField] private Interactable[] requiredObjects;
    public override void onFocus()
    {
        if(!this.Unlocked || this.interacted)
            return;

        this.description = "Press E to take a shower (Required: New clothes)";
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

        Debug.Log("Take a shower");
        myAudioSource.Play();
        this.interacted = true;
    }

    public override void onLoseFocus()
    {
        
    }
}
