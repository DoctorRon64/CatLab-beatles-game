using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Rigidbody2D rb2d;
	[SerializeField] private float CarSpeed = 1.0f;

	private void Awake()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		HandleInput();
	}

	private void HandleInput()
	{
		float Horizontal = Input.GetAxis("Horizontal");
		float Vertical = Input.GetAxis("Vertical");

		Horizontal *= CarSpeed;
		Vertical *= CarSpeed;

		rb2d.velocity = new Vector3(Horizontal, Vertical, 0);
	}

}
