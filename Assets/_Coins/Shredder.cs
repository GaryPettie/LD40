using System.Collections;
using UnityEngine;

public class Shredder : MonoBehaviour {

	CoinController controller;

	void Awake () {
		controller = GetComponentInParent<CoinController>();
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Container") {
			StartCoroutine(KillTheChildren(other.gameObject));
		}
	}

	IEnumerator KillTheChildren (GameObject parent) {
		foreach (Transform child in parent.transform) {
			Destroy(child.gameObject);
			yield return null;
		}
	}
}
