using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour {

	[SerializeField] Graphic fadeScreen;
	float fadeValue = 1f;
	float fadeStep = 0.01f;

	void Start () {
		Graphic fadeScreen = GameObject.Find("FadeScreen").GetComponent<Graphic>();
		StartCoroutine(FadeIn(fadeScreen, 5f));
	}

	IEnumerator FadeIn (Graphic graphic, float fadeTime) {
		graphic.gameObject.SetActive(true);
		while (fadeValue > 0) {
			graphic.canvasRenderer.SetAlpha(fadeValue);
			fadeValue -= fadeStep;
			graphic.canvasRenderer.SetAlpha(fadeValue);
			yield return new WaitForEndOfFrame();
		}
		graphic.gameObject.SetActive(false);
	}
}
