using System;
using UnityEngine;

public class CarController : VehicleController
{
    private Rigidbody2D rb2d;
	private bool isDrifting;
	private bool isInvincible = false;
	[SerializeField] private ParticleSystem particleDust;
	[SerializeField] private HighscoreManager scoreManage;
	[SerializeField] private TrailRenderer[] TyreMarks;
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
		CheckDrift();
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

		if (horizontalInput < 0f) { isDrifting = true; } else { isDrifting = false; }
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
}
