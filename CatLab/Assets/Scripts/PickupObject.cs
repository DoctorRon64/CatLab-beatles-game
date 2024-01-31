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

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent<IDamagable>(out IDamagable _damagable))
		{
			highscoreManager.AddScore();
			Destroy(gameObject);
		}
	}

}
