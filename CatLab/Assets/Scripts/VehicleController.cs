using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour, IDamagable
{
	protected int health;
	protected float horizontalInput;
	protected float verticalInput;

	public Action<int> onHealthChanged;
	public int MaxHealth = 20;
	public int Health
	{
		get { return health; }
		set
		{
			if (health != value)
			{
				health = Mathf.Clamp(value, 0, MaxHealth);
				OnHealthChanged(health);
			}
		}
	}

	private void Update()
	{
		HandleInput();
	}

	protected virtual void OnHealthChanged(int newHealth)
	{
		onHealthChanged?.Invoke(newHealth);
	}

	protected virtual void HandleInput()
	{
		horizontalInput = Input.GetAxis("Horizontal");
		verticalInput = Input.GetAxis("Vertical");
	}

	public virtual void TakeDamage(int _damage)
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
