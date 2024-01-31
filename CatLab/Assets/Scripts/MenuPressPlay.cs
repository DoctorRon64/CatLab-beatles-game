using System.Collections;
using TMPro;
using UnityEngine;

public class MenuPressPlay : MonoBehaviour
{
	[SerializeField] private string textSentence;
	[SerializeField] private TextMeshProUGUI tmproText;
	[SerializeField] private float typingSpeed = 1.0f;

	private void Awake()
	{
		tmproText = GetComponent<TextMeshProUGUI>();
		if (tmproText == null)
		{
			Debug.LogError("TextMeshProUGUI component not found!");
			return;
		}

		tmproText.text = "";
		StartCoroutine(TypeSentence());
	}

	IEnumerator TypeSentence()
	{
		if (tmproText.text.Length < textSentence.Length)
		{
			foreach (char letter in textSentence.ToCharArray())
			{
				tmproText.text += letter;
				yield return new WaitForSeconds(typingSpeed);
			}
		}
	}
}
