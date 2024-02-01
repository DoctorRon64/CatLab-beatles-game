using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextColorChanger : MonoBehaviour
{
    private TextMeshProUGUI text;
    private float hue;
    [SerializeField] private float speed = 1f;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        hue += Time.deltaTime * speed; // Adjust the speed of color change here

        if (hue >= 1f)
        {
            hue = 0f;
        }

        Color rainbowColor = Color.HSVToRGB(hue, 1f, 1f);
        text.color = rainbowColor;
    }
}
