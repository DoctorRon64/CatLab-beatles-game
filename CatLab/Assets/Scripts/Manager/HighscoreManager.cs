using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreManager : MonoBehaviour
{
	[SerializeField] private int addScoreValue = 1;
	private int highScore = 0;
	public Action<int> HighScoreAction;

	public int HighScore 
	{ 
		get 
		{ 
			return highScore; 
		} 
		set 
		{ 
			if (highScore != value) 
			{
				highScore = value; OnScoreChanged(highScore); 
			} 
		} 
	}

	public void AddScorePerBeat()
	{
		HighScore += addScoreValue;
	}

	public void AddScoreAmount(int _score)
	{
		HighScore += _score;
	}

	public void RemoveScore(int score)
	{
		HighScore -= score;
	}

	protected void OnScoreChanged(int _score)
	{
		HighScoreAction?.Invoke(_score);
	}
}
