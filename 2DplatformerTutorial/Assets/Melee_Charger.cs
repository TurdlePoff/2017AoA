using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_Charger : MonoBehaviour {


	public float enemySpeed;
	bool canflip = true; 
	bool facingRight = false; 

	//facing
	public GameObject enemyGraphic; 

	//Attacking
	public float ChargeTime;
	float StartChargeTime; 
	bool charging; 
	Rigidbody2D enemyRB; 

	// Use this for initialization
	void Start ()
	{
		enemyRB = GetComponent<Rigidbody2D> (); 
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	void OnTriggerEnter2D(Collider2D Other)
	{
		if (Other.tag == "Player") 
		{
			if (facingRight && Other.transform.position.x < transform.position.x) 
			{
				flipfacing ();
			} else if (!facingRight && Other.transform.position.x > transform.position.x) 
			{
				flipfacing (); 
			}
			canflip = false; 
			charging = true; 
			StartChargeTime = Time.time + ChargeTime; 
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.tag == "Player") 
			{
			if (StartChargeTime < Time.time) 
				{
				if (!facingRight) {
					enemyRB.AddForce (new Vector2 (-1, 0) * enemySpeed);
				} else
					enemyRB.AddForce (new Vector2 (1, 0) * enemySpeed); 
				{
					//Enemy animator
				}
				}
			}

	}
	void OnTriggerExit (Collider other)
	{
		if(other.tag == "Player")
		{
			canflip = true; 
			charging = false; 
			enemyRB.velocity = new Vector2(0.0f,0.0f);
			//Enemy animator
		}
	}

	void flipfacing()
	{
		if (!canflip) {
			return;
		}
		float facingX = enemyGraphic.transform.localScale.x; 
			facingX *= -1f; 
		enemyGraphic.transform.localScale = new Vector3 (facingX, enemyGraphic.transform.localScale.y, enemyGraphic.transform.localScale.z); 
		facingRight = !facingRight; 
	}
}