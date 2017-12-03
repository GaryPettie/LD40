using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	CoinController controller;

	void Awake () {
		controller = GetComponentInParent<CoinController>();
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Container") {
			controller.LoadNextChunk();
		}
	}
}
