using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundDialogueController : MonoBehaviour
{
    [SerializeField] private List<GameObject> sprites;
    private int bgIndex = -1;

    public void NextBg()
    {
        bgIndex++;
        foreach (var sprite in sprites)
        {
            sprite.SetActive(false);
        }
        sprites[bgIndex].SetActive(true);
    }
}
