using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {

    [System.Serializable]


    public class PlayerStats
    {
        public int Health = 2;

        //public void KillPlayer();
    }

	//Player pStats = new PlayerStats();


    public PlayerStats playerStats = new PlayerStats();
    public int fallYBoundary = -20;
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
	{
	}

    void Update()
    {
        if(transform.position.y <= fallYBoundary)
        {
            DamagePlayer(9999999);
        }
    }
    
    public void DamagePlayer(int damage)
    {
        playerStats.Health -= damage;
        if(playerStats.Health <= 0)
        {
            GameMaster.KillPlayer(this);
        }
    }

	void Hurt()
	{

	}

    void OnTriggerEnter2D(Collider2D collsion)
    {
        if (collsion.gameObject.layer == 13) //Spikes
        {
            DamagePlayer(9999999);
        }
    }

    void OncollsionEnter2D(Collision2D collsion)
	{
		EnemyPatrol enemy = collsion.collider.GetComponent<EnemyPatrol> (); 
		if (enemy != null) 
		{
			DamagePlayer (1);  
		}
	}
		
}
