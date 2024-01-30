using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private float loadingLength = 10;
	private Animator anim;
	private Slider slider;

	private void Awake()
	{
        if (loadingScreen != null)
        {
			anim = loadingScreen.GetComponentInChildren<Animator>();
			slider = loadingScreen.GetComponentInChildren<Slider>();
			loadingScreen.SetActive(false);
			slider.value = 0;
        }
	}

	public void SkipScene()
	{
		int loading = SceneManager.GetActiveScene().buildIndex + 1;
		if (loadingScreen == null)
		{
			SceneManager.LoadScene(loading);
		} 
		else
		{
			StartCoroutine(LoadSceneAsync(loading));
		}
	}

    IEnumerator LoadSceneAsync(int sceneId)
    {
        loadingScreen.SetActive(true);
        anim.Play("Loading");

		float elapsedTime = 0f;

		while (elapsedTime < loadingLength)
		{
			float progressValue = elapsedTime / loadingLength;

			elapsedTime += Time.deltaTime;
			slider.value = progressValue;
			yield return null;
		}

		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

		while (!operation.isDone)
        {

            yield return null;
        }
    }
}
