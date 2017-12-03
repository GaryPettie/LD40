using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScreen : MonoBehaviour {

	public void Play () {
		LevelManager.instance.LoadLevel(3);
	}

	public void Instructions () {
		LevelManager.instance.LoadNextLevel();
	}
}
