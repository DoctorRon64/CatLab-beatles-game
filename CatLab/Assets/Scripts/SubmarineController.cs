using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineController : VehicleController
{
	private float rotationValue = 0;

	private Rigidbody2D rb2d;
	[SerializeField] private float moveSpeed = 10;
	[SerializeField] private float slowedRotationValue = 10;
	[SerializeField] private ParticleSystem particleBubbles;

	private void Awake()
	{
		Health = MaxHealth;
		rb2d = GetComponent<Rigidbody2D>();
	}

	private void LateUpdate()
	{
		if (verticalInput != 0f)
		{
			particleBubbles.Play(true);
		}
	}

	protected override void HandleInput()
	{
		base.HandleInput();

		rotationValue += verticalInput;

		float truerotationValue = -rotationValue / slowedRotationValue;
		transform.rotation = Quaternion.Euler(0, 0, truerotationValue);

		if (horizontalInput != 0)
		{
			Vector2 moveDir = new Vector2(Mathf.Cos(truerotationValue * Mathf.Deg2Rad), Mathf.Sin(truerotationValue * Mathf.Deg2Rad));
			rb2d.velocity = moveDir * horizontalInput * moveSpeed;
		}
		if (horizontalInput == 0)
		{
			rb2d.velocity = Vector2.zero;
		}
	}
}
