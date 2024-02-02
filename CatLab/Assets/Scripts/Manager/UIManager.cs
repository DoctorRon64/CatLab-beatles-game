using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	[SerializeField] private CarController carController;
	[SerializeField] private HighscoreManager highscoreManager;
	[SerializeField] private Slider healthSlider;
	[SerializeField] private TextMeshProUGUI highScoreText;
	[SerializeField] private TextMeshProUGUI highScoreEndText;
	private void Update()
	{
		healthSlider.transform.position = new Vector3(carController.transform.position.x, carController.transform.position.y + 1.2f, 0);
	}

	private void Awake()
	{
		healthSlider.maxValue = carController.MaxHealth;
		healthSlider.value = carController.MaxHealth;
		highscoreManager.HighScoreAction += UpdateScoreText;
		carController.onHealthChanged += UpdateCarHealth;
	}

	public void HideAndShowHighScore()
	{
		highScoreText.enabled = false;
	}

	private void UpdateScoreText(int _newScore)
	{
		highScoreText.text = "High Score: " + _newScore + " Beatz";
		highScoreEndText.text = "--- High score Was ---\n" + _newScore + " Beatz";
	}

	private void UpdateCarHealth(int _newHealth)
	{
		healthSlider.value = _newHealth;
	}
}
