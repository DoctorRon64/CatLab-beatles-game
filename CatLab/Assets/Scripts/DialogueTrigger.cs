using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class DialogueCharacter
{
    public string characterName;
    public Sprite icon;
}

[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(0, 10)]
    public string dialogueText;
}

[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> lines = new List<DialogueLine>();
}

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private DialogueManager manager;

    private void Awake()
    {
        manager = FindObjectOfType<DialogueManager>();

        if (manager == null)
        {
            Debug.LogError("DialogueManager not found!");
        }
        else
        {
            TriggerDialogue();
        }
    }

    [ContextMenu("jojojo")]
    public void TriggerDialogue()
    {
        if (manager != null)
        {
            manager.Instance.StartDialogue(dialogue);
        }
        else
        {
            Debug.LogError("DialogueManager is null. Cannot start dialogue.");
        }
    }
}

