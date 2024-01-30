using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    //[SerializeField] private Image loadingBarFill;

	private void Awake()
	{
		loadingScreen.SetActive(false);
	}

	public void SkipScene()
    {
        int loading = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(LoadSceneAsync(loading));
	}

    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
        loadingScreen.SetActive(true);

        while(!operation.isDone)
        {
            //float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            //loadingBarFill.fillAmount = progressValue;

            yield return null;
        }
    }
}
