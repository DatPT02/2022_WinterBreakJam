using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Quest : MonoBehaviour
{
    public string narration;
    public string description;
    public Interactable[] CompleteQuestObject;

    public void startQuest()
    {
        for(int i = 0; i < CompleteQuestObject.Length; i ++)
        {
            CompleteQuestObject[i].Unlocked = true;
        }
    }

    public bool isCompleted()
    {
        for(int i = 0; i < CompleteQuestObject.Length; i ++)
        {
            if(!CompleteQuestObject[i].interacted)
                return false;
        }

        return true;
    }
}
