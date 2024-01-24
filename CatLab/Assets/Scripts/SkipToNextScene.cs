using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipToNextScene : MonoBehaviour
{
    public void SkipScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
