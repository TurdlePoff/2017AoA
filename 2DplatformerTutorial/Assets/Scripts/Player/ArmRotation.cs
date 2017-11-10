using UnityEngine;

public class ArmRotation : MonoBehaviour {

    public int rotOffset = 0;
	SpriteRenderer arm;
	GameObject firePoint;
	Vector3 localPos;
	void Start()
	{
		arm = GetComponent<SpriteRenderer> ();
		localPos = this.gameObject.transform.GetChild (0).GetChild (0).gameObject.transform.localPosition;
	}
	// Update is called once per frame
	void Update () {


		//Subtract pos of player from mouse pos //Input.mousePosition
		Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

		if (difference.x > 0) 
		{
			localPos.y = -0.1f;
			this.gameObject.transform.GetChild (0).GetChild (0).gameObject.transform.localPosition = localPos;
			//.y -= 5;
			arm.flipY = false;
		} else 
		{
			localPos.y = 0.2f;
			this.gameObject.transform.GetChild (0).GetChild (0).gameObject.transform.localPosition = localPos;
			arm.flipY = true;
		}
        difference.Normalize();     //Keep same proportions of xyz but when added together they will == 1

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;   //Find angle in degrees

		transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotOffset);

	}
}
