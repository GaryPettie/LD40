using UnityEngine;

public class Destroyer : MonoBehaviour {

	CoinController controller;

	void Awake () {
		controller = GetComponentInParent<CoinController>();
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Container") {
			Destroy(other.gameObject);
		}
	}
}
