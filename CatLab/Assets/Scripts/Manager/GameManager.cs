using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private bool isPaused = false;
	[SerializeField] private Animator animDeathPopup;
	[SerializeField] private CarController carController;
	[SerializeField] private BackgroundManager backgroundManager;
	[SerializeField] private GameObject deathPopUp;

	private void Awake()
	{
		deathPopUp.SetActive(false);
		carController.onPlayerDied += GameOver;
	}

	public void GameOver()
	{
		deathPopUp.SetActive(true);
		backgroundManager.GameStopped();
		animDeathPopup.SetBool("gameover", true);
	}
}
