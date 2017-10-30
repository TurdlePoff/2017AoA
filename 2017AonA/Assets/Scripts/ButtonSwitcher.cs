using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwitcher : MonoBehaviour {

    private Vector3 endPos;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform childTransform;

    [SerializeField]
    private Transform transformDest;
    
    public bool switchedOn;

    //public ButtonStats stats = new ButtonStats();


    // Use this for initialization
    void Start ()
    {
        endPos = transformDest.localPosition;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (switchedOn)
        {
            Move();
        }
    }

    public void Switch(bool val)
    {
        switchedOn = val;
    }

    void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, endPos, speed * Time.deltaTime);
    }
}
