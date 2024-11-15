using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class emitter : MonoBehaviour {
  // Waveプレハブを格納する
public GameObject[] waves;

	nowwave nw;
	enemac ene;
	public bool isdeath;
// 現在のWave
	private int currentWave;

	void Start(){
		nw = FindObjectOfType<nowwave> ();
		currentWave = nw.nowWave;
		StartCoroutine ("startmove");
	}

IEnumerator startmove()
{

	// Waveが存在しなければコルーチンを終了する
	if (waves.Length == 0) {
		yield break;
	}

	while (true) {

		// Waveを作成する
		GameObject wave = (GameObject)Instantiate (waves [currentWave], transform.position, Quaternion.identity);

		// WaveをEmitterの子要素にする
		wave.transform.parent = transform;
			if (nw.s == 1) {
				ene = FindObjectOfType<enemac> ();
					ene.auto = true;
				if (currentWave == 9) {
					GameObject[] boss = GameObject.FindGameObjectsWithTag("kaneboss");
					foreach (GameObject a in boss) {
						ene = a.GetComponent<enemac> ();
						ene.auto = true;
					}
					GameObject alpha = GameObject.FindWithTag("enemy10");
					ene = alpha.GetComponent<enemac> ();
					ene.auto = true;
				}
			}
			if (nw.s == 0) {
				ene = FindObjectOfType<enemac> ();
				ene.auto = false;
			}


		// Waveの子要素のEnemyが全て削除されるまで待機する
		while (wave.transform.childCount != 0) {
			yield return new WaitForEndOfFrame ();
		}

		// Waveの削除
		Destroy (wave);
			yield return new WaitForSeconds (1.5f);
			if(currentWave != 9)
				isdeath = true;
			yield return new WaitForSeconds (3);

		// 格納されているWaveを全て実行したらcurrentWaveを0にする（最初から -> ループ）
		if (waves.Length <= ++currentWave) {
				nw.nowWave = 0;
				SceneManager.LoadScene ("epelogue");
				yield break;
		}

	}
}

	public void saving(){
		nw.nowWave = currentWave;
	}
}
