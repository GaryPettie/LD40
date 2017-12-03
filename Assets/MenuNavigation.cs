using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNavigation : MonoBehaviour {

	public void Play () {
		LevelManager.instance.LoadLevel(3);
	}

	public void NextLevel () {
		LevelManager.instance.LoadNextLevel();
	}

	public void PreviousLevel () {
		LevelManager.instance.LoadPreviousLevel();
	}
}
