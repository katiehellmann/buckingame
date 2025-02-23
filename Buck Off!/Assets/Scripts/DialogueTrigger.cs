using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    //https://www.youtube.com/watch?v=DOP_G5bsySA
    //script that will trigger the dialogue to start displaying

    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }

    private void Start()
    {
        // Automatically trigger dialogue when the scene starts
        TriggerDialogue();
    }
}
