using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : Interactable
{
    [SerializeField] private AudioSource myAudioSource;
    public override void onFocus()
    {
        if(this.interacted || !this.Unlocked) return;

        this.description = "Open gift";
    }

    public override void onInteract()
    {
        if(this.interacted || !this.Unlocked) return;
        
        myAudioSource.Play();
        this.interacted = true;
    }

    public override void onLoseFocus()
    {
    }
}
