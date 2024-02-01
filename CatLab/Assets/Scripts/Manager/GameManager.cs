using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private bool isPaused = false;
	[SerializeField] private Animator animDeathPopup;
	[SerializeField] private CarController carController;
	[SerializeField] private GameObject deathPopUp;

	private void Awake()
	{
		deathPopUp.SetActive(false);
		carController.onPlayerDied += GameOver;
	}

	protected void TogglePauseGame()
	{
		isPaused = !isPaused;
		Time.timeScale = isPaused ? 0.0f : 1.0f;
	}

	public void GameOver()
	{
		deathPopUp.SetActive(true);

		StopAllCoroutines();
		StartCoroutine(PlayAnimationAndPause());
	}

	private IEnumerator PlayAnimationAndPause()
	{
		animDeathPopup.SetBool("gameover", true);

		yield return new WaitForSeconds(animDeathPopup.GetCurrentAnimatorStateInfo(0).length + 1);

		TogglePauseGame();
	}
}
