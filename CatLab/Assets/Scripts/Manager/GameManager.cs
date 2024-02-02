using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private Animator animDeathPopup;
	[SerializeField] private CarController carController;
	[SerializeField] private BackgroundManager backgroundManager;
	[SerializeField] private HighscoreManager highscoreManager;
	[SerializeField] private GameObject deathPopUp;
	[SerializeField] private AudioManager musicManager;
	[SerializeField] private AudioManager SFXHitManager;
	[SerializeField] private AudioManager SFXHealManager;
    private bool theGameIsOverCheck = false;
	private int beatValue = 0;

	private void Awake()
	{
		deathPopUp.SetActive(false);
		carController.onPlayerDied += GameOver;
        carController.onPlayerHit += PlayHitSFX;
		carController.onPlayerHeal += PlayHealSFX;
    }

	private void PlayHitSFX()
	{
        int biggestValue = 12 + 1;
		SFXHitManager.PlayAudio(Random.Range(0, biggestValue));
	}
    private void PlayHealSFX()
	{
        int biggestValue = 1 + 1;
        SFXHealManager.PlayAudio(Random.Range(0, biggestValue));
    }

    public void GameOver()
	{
		if (!theGameIsOverCheck)
		{
			musicManager.PlayAudio(Random.Range(0,2));
			deathPopUp.SetActive(true);
			backgroundManager.GameStopped();
			animDeathPopup.SetBool("gameover", true);
			theGameIsOverCheck = true;
		}
	}
}
