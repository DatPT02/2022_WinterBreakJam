using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : Interactable
{
    [SerializeField] private GameObject furnaceFire;
    [SerializeField] private AudioSource myAudioSource;
    [SerializeField] private Interactable[] requiredObjects;
    public override void onFocus()
    {
        if(!this.Unlocked || this.interacted)
            return;

        this.description = "Press E to light the furnace (Required: Wood)";

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

        this.interacted = true;
        myAudioSource.Play();
        furnaceFire.SetActive(true);
    }

    public override void onLoseFocus()
    {
        if(!this.Unlocked)
            return;
    }
}
