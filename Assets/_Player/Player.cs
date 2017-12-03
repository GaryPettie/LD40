using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.PostProcessing;


public class Player : MonoBehaviour {

	[SerializeField] int powerUpCount = 4;
	[Tooltip("Damage | Invert | Fast | Invisible")]
	[SerializeField] int[] counterThresholds;
	int[] counters;
	
	[SerializeField] float damage = 5f;
	[SerializeField] float fastSpeedMod = 1.1f;

	[SerializeField] float maxHealth = 100;
	[SerializeField] float currentHealth = 100;
	[SerializeField] float baseSpeed = 10f;

	MeshRenderer mesh;
	ParticleSystem engine;
	ParticleSystem.EmissionModule emission;
	
	float translation;
	int outcome;
	public static bool isAlive = true;

	void Awake () {
		counters = new int[powerUpCount];
		currentHealth = maxHealth;
	}

	void Start () {
		mesh = GetComponentInChildren<MeshRenderer>();
		engine = GetComponentInChildren<ParticleSystem>();
		emission = engine.emission;
	}

	void Update () {
		Move();
		if (currentHealth <= 0 && isAlive) {
			Die();
		}
	}

	public float GetMaxHealth () {
		return maxHealth;
	}

	public float GetCurrentHealth () {
		return currentHealth;
	}

	void Move () {
		translation = CrossPlatformInputManager.GetAxis("Horizontal") * baseSpeed * Time.deltaTime;
		transform.Translate(new Vector3(translation, 0, 0));
	}

	void Die () {
		isAlive = false;
		Destroy(gameObject);
		ScoreManager.instance.SubmitTime();
		LevelManager.instance.LoadNextLevel();
	}

	void SelectOutcome () {
		outcome = Random.Range(0, powerUpCount);
		counters[outcome]++;

		if (counters[outcome] >= counterThresholds[outcome]) {
			PerformOutcome(outcome);
			counters[outcome] = 0;
		}		
	}

	void PerformOutcome (int outcome) {
		switch (outcome) {
			//Damage Ship
			case 0:
				currentHealth -= damage;
				break;
			//Invert Controls
			case 1:
				baseSpeed *= -1;
				break;
			//Speed Up Ship Movement
			case 2:
				baseSpeed *= fastSpeedMod;
				break;
			//Ship Invisibility Toggle;
			case 3:
				mesh.enabled = !mesh.enabled;
				emission.enabled = ! emission.enabled;
				break;
			case 4:
				baseSpeed *= fastSpeedMod;
				break;
			default:
				Debug.LogWarning("outcome not in range.");
				break;
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Coin") {
			AudioSource.PlayClipAtPoint(other.GetComponent<AudioSource>().clip, other.transform.position);
			Destroy(other.gameObject);
			ScoreManager.instance.AddCoin();
			SelectOutcome();
		}
		if (other.tag == "Bumper"){
			Die();
		}
	}

}
