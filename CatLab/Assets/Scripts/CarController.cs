using System;
using UnityEngine;

public class CarController : VehicleController
{
    private Rigidbody2D rb2d;
	private bool isInvincible = false;

	public delegate void OnPlayerDied();
	public event OnPlayerDied onPlayerDied;

	public delegate void OnPlayerHit();
    public event OnPlayerHit onPlayerHit;

    public delegate void OnPlayerHeal();
    public event OnPlayerHeal onPlayerHeal;

    private bool isDead;

	[SerializeField] private ParticleSystem particleDust;
	[SerializeField] private float CarSpeed = 1.0f;
	[SerializeField] private float InviniblilityFrames = 3.0f;

	private void Awake()
	{
		Health = MaxHealth;
		rb2d = GetComponent<Rigidbody2D>();
		
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

		if (!isDead)
		{
			rb2d.velocity = new Vector3(horizontalInput, verticalInput, 0);
		}
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
        onPlayerHit?.Invoke();
        if (!isInvincible)
		{
			base.TakeDamage(_damage);
		}
	}

	public override void GrandHealth(int _health)
	{
        onPlayerHeal?.Invoke();
        Health += _health;
	}

	protected override void Die()
	{
		isDead = true;
		onPlayerDied?.Invoke();
	}
}
