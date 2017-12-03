using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	[SerializeField] Slider healthBar;
	[SerializeField] Text coinTextFront;
	[SerializeField] Text coinTextBack;
	[SerializeField] Text timerTextFront;
	[SerializeField] Text timerTextBack;
	[SerializeField] Text HighScoreTextFront;
	[SerializeField] Text HighScoreTextBack;

	Player player;
	float highScore;

	void Start () {
		player = FindObjectOfType<Player>();
		healthBar.maxValue = player.GetMaxHealth();
		highScore = PlayerPrefsManager.GetHighScore();
		HighScoreTextFront.text = "High Score: " + highScore;
		HighScoreTextBack.text = "High Score: " + highScore;
		
	}

	void Update () {
		healthBar.value = player.GetCurrentHealth();
		coinTextFront.text = "Coins: " + ScoreManager.instance.GetCoins();
		coinTextBack.text = "Coins: " + ScoreManager.instance.GetCoins();
		timerTextFront.text = "Timer: " + ScoreManager.instance.GetCurrentTime();
		timerTextBack.text = "Timer: " + ScoreManager.instance.GetCurrentTime();
	}
}
