using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

	CoinController controller;
	bool hasTriggered = false;

	void Awake () {
		controller = GetComponentInParent<CoinController>();
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Container") {
			other.gameObject.SetActive(false);
			//TODO Need a better way to destroy the coin block.
			//Currently offset by 1 sec to allow time for new block to be created before the current one gets destroyed (cuts down a little bit of lag).
			Destroy(other.gameObject, 1f);
			controller.LoadNextChunk();
		}
	}
}
