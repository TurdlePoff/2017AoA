using UnityEngine;

public class ArmRotation : MonoBehaviour {

    public int rotOffset = 0;
    SpriteRenderer playerArm;   //Reference to graphics so we can change direction

    private void Awake()
    {
        playerArm = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update () {
        //Subtract pos of player from mouse pos
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();     //Keep same proportions of xyz but when added together they will == 1
        playerArm = GetComponent<SpriteRenderer>();
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;   //Find angle in degrees
        Debug.Log("Rot reached: " + rotZ);

        if ((Input.mousePosition.x) < playerArm.transform.position.x)
        {
            if (playerArm != null)
            {
                playerArm.flipY = true;
                //rotZ *= 1;
            }
        }
        else
        {
            if (playerArm != null)
            {
                playerArm.flipY = false;
            }
        }
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotOffset);
	}
}
