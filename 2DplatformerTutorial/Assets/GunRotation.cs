using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour {

	public Transform target;
	public float speed = 2f;
	private float minDistance = 1f;
	private float range;
	void Update ()
	{
		range = Vector2.Distance(transform.position, target.position);

		if (range > minDistance)
		{
			Debug.Log(range);

			transform.Translate(Vector2.MoveTowards(transform.position, target.position, range) * speed * Time.deltaTime);
		}
	}
}