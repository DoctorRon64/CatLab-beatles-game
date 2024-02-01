using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BackgroundManager : MonoBehaviour
{
	[SerializeField] private float scrollSpeed = 5f;
	[SerializeField] private float bpm = 120f;
	[SerializeField] private GameObject backgroundVersion1;
	[SerializeField] private GameObject backgroundVersion2;
	[SerializeField] private GameObject backgroundStatic;
	[SerializeField] private HighscoreManager highscoreManager;

	private bool stoppedGame = false;
	private float timeBetweenSwitches;

	private void Start()
	{
		timeBetweenSwitches = 60f / bpm;
		InvokeRepeating("SwitchBackground", 0f, timeBetweenSwitches);
	}

	private void Update()
	{
		if (!stoppedGame)
		{ 
			MoveBackground(backgroundVersion1);
			MoveBackground(backgroundVersion2);
			MoveBackground(backgroundStatic);
		}
	}

	private void MoveBackground(GameObject background)
	{
		background.transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);

		if (background.transform.position.x < -background.transform.localScale.x)
		{
			//background.transform.Translate(new Vector2(background.transform.localScale.x * 2f, 0));
		}
	}

	private void SwitchBackground()
	{
		if (backgroundVersion1.activeSelf)
		{
			backgroundVersion1.SetActive(false);
			backgroundVersion2.SetActive(true);
			AddScore();
		}
		else
		{
			backgroundVersion1.SetActive(true);
			backgroundVersion2.SetActive(false);
			AddScore();
		}
	}

	public void GameStopped()
	{
		stoppedGame = true;
		CancelInvoke("SwitchBackground");
	}

	private void AddScore()
	{
		highscoreManager.AddScore();
	}
}
