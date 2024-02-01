using UnityEngine;
using System.Collections.Generic;
using FMODUnity;

[System.Serializable]
public class DialogueCharacter
{
	public string characterName;
	public Sprite icon;

	public EventReference eventName;
}

[System.Serializable]
public class DialogueCharacterArchive : MonoBehaviour
{
	public List<DialogueCharacter> characterList;
}

