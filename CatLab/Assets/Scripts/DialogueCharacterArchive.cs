using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class DialogueCharacter
{
	public string characterName;
	public Sprite icon;
	public AudioClip audioClip;
}

[System.Serializable]
public class DialogueCharacterArchive : MonoBehaviour
{
	public List<DialogueCharacter> characterList;
}

