using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    
    [HideInInspector] public bool interacted = false;
    [HideInInspector] public bool Unlocked = false;
    [HideInInspector] public string description;
    public abstract void onInteract();
    public abstract void onFocus();
    public abstract void onLoseFocus();
}
