using System;
using UnityEngine;

public class CarController : VehicleController
{
    private Rigidbody2D rb2d;
	private bool isInvincible = false;
	private HighscoreManager scoreManage;

	public delegate void OnPlayerDied();
	public event OnPlayerDied onPlayerDied;

	[SerializeField] private ParticleSystem particleDust;
	[SerializeField] private float CarSpeed = 1.0f;
	[SerializeField] private float InviniblilityFrames = 3.0f;

	private void Awake()
	{
		Health = MaxHealth;
		rb2d = GetComponent<Rigidbody2D>();
		scoreManage = FindObjectOfType<HighscoreManager>();
	}

	private void Update()
	{
		HandleInput();
	}

	private void LateUpdate()
	{
		if (horizontalInput > 0f)
		{
			particleDust.Play(true);
		}
	}

	protected override void HandleInput()
	{
		base.HandleInput();

		horizontalInput *= CarSpeed;
		verticalInput *= CarSpeed;

		rb2d.velocity = new Vector3(horizontalInput, verticalInput, 0);
	}

	public void InvincibleFrames()
	{
		isInvincible = true;
		Invoke("ResetInvincibility", InviniblilityFrames);
	}

	private void ResetInvincibility()
	{
		if (isInvincible)
		{
			isInvincible = false;	
		}
	}

	public override void TakeDamage(int _damage)
	{
        if (!isInvincible)
		{
			base.TakeDamage(_damage);
			scoreManage.RemoveScore(3);
		}
	}

	protected override void Die()
	{
		onPlayerDied?.Invoke();
	}
}
