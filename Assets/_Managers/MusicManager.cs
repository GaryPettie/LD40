using UnityEngine;

[RequireComponent(typeof (AudioSource))]
public class MusicManager : MonoBehaviour {

	[SerializeField] AudioClip[] levelMusic;

	public static MusicManager instance;
	static AudioSource audioSource;

	void Awake () {
		if (instance == null) {
			instance = this;
			audioSource = GetComponent<AudioSource>();
			DontDestroyOnLoad(gameObject);
		}
		else {
			Destroy(this.gameObject);
			Debug.LogWarning("Duplicate Music Manager destroyed on " + gameObject.name);
		}
	}

	void Start () {
		//TODO Add volume control (from player prefs?)
	}

	void OnLevelWasLoaded (int buildIndex) {
		AudioClip thisLevelMusic = levelMusic[buildIndex];

		if (thisLevelMusic) {
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}

	public void ChangeVolume (float volume) {
		audioSource.volume = volume;
	}
}
