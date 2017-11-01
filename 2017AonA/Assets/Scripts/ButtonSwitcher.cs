using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwitcher : MonoBehaviour {

    private Vector3 startPos;

    private Vector3 endPos;

    [SerializeField]
    private float speed = 2;

    [SerializeField]
    private Transform childTransform;

    [SerializeField]
    private Transform transformDest;
    
    public bool switchedOn;

    //public ButtonStats stats = new ButtonStats();


    // Use this for initialization
    void Start ()
    {
        startPos = childTransform.localPosition;
        endPos = transformDest.localPosition;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        Move();
    }

    void Move()
    {
        if(switchedOn)
        {
            childTransform.localPosition = Vector3.MoveTowards(endPos, startPos, speed * Time.deltaTime);
        }
        else
        {
            childTransform.localPosition = Vector3.MoveTowards(startPos, endPos, speed * Time.deltaTime);

        }
    }
}
