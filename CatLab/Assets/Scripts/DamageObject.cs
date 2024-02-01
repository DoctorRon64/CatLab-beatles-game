using UnityEngine;

public class DamageObject : MonoBehaviour
{
	[SerializeField] private int damageAmount = 3;
	[SerializeField] private int scoreAmount = 3;
	private HighscoreManager scoreManager;

	private void Awake()
	{
		scoreManager = FindObjectOfType<HighscoreManager>();
	}
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.TryGetComponent<IDamagable>(out IDamagable _damagable))
		{
			_damagable.TakeDamage(damageAmount);
			scoreManager.RemoveScore(damageAmount);
		}

		if (collision.gameObject.TryGetComponent<CarController>(out CarController _carController))
		{
			_carController.InvincibleFrames();
		}
	}
}
