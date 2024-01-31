using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class KeyPress<T>
{
    public KeyCode PressedKey;
    public T SomeClass;
	public string MethodName;
}

public class DoWhenPress : MonoBehaviour
{
	public KeyPress<LoadingScene> loadClass;
	private bool isKeyPressed = false;

	private void Update()
	{
		if (Input.GetKeyDown(loadClass.PressedKey) && !isKeyPressed)
		{
			loadClass.SomeClass.Invoke(loadClass.MethodName, 1);
			isKeyPressed = true;
		}
	}
}
