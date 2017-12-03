using UnityEngine;

public class CoinController : MonoBehaviour {

	[SerializeField] GameObject[] coinFieldPrefabs;
	GameObject nextChunk;
	int rand;
	int lastChunk = 5;

	void Update () {
		
	}

	public void LoadNextChunk () {
		if (lastChunk == 0) {
			rand = Random.Range(1, coinFieldPrefabs.Length + 1);
		}
		else if (lastChunk == 1 || lastChunk == 2 || lastChunk == 6) {
			rand = Random.Range(1, 4);
		}
		else if (lastChunk == 3 || lastChunk == 4 || lastChunk == 5) {
			rand = Random.Range(4, 7);
		}

		nextChunk = Instantiate(coinFieldPrefabs[rand], transform.position, Quaternion.identity, transform);
		nextChunk.name = coinFieldPrefabs[rand].name;
		lastChunk = rand;
	}
}
