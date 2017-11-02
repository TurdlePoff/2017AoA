using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;

    public Transform firePoint;
    public LayerMask whatToHit; //Tells us what we want to hit //raycast is a layer of objects which we want to hit


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
        {
            //Shooting code
            Shoot();
        }
	}

    void Shoot()
    {
        //Raycast shoot
        Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                      Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        
        Vector2 firePointPos = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePoint.transform.position, mousePos - firePointPos, 100, whatToHit, range);
        if (hit.collider != null)
        {
            Debug.DrawLine(firePointPos, hit.point, Color.red);


            //    Destroy(buttoned);

            //    Debug.Log("We SWITCHED " + hit.collider.name + " and did " + Damage + " damage.");
            //}
        }
    }
}
