using UnityEngine;

public static class PlayerPrefsManager {

	const string HIGH_SCORE = "high_score";

	public static void DeleteAll() {
		PlayerPrefs.DeleteAll();
	}

	public static void StoreHighScore (float score) {
		if (score > GetHighScore()) {
			PlayerPrefs.SetFloat(HIGH_SCORE, score);
		}
	}

	public static float GetHighScore () {
		return PlayerPrefs.GetFloat(HIGH_SCORE, 0);
	}
}
