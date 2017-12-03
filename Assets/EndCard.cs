using UnityEngine;
using UnityEngine.UI;

public class EndCard : MonoBehaviour {

	[SerializeField] Text scoreText;
	[SerializeField] Text timeText;
	[SerializeField] Text coinsText;

	float score;

	void Start () {
		scoreText.text = "You scored: " + ScoreManager.instance.GetScore();
		timeText.text = ScoreManager.instance.GetStoredTime().ToString();
		coinsText.text = ScoreManager.instance.GetCoins().ToString();

		ScoreManager.instance.Reset();
	}

	public void PlayAgain () {
		LevelManager.instance.LoadLevel(1);
	}
}
