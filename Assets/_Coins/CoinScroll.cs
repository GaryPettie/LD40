using UnityEngine;

public class CoinScroll : MonoBehaviour {

	[SerializeField] float scrollSpeed = 1f;
	
	void FixedUpdate () {
		transform.Translate(new Vector3(0, -scrollSpeed * Time.deltaTime, 0));
	}

	public void StopScroll () {
		scrollSpeed = 0f;
	}
}
