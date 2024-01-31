using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	protected HighscoreManager scoreManager;
	private bool isPaused = false;

	protected void TogglePauseGame()
	{
		isPaused = !isPaused;
		if (isPaused ) { Time.timeScale = 1.0f; } else { Time.timeScale = 0.0f; }
	}

	public void GameOver()
	{
		TogglePauseGame();
	}
 }
