using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour, IDamagable
{
    private Rigidbody2D rb2d;
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
