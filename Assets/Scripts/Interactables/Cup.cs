using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : Interactable
{
    private bool pickedUp = false;
    public override void onFocus()
    {
        if(!this.Unlocked)
            return;

        if(pickedUp) this.description = "Press E to put down";
        else this.description = " Press E to pick up";
    }

    public override void onInteract()
    {
        if(!this.Unlocked)
            return;

        pickedUp = !pickedUp;
        this.interacted = pickedUp;
        this.gameObject.gameObject.GetComponent<MeshRenderer>().enabled = !pickedUp;
    }

    public override void onLoseFocus()
    {
        if(!this.Unlocked)
            return;
    }
}
