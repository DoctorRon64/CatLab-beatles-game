using System;
using UnityEngine;

public class CarController : MonoBehaviour, IDamagable
{
    private Rigidbody2D rb2d;
	private bool isDrifting;
	[SerializeField] private ParticleSystem particleDust;
	[SerializeField] private TrailRenderer[] TyreMarks;
	[SerializeField] private float CarSpeed = 1.0f;
	
	public Action<int> onHealthChanged;
	public int MaxHealth = 20;
	private int health;
	public int Health
	{
		get { return health; }
		set
		{
			if (health != value)
			{
				health = value;
				OnHealthChanged(health);
			}
		}
	}

	private void Awake()
	{
		Health = MaxHealth;
		rb2d = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		HandleInput();
		CheckDrift();
	}

	protected virtual void OnHealthChanged(int newHealth)
	{
		onHealthChanged?.Invoke(newHealth);
	}

	private void HandleInput()
	{
		float Horizontal = Input.GetAxis("Horizontal");
		float Vertical = Input.GetAxis("Vertical");

		Horizontal *= CarSpeed;
		Vertical *= CarSpeed;

		rb2d.velocity = new Vector3(Horizontal, Vertical, 0);

		if (Horizontal > 0f) { particleDust.Play(); }
		if (Horizontal < 0f) { isDrifting = true; } else { isDrifting = false; }

		Debug.Log("HORIZONTAL" + Horizontal);
		Debug.Log("VERTICAL" + Vertical);
	}

	private void CheckDrift()
	{
		if (isDrifting) { EmitterSettings(true); }
		else { EmitterSettings(false); }
	}

	private void EmitterSettings(bool _setEmitterTo)
	{
		foreach(TrailRenderer T in TyreMarks)
		{
			T.emitting = _setEmitterTo;
		}
	}

	public void TakeDamage(int _damage)
	{
		Health -= _damage;

		if (Health <= 0)
		{
			Die();
		}
	}

	private void Die()
	{
		Debug.Log("DIEEE!!");
	}
}
