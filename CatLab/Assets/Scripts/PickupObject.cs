using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
	[SerializeField] private int coinAmount;
	[SerializeField] private HighscoreManager highscoreManager;

	private void Awake()
	{
		highscoreManager = FindObjectOfType<HighscoreManager>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.TryGetComponent<IDamagable>(out IDamagable _damagable))
		{
			Destroy(gameObject);
			highscoreManager.AddScore();
		}
	}
}
