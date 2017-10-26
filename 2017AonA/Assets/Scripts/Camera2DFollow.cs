using UnityEngine;

namespace UnitySampleAssets._2D
{

    public class Camera2DFollow : MonoBehaviour
    {

        public Transform target;
        public float damping = 1;
        public float lookAheadFactor = 3;
        public float lookAheadReturnSpeed = 0.5f;
        public float lookAheadMoveThreshold = 0.1f;
        public float yPosRestriction = -1;
        public float yCamPos = -51.87f;

        private float offsetZ;
        private Vector3 lastTargetPosition;
        private Vector3 currentVelocity;
        private Vector3 lookAheadPos;
        private float nextTimeToSearch = 0; //Taxing is searches for player every frame

        // Use this for initialization
        private void Start()
        {
            lastTargetPosition = target.position;
            offsetZ = (transform.position - target.position).z;
            transform.parent = null;
        }

        // Update is called once per frame
        private void Update()
        {
            if (target == null)
            {
                FindPlayer();
                return;
            }

            // only update lookahead pos if accelerating or changed direction
            float xMoveDelta = (target.position - lastTargetPosition).x;

            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            if (updateLookAheadTarget)
            {
                lookAheadPos = lookAheadFactor*Vector3.right*Mathf.Sign(xMoveDelta);
            }
            else
            {
                lookAheadPos = Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime*lookAheadReturnSpeed);
            }

            Vector3 aheadTargetPos = target.position + lookAheadPos + Vector3.forward*offsetZ;
            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, damping);

            //clamp camera when player falls below ground


            //TODO: THIS ALLOWS THE CAMERA TO FOLLOW THE PLAYER ON THE Y AXIS AS WELL.
            //newPos = new Vector3(newPos.x, Mathf.Clamp(newPos.y+0.2f, yPosRestriction, Mathf.Infinity), newPos.z);

            //THIS ALLOWS CAMERA TO FOLLOW THE PLAYER ON THE X AXIS BUT NOT THE Y.
            newPos = new Vector3(newPos.x, Mathf.Clamp(yCamPos, yPosRestriction, Mathf.Infinity), newPos.z);

            transform.position = newPos;
            
           lastTargetPosition = target.position;
        }

        void FindPlayer()
        {
            if(nextTimeToSearch <= Time.time)
            {
                GameObject searchResult = GameObject.FindGameObjectWithTag("P1");
                if(searchResult != null)
                {
                    target = searchResult.transform;
                }
                nextTimeToSearch = Time.time + 0.5f;
            }
        }
    }
}