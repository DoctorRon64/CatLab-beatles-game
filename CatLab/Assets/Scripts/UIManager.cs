using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	[SerializeField] private CarController carController;
	[SerializeField] private Slider healthSlider;

	private void Awake()
	{
		healthSlider.maxValue = carController.MaxHealth;
		healthSlider.value = carController.MaxHealth;
		carController.onHealthChanged += UpdateCarHealth;
	}

	private void UpdateCarHealth(int _newHealth)
	{
		healthSlider.value = _newHealth;
	}

}
