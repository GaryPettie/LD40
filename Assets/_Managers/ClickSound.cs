using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))] 
public class ClickSound : MonoBehaviour {

	AudioSource audio;

	void Start () {
		audio = GetComponent<AudioSource>();
	}

	public void PlaySound () {
		audio.Play();
	}
}
