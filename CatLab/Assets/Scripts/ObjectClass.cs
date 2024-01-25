using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClass : MonoBehaviour
{
	[SerializeField] private int damageAmount;
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.TryGetComponent<IDamagable>(out IDamagable _damagable))
		{
			_damagable.TakeDamage(damageAmount);
			Destroy(gameObject);
		}
	}
}
