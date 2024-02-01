using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
	[SerializeField] private int scoreAmount = 1;
	[SerializeField] private int healthAddAmount = 1;
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
			_damagable.GrandHealth(healthAddAmount);
			highscoreManager.AddScoreAmount(scoreAmount);
			Instantiate(pickupParticlesPrefab, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}

}
