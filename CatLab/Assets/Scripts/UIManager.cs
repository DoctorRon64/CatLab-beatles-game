using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	[SerializeField] private CarController carController;
	[SerializeField] private Slider healthSlider;

	private void Update()
	{
		healthSlider.transform.position = new Vector3(carController.transform.position.x, carController.transform.position.y + 1.2f, 0);
	}

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
