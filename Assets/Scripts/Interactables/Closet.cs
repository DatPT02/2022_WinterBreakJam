using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closet : Interactable
{
    [SerializeField] private Animator myAnimator; 
    [SerializeField] private string animatorParamName;

    private bool isOpen = false;

    public override void onFocus()
    {
        if(!this.Unlocked)
            return;

        if(!this.interacted) this.description = "Press E to get new clothes";
        else if(isOpen) this.description = "Press E to close";
        else if (!isOpen) this.description = "Press E to open";
    }

    public override void onInteract()
    {
        if(!this.Unlocked)
            return;

        isOpen = myAnimator.GetBool(animatorParamName);

        isOpen = !isOpen;
        myAnimator.SetBool(animatorParamName, isOpen);

        this.interacted = true;
    }

    public override void onLoseFocus()
    {
        if(!this.Unlocked)
            return;
    }
}
