using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : Interactable
{
    [SerializeField] AudioSource myAudioSource;

    [SerializeField] private GameObject[] lights;
    private bool isOn = false;

    public override void onFocus()
    {
        this.description = " Press E to toggle light";
    }

    public override void onInteract()
    {
        myAudioSource.Play();
        toggleLight();
        this.interacted = true;
    }

    public override void onLoseFocus()
    {
    }

    public void toggleLight()
    {
        isOn = lights[0].gameObject.activeInHierarchy;
        isOn = !isOn;
        foreach(GameObject light in lights)
        {
            light.SetActive(isOn);
        }
    }
}
