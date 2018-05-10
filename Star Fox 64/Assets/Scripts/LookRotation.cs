using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookRotation : MonoBehaviour {

    public Transform target;
    public float speed;
    public float viewRange = 15.0f;

    private float x = 0;
    private float y = 0;
	
	void Update () {
        //Vector3 rotation = transform.eulerAngles;

        Vector3 relativePos = target.position - transform.position;
        float step = speed * Time.deltaTime;

        //Vector3 newDir = Vector3.RotateTowards(transform.);
        Quaternion lookRotation = Quaternion.LookRotation(relativePos);
        Debug.Log(lookRotation.eulerAngles.x);
        if(lookRotation.eulerAngles.x > viewRange && lookRotation.eulerAngles.x < 160.0f)
        {
            x = viewRange;
        }
        else if(lookRotation.eulerAngles.x > viewRange && lookRotation.eulerAngles.x < 345.0f)
        {
            x = -viewRange;
        }
        else
        {
            x = lookRotation.eulerAngles.x;
        }
        if (lookRotation.eulerAngles.y > viewRange && lookRotation.eulerAngles.y < 160.0f)
        {
            y = viewRange;
        }
        else if (lookRotation.eulerAngles.y > viewRange && lookRotation.eulerAngles.y < 345.0f)
        {
            y = -viewRange;
        }
        else
        {
            y = lookRotation.eulerAngles.y;
        }
        lookRotation.eulerAngles = new Vector3(x,y,0);
        //lookRotation.eulerAngles = new Vector3(Mathf.Clamp(lookRotation.eulerAngles.x, -15.0f,viewRange), Mathf.Clamp(lookRotation.eulerAngles.y, -15.0f,viewRange), 0);
        transform.rotation = Quaternion.RotateTowards(transform.rotation,lookRotation,speed*Time.deltaTime);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation,lookRotation,Mathf.Deg2Rad*30.0f);
        //transform.rotation = lookRotation;
    }
}
