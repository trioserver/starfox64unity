using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookRotation : MonoBehaviour {

    public Transform target;
    public float speed;
    public float viewRangeY = 2.0f;
    public float viewRangeX = 2.0f;

    private float x = 0;
    private float y = 0;
	
	void Update () {

        Vector3 relativePos = target.position - transform.position;
        float step = speed * Time.deltaTime;

        Quaternion lookRotation = Quaternion.LookRotation(relativePos);
        if(lookRotation.eulerAngles.x > viewRangeX && lookRotation.eulerAngles.x < 160.0f)
        {
            x = viewRangeX;
        }
        else if(lookRotation.eulerAngles.x > viewRangeX && lookRotation.eulerAngles.x < (360.0f-viewRangeX))
        {
            x = -viewRangeX;
        }
        else
        {
            x = lookRotation.eulerAngles.x;
        }
        if (lookRotation.eulerAngles.y > viewRangeY && lookRotation.eulerAngles.y < 160.0f)
        {
            y = viewRangeY;
        }
        else if (lookRotation.eulerAngles.y > viewRangeY && lookRotation.eulerAngles.y < (360.0f-viewRangeY))
        {
            y = -viewRangeY;
        }
        else
        {
            y = lookRotation.eulerAngles.y;
        }
        if (target.eulerAngles.z != 0)
        {
            float z;
            float maxLookAngle = 5.0f;
            if(target.eulerAngles.z > 160.0f)
            {
                z = target.eulerAngles.z - 360.0f;
                if (z < -maxLookAngle)
                {
                    z = -maxLookAngle;
                }
            } 
            else
            {
                z = target.eulerAngles.z;
                if (z > maxLookAngle)
                {
                    z = maxLookAngle;
                }
            }
            //z = z / 4;
            lookRotation.eulerAngles = new Vector3(x, y, z);
        }
        else
        {
            lookRotation.eulerAngles = new Vector3(x, y, 0);
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation,lookRotation,speed*Time.deltaTime);
    }
}
