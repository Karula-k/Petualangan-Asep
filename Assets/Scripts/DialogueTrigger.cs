using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DilaogueClass dilaogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartsDialogue(dilaogue);
    }
}
