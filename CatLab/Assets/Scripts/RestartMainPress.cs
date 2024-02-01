using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMainPress : MonoBehaviour
{
	void Update()
	{
		if (gameObject.activeSelf && Input.GetKeyDown(KeyCode.Space))
		{
			SceneManager.LoadScene(0);
		}
	}
}
