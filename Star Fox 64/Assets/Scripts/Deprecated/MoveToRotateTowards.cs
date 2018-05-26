using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToRotateTowards : MonoBehaviour
{

    public float transformPositionX;
    public float transformPositionY;
    public float transformPositionZ;

    public Rigidbody target;

    public bool destinationReached = false;

    void Start ()
    {
	}
	
	void FixedUpdate ()
    {

        Vector3 destination = new Vector3(transformPositionX, transformPositionY,transformPositionZ);
        transform.position = Vector3.MoveTowards(transform.position,destination,30.0F*Time.deltaTime);

        if (destination == transform.position)
        {
            destinationReached = true;
            Vector3 targetDir = target.position - transform.position;
            Quaternion look = Quaternion.LookRotation(targetDir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, look, 200.0f * Time.deltaTime);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Laser")
        {
            Destroy(gameObject);
        }
    }
}
