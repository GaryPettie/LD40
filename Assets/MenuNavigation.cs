using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNavigation : MonoBehaviour {

	public void Play () {
		LevelManager.instance.LoadMainGame();
	}

	public void NextLevel () {
		LevelManager.instance.LoadNextLevel();
	}

	public void PreviousLevel () {
		LevelManager.instance.LoadPreviousLevel();
	}
}
