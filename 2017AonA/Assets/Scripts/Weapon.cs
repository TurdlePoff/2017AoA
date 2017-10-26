using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    public float fireRate = 5f; //rate of fire. 0 = single burst, 1+ = multi
    public float Damage = 10f;

    public LayerMask whatToHit; //Tells us what we want to hit //raycast is a layer of objects which we want to hit
    public Transform BulletTrailPrefab;
    public Transform MuzzleFlashPrefab;

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
        if (Time.time >= timeToSpawnEffect)
        {
            //StartCoroutine("Effect");   //============IENUMERATOR
            Effect();
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
        }
        Debug.DrawLine(firePointPos, (mousePos - firePointPos) * 100, Color.cyan, 0.1f, true);
        if (hit.collider != null)
        {
            Debug.DrawLine(firePointPos, hit.point, Color.red);
            Debug.Log("We hit " + hit.collider.name + " and did " + Damage + " damage.");
            ButtonScript button = hit.collider.GetComponent<ButtonScript>();
            if (button != null)
            {
                button.Switch(true);
            }
        }
    }

    void Effect()//Vector3 hitPos, Vector3 hitNormal)
    {
        //Transform trail = Instantiate(BulletTrailPrefab, firePoint.position, firePoint.rotation) as Transform;
        //LineRenderer lr = trail.GetComponent<LineRenderer>();

        //if (lr != null)
        //{
        //    lr.SetPosition(0, firePoint.position);
        //    lr.SetPosition(1, hitPos);
        //}

        //Destroy(trail.gameObject, 0.04f);

        //if (hitNormal != new Vector3(9999, 9999, 9999))
        //{
        //    Transform hitParticle = Instantiate(HitPrefab, hitPos, Quaternion.FromToRotation(Vector3.right, hitNormal)) as Transform;
        //    Destroy(hitParticle.gameObject, 1f);
        //}

        Transform clone = Instantiate(MuzzleFlashPrefab, firePoint.position, firePoint.rotation) as Transform;
        clone.parent = firePoint;
        float size = Random.Range(0.6f, 0.9f);
        clone.localScale = new Vector3(size, size, size);
        Destroy(clone.gameObject, 0.02f);
    }
}