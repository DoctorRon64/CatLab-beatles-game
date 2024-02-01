using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
	[SerializeField] private int coinAmount;
	[SerializeField] private HighscoreManager highscoreManager;

	[SerializeField] GameObject pickupParticlesPrefab;

	private void Awake()
	{
		highscoreManager = FindObjectOfType<HighscoreManager>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent<IDamagable>(out IDamagable _damagable))
		{
			_damagable.TakeDamage(-1);
			highscoreManager.AddScoreAmount(coinAmount);
			Instantiate(pickupParticlesPrefab, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}

}
