using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public static LevelManager instance;
	[SerializeField] float autoloadTimer = 0f;

	void Awake () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else {
			Destroy(this.gameObject);
			Debug.LogWarning("Duplicate Level Manager destroyed on " + gameObject.name);
		}
		
	}

	void Start () {
		if (autoloadTimer > 0) {
			Invoke("LoadNextLevel", autoloadTimer);
		}
	}

	public void LoadMainGame () {
		Text loader = GameObject.Find("Loader").GetComponent<Text>();
		StartCoroutine(LoadAsync(loader));
	}

	IEnumerator LoadAsync (Text loader) {
		AsyncOperation operation = SceneManager.LoadSceneAsync(3);

		while (!operation.isDone) {
			if (loader != null) {
				loader.text = loader.text + "*";
			}
			yield return null;
		}
	}


	public void LoadNextLevel () {
		if (SceneManager.GetActiveScene().buildIndex + 1 == 3) {
			LoadMainGame();
		}
		else {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}

	public void LoadPreviousLevel () {
		if (SceneManager.GetActiveScene().buildIndex - 1 == 3) {
			LoadMainGame();
		}
		else {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
		}
	}

	public void LoadLevel (int buildIndex) {
		if (buildIndex ==3) {
			LoadMainGame();
		}
		else {
			SceneManager.LoadScene(buildIndex);
		}
	}

	public void QuitResuest () {
		Debug.LogWarning("Request to quit received... Exiting Application.");
		Application.Quit();
	}

	public void FadeIn (Graphic graphic, float fadeTime) {
		graphic.gameObject.SetActive(true);
		graphic.canvasRenderer.SetAlpha(0);
		graphic.CrossFadeAlpha(1, fadeTime, false);
		graphic.gameObject.SetActive(false);
	}

	public void FadeOut (Graphic graphic, float fadeTime) {
		graphic.gameObject.SetActive(true);
		graphic.canvasRenderer.SetAlpha(1);
		graphic.CrossFadeAlpha(0, fadeTime, false);
		graphic.gameObject.SetActive(false);
	}
}
