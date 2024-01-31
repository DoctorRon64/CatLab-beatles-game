using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScroller : MonoBehaviour
{
    [SerializeField] private RawImage imageBackground;
    [SerializeField] private Vector2 bgDirection;

	private void Update()
	{
		imageBackground.uvRect = new Rect(imageBackground.uvRect.position + bgDirection * Time.deltaTime, imageBackground.uvRect.size);
	}
}
