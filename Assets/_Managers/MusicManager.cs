using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

	void OnLevelWasLoaded (int buildIndex) {
		AudioClip thisLevelMusic = levelMusic[buildIndex];

		if (thisLevelMusic) {
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.volume = 0;
			StartCoroutine(FadeIn());
			audioSource.Play();
		}
	}

	IEnumerator FadeIn() {
		while (audioSource.volume < 1) {
			audioSource.volume += 0.01f;
			yield return null;
		}
	}
}
