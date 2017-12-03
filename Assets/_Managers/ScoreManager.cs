using UnityEngine;

public class ScoreManager : MonoBehaviour {

	int coinCount = 0;
	float timer = 0f;

	public static ScoreManager instance;

	void Awake () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
			Debug.LogWarning("Duplicate Score Manager destroyed on " + gameObject.name);

		}
		else {
			Destroy(this.gameObject);
		}
	}

	public void AddCoin () {
		coinCount++;
	}

	public int GetCoins () {
		return coinCount;
	}

	public float GetCurrentTime () {
		return Mathf.Round(Time.timeSinceLevelLoad * 100) / 100;
	}

	public void SubmitTime () {
		timer = Mathf.Round(Time.timeSinceLevelLoad * 100) / 100;
	}
	
	public float GetStoredTime () {
		return timer;
	}

	public float GetScore () {
		float score = Mathf.Round((timer * 10) * ((float)coinCount / 4));
		float highscore = PlayerPrefsManager.GetHighScore();

		if (score > highscore) {
			PlayerPrefsManager.StoreHighScore(score);
			Debug.Log("Score saved");
		}

		return score;

	}

	public void Reset () {
		timer = 0;
		coinCount = 0;
	}
}
