using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomBeatleText : MonoBehaviour
{
    [SerializeField] private List<string> textList;
	[SerializeField] private TextMeshProUGUI text;

	private void Awake()
	{
		text.text = textList[Random.Range(0, textList.Count)];
	}

}
