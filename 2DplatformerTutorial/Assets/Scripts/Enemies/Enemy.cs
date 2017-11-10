using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


	[System.Serializable]


	public class EnemyStats
	{
		public int Health = 100;

		//public void KillPlayer();
	}

	//Player pStats = new PlayerStats();


	public EnemyStats Stats = new EnemyStats();
	public int fallYBoundary = -20;

	void Start()
	{
	}

	void Update()
	{
		if(transform.position.y <= fallYBoundary)
		{
			DamageEnemy(9999999);
		}


	}

	public void  DamageEnemy(int damage)
	{
		Stats.Health -= damage;
		if(Stats.Health <= 0)
		{
			GameMaster.KillEnemy(this);
		}
	}

	void Hurt()
	{

	}

	void OnTriggerEnter2D(Collider2D collsion)
	{
		if (collsion.gameObject.layer == 13) //Spikes
		{
			DamageEnemy (9999999);
		}
	}

	void OncollsionEnter2D(Collision2D collsion)
	{

		EnemyPatrol enemy = collsion.collider.GetComponent<EnemyPatrol> (); 
		if (enemy != null) 
		{
			DamageEnemy (1);  
		}
	}

}
