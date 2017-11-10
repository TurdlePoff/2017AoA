using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Spawner : MonoBehaviour 
{

	public enum SpawnState {Spawning, Waiting, Counting }; 

	[System.Serializable]

	public class Wave
	{

		public string name; 
		public Transform enemy; 
		public int count; 
		public float rate; 
	}

	public Wave[] waves; 

	private int nextWave =0; 

	public Transform[] spawnPoints; 

	public float timeBetweenWaves = 5f; 
	private float wavecountdown; 

	private float searchCountdown = 1f; 

	private SpawnState state = SpawnState.Counting;

	void Start ()
	{
		if (spawnPoints.Length == 0) 
		{
			Debug.LogError ("No spawnpoints referanced");
		}
		wavecountdown = timeBetweenWaves; 

	}

	void Upadte()
	{

		if (state == SpawnState.Waiting) 
		{
		
		//check if enemies are still alive
			if (!EnemyisAlive ()) 
			{

				//Begin a new round
				//Debug.Log("wave Completed"); 
				WaveCompleted();
				return;
			}
			else
			{
				return;
			}

		}



		if (wavecountdown <= 0) {

			if (state != SpawnState.Spawning)
			{
				
				StartCoroutine (SpawnWave (waves [nextWave]));
			}
		}
		else
		{
			wavecountdown -= Time.deltaTime; 
		}
	}


	void WaveCompleted()
	{

		Debug.Log ("Wave Completed!"); 

		state = SpawnState.Counting;
		wavecountdown = timeBetweenWaves;

		if (nextWave + 1 > waves.Length - 1) 
		{
		
			nextWave = 0; 
			Debug.Log ("ALL WAVES COMPLETE! Looping..."); 
						
		}

		nextWave++; 
	}

	bool EnemyisAlive()
	{
		searchCountdown -= Time.deltaTime; 
		if (searchCountdown <= 0f)
		{
			searchCountdown = 1f; 
			if (GameObject.FindGameObjectsWithTag ("Enemy") == null) 
			{
				return false;
			}	
		}

		return true; 
	}

	IEnumerator SpawnWave (Wave _wave)
	{
		//Debug.Log("Spawning wave: " + _wave.name
		//state = SpawnState.Spawning; 

		//Spawn 
		for (int i = 0; i < _wave.count; i++) 
		{

			SpawnEnemy (_wave.enemy); 
			yield return new WaitForSeconds (1f / _wave.rate); 

		}

		state = SpawnState.Waiting; 

		yield break;
	}

	void SpawnEnemy(Transform _enemy)
	{
		Debug.Log ("Spawning enemy: " + _enemy.name); 

		Transform _sp = spawnPoints [Random.Range (0, spawnPoints.Length)];
		Instantiate (_enemy, _sp.position, _sp.rotation);

	}

}
