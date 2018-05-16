using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToRotateTowards : MonoBehaviour
{

    public float transformPositionX;
    public float transformPositionY;
    public float transformPositionZ;

    public Rigidbody target;

    public bool triggered = false;

    void Start ()
    {
        //target = GetComponent<Rigidbody>();
        //rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate ()
    {

        Vector3 destination = new Vector3(transformPositionX, transformPositionY,transformPositionZ);
        transform.position = Vector3.MoveTowards(transform.position,destination,30.0F*Time.deltaTime);

        if (triggered)
        {
            Vector3 targetDir = target.position - transform.position;
            Quaternion look = Quaternion.LookRotation(targetDir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, look, 200.0f * Time.deltaTime);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter trigger");
        triggered = true;
    }
}
