using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {


	public LayerMask enemyMask; 
	Rigidbody2D myBody; 
	public float speed; 
	Transform myTrans; 
	float MyWidth; 
	float MyHeight; 


	// Use this for initialization
	void Start () 
	{
		myTrans = this.transform; 
		myBody = this.GetComponent<Rigidbody2D> (); 
		SpriteRenderer mySprite = this.GetComponent<SpriteRenderer> (); 
		MyWidth = mySprite.bounds.extents.x; 
		MyHeight = mySprite.bounds.extents.y; 
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		//Check to see if there is gounrd in front of me before moving forward. 
		Vector2 linecastpos = myTrans.position.toVector2() - myTrans.right.toVector2() * MyWidth; 
		Debug.DrawLine (linecastpos, linecastpos + Vector2.down * 2.5f); 
		bool isGrounded = Physics2D.Linecast (linecastpos, linecastpos + Vector2.down *2.5f, enemyMask);
		Debug.DrawLine (linecastpos, linecastpos - myTrans.right.toVector2() * 0.5f); 
		bool isBlocked = Physics2D.Linecast (linecastpos, linecastpos - myTrans.right.toVector2() * 0.5f, enemyMask);

		// If there is no ground or if path is blocked, turn around 
		if (!isGrounded || isBlocked) 
		{
			Vector3 currRot = myTrans.eulerAngles; 
			currRot.y += 180; 
			speed *= 1;
			myTrans.eulerAngles = currRot; 
		}

		//Always move forawrd 
		Vector2 myVel = myBody.velocity; 
		myVel.x =myTrans.right.x * speed; 
		myBody.velocity = myVel; 
	}
}
