using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Ship : MonoBehaviour
{

    public Rigidbody ship;

    private float relativeDistanceZ;
	
    // Use this for initialization
	void Start ()
    {
        relativeDistanceZ = transform.position.z - ship.position.z;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float updated_z = ship.position.z + relativeDistanceZ;
        transform.position = new Vector3(transform.position.x,transform.position.y,updated_z);
	}
}
