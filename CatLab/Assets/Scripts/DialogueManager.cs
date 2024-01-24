using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public DialogueManager Instance;

    [SerializeField] private Image characterImage;
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private TextMeshProUGUI dialogueArea;

    public Queue<DialogueLine> lines = new Queue<DialogueLine>();
    [Range(0, 2)]
    [SerializeField] private float typingSpeed = 1.0f;
    [SerializeField] private bool isDialogueActive = false;
    [SerializeField] private Animator anim;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextDialogue();
        }
    }

    public void StartDialogue(Dialogue _dialogue)
    {
        isDialogueActive = true;

        anim.Play("Show");
        lines.Clear();

        foreach (DialogueLine dialogueLine in _dialogue.lines)
        {
            lines.Enqueue(dialogueLine);
        }

        DisplayNextDialogue();
    }

    private void DisplayNextDialogue()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }
        anim.Play("Show");

        DialogueLine currentLine = lines.Dequeue();

        characterImage.sprite = currentLine.character.icon;
        characterName.text = currentLine.character.characterName;

        StopAllCoroutines();

        StartCoroutine(TypeSentence(currentLine));
    }

    IEnumerator TypeSentence(DialogueLine _dialogue)
    {
        dialogueArea.text = "";
        foreach(char letter in _dialogue.dialogueText.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private void EndDialogue()
    {
        isDialogueActive = false;
        anim.Play("Hide");

        if (lines.Count == 0)
        {
            Invoke("SkipScene", 1.0f);
        }
    }
    void SkipScene()
    {
        SkipToNextScene skipToNextScene = GetComponent<SkipToNextScene>();
        skipToNextScene.SkipScene();
    }
}
