using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    public float fireRate = 5f; //rate of fire. 0 = single burst, 1+ = multi
    public float Damage = 10f;

    public LayerMask whatToHit; //Tells us what we want to hit //raycast is a layer of objects which we want to hit
    public Transform BulletTrailPrefab;
    public Transform MuzzleFlashPrefab;
    public Transform HitPrefab;

    float timeToSpawnEffect = 0f;
    public float effectSpawnRate = 10f;

    float timeToFire = 0f;
    Transform firePoint;

    // Use this for initialization
    void Awake ()
    {
        firePoint = transform.Find("FirePoint");
        if(firePoint == null)
        {
            Debug.LogError("No fire point? WhaAAAAAAAT");
        }
	}

    // Update is called once per frame
    void Update()
    {
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                      Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPos = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPos, mousePos - firePointPos, 100, whatToHit); //distance is the parameter of the shooting
        
		//if (mousePos.x > firePointPos.x) { //Way to reverse fire line
		//	Debug.DrawLine(firePointPos, -(mousePos - firePointPos) * 100, Color.cyan, 0.1f, true);
		//}
        Debug.DrawLine(firePointPos, (mousePos - firePointPos) * 100, Color.cyan, 0.1f, true);

        if (hit.collider != null)
        {
            Debug.DrawLine(firePointPos, hit.point, Color.red);

            
            //    Destroy(buttoned);
                
            //    Debug.Log("We SWITCHED " + hit.collider.name + " and did " + Damage + " damage.");
            //}
        }

        if (Time.time >= timeToSpawnEffect)
        {
            //StartCoroutine("Effect");   //============IENUMERATOR
            Effect();
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
        }
        Debug.DrawLine(firePointPos, (mousePos - firePointPos) * 100, Color.cyan, 0.1f, true);
        if (hit.collider != null)
        {
            Debug.DrawLine(firePointPos, hit.point, Color.red, 0.1f, true);
            
            //hit.collider.GetComponent<ButtonSwitcher>();
            ButtonSwitcher bSwitch = GameObject.FindGameObjectWithTag("BlueSwitch").GetComponent<ButtonSwitcher>();
            GateSwitch gSwitch = GameObject.FindGameObjectWithTag("Gate1Switch").GetComponent<GateSwitch>(); ;
            //GateSwitch gSwitch2 = GameObject.FindGameObjectWithTag("Gate2Switch").GetComponent<GateSwitch>(); ;

            if (bSwitch != null || gSwitch != null )
            {


                switch (hit.transform.gameObject.tag)
                {
                    case "RedButton":
                        {
                            bSwitch = GameObject.FindGameObjectWithTag("RedSwitch").GetComponent<ButtonSwitcher>();
                            WeaponSwitchButtons(bSwitch);

                            break;
                        }
                    case "BlueButton":
                        {
                            bSwitch = GameObject.FindGameObjectWithTag("BlueSwitch").GetComponent<ButtonSwitcher>();
                            WeaponSwitchButtons(bSwitch);
                            if (!gSwitch.switchedOn)
                            {
                                gSwitch.blueSwitch = true;
                                gSwitch.switchedOn = true;
                            }
                            else
                            {
                                gSwitch.blueSwitch = false;
                                gSwitch.switchedOn = false;
                            }

                            break;
                        }
                    case "GreenButton":
                        {
                            bSwitch = GameObject.FindGameObjectWithTag("GreenSwitch").GetComponent<ButtonSwitcher>();
                            WeaponSwitchButtons(bSwitch);
                            break;
                        }
                }
            }
            //Debug.Log("SWITCHED RED BUTTON: "+ (bSwitch.switchedOn ? "ON" : "OFF"));
            //Debug.Log("SDFJKFH hit" + hit.collider.name + " and did " + Damage + " damage.");
        }

    }
    //IEnumerator Effect()
    void Effect()
    {
        Instantiate(BulletTrailPrefab, firePoint.position, firePoint.rotation); //What to spawn, position of spawn

        //Create instant in which we want to store in a variable so different instances can be randomized and different each time
        Transform clone = (Transform)Instantiate(MuzzleFlashPrefab, firePoint.position, firePoint.rotation); //Want to change things on muzzle flash after instantiated
        clone.parent = firePoint; //parent the clone to a firepoint
        float size = Random.Range(0.6f, 0.9f);
        clone.localScale = new Vector3(size, size, size);
        //Display for 1 single frame = yield return 0;
        //yield return 0; //Requires function to be an IEnumerator //Waits a single frame
        //Destroy(clone);
        Destroy(clone.gameObject, 0.02f); //Must destroy the actual game object
        //Display for multiple frames = 
    }

    void WeaponSwitchButtons(ButtonSwitcher bSwitch)
    {
        if (bSwitch.switchedOn)
        {
            bSwitch.switchedOn = false;
        }
        else
        {
            bSwitch.switchedOn = true;
        }
    }
}