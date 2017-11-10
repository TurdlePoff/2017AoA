using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwitcher : MonoBehaviour {

   //BUTTONS
    [SerializeField]
    private Transform childTransform;
    [SerializeField]
    private Transform transformDest;

    private Vector3 startPos;
    private Vector3 endPos;

    //GATE
    [SerializeField]
    private Transform childGate;
    [SerializeField]
    private Transform childGateDest;

    private Vector3 gateStartPos;
    private Vector3 gateEndPos;

    //SHARED VARIABLES
    [SerializeField]
    private float speed = 2;
    [SerializeField]
    public bool switchedOn = false;

    // Use this for initialization
    void Start ()
    {
        startPos = childTransform.localPosition;
        endPos = transformDest.localPosition;

        gateStartPos = childGate.localPosition;
        gateEndPos = childGateDest.localPosition;
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
            childGate.localPosition = Vector3.MoveTowards(gateEndPos, gateStartPos, speed * Time.deltaTime);
        }
        else
        {
            childTransform.localPosition = Vector3.MoveTowards(startPos, endPos, speed * Time.deltaTime);
            childGate.localPosition = Vector3.MoveTowards(gateStartPos, gateEndPos, speed * Time.deltaTime);
        }
    }
}
