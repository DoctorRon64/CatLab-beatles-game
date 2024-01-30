using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.TextCore.Text;

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
    [SerializeField] private AudioSource dialougeAudioSource;
    [SerializeField] private DialogueCharacterArchive dialogueCharacterArchive;
    [SerializeField] private LoadingScene skipToNextScene;

	private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        dialogueCharacterArchive = GetComponent<DialogueCharacterArchive>();
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
        DialogueCharacter character = dialogueCharacterArchive.characterList[currentLine.characterIndex];

		characterImage.sprite = character.icon;
		characterName.text = character.characterName;
		dialougeAudioSource.clip = character.audioClip;

		StopAllCoroutines();

        StartCoroutine(TypeSentence(currentLine));
    }

    IEnumerator TypeSentence(DialogueLine _dialogue)
    {
        dialogueArea.text = "";
   

        foreach(char letter in _dialogue.dialogueText.ToCharArray())
        {
            if (dialougeAudioSource.isPlaying == false)
            {
                dialougeAudioSource.Play();
            }

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
        skipToNextScene.SkipScene();
    }
}
