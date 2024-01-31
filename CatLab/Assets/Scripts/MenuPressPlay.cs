using System.Collections;
using TMPro;
using UnityEngine;

public class MenuPressPlay : MonoBehaviour
{
	[SerializeField] private string textSentence;
	[SerializeField] private TextMeshProUGUI tmproText;
	[SerializeField] private float typingSpeed = 1.0f;
	private bool typingAddOrRemove = true;

	private void Awake()
	{
		tmproText = GetComponent<TextMeshProUGUI>();
		if (tmproText == null)
		{
			Debug.LogError("TextMeshProUGUI component not found!");
			return;
		}

		tmproText.text = "";
	}

	private void Update()
	{
		if (tmproText.text == textSentence)
		{
			typingAddOrRemove = false;
			StopAllCoroutines();
			StartCoroutine(TypeSentence());
		} else if (tmproText.text == "")
		{
			typingAddOrRemove = true;
			StopAllCoroutines();
			StartCoroutine(TypeSentence());
		}
	}

	IEnumerator TypeSentence()
	{
		if (typingAddOrRemove && tmproText.text.Length < textSentence.Length)
		{
			foreach (char letter in textSentence.ToCharArray())
			{
				tmproText.text += letter;
				yield return new WaitForSeconds(typingSpeed);
			}
		}
		else if (!typingAddOrRemove && tmproText.text.Length > 0)
		{
			foreach (char letter in textSentence.ToCharArray())
			{
				tmproText.text = tmproText.text.Substring(0, Mathf.Max(0, tmproText.text.Length - 1));
				yield return new WaitForSeconds(typingSpeed);
			}
		}

		yield return new WaitForSeconds(typingSpeed);
	}
}
