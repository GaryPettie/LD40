using UnityEngine;

public class CoinController : MonoBehaviour {

	[SerializeField] GameObject[] coinFieldPrefabs;
	GameObject nextChunk;
	int rand;
	int lastChunk = 5;

	public void LoadNextChunk () {
		if (Time.timeSinceLevelLoad < 45) {
			if (lastChunk == 0) {
				rand = Random.Range(1, coinFieldPrefabs.Length + 1);
			}
			else if (lastChunk == 1 || lastChunk == 2 || lastChunk == 6) {
				rand = Random.Range(1, 4);
			}
			else if (lastChunk == 3 || lastChunk == 4 || lastChunk == 5) {
				rand = Random.Range(4, 7);
			}
		}
		else if (Time.timeSinceLevelLoad < 90) {
			if (lastChunk == 0) {
				rand = Random.Range(1, coinFieldPrefabs.Length + 1);
			}
			else if (lastChunk == 1 || lastChunk == 2 || lastChunk == 6 || lastChunk == 7 || lastChunk == 8 || lastChunk == 12) {
				rand = Random.Range(1, 7);
				if (rand > 3) {
					rand += 3; 
				}
			}
			else if (lastChunk == 3 || lastChunk == 4 || lastChunk == 5 || lastChunk == 9 || lastChunk == 10 || lastChunk == 11) {
				rand = Random.Range(4, 10);
				if (rand > 6) {
					rand += 3;
				}
			}
		}
		else if (Time.timeSinceLevelLoad < 135) {
			if (lastChunk == 0) {
				rand = Random.Range(1, coinFieldPrefabs.Length + 1);
			}
			else if (lastChunk == 1 || lastChunk == 2 || lastChunk == 6 || lastChunk == 7 || lastChunk == 8 || lastChunk == 12) {
				rand = Random.Range(7, 10);
			}
			else if (lastChunk == 3 || lastChunk == 4 || lastChunk == 5 || lastChunk == 9 || lastChunk == 10 || lastChunk == 11) {
				rand = Random.Range(10, 13);
			}
		}


		nextChunk = Instantiate(coinFieldPrefabs[rand], transform.position, Quaternion.identity, transform);
		nextChunk.name = coinFieldPrefabs[rand].name;
		lastChunk = rand;
	}
}
