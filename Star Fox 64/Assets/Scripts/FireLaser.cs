using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLaser : MonoBehaviour {

    public Rigidbody laser;
    public float velocity = 100.0f;
    public float laserBeginsAheadFloat = 1.0f;

	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
        {
            Vector3 laserBeginsAt = transform.position;
            laserBeginsAt.z += laserBeginsAheadFloat;
            Rigidbody newLaser = Instantiate(laser, laserBeginsAt, laser.rotation) as Rigidbody;
            newLaser.AddForce(transform.forward * velocity, ForceMode.VelocityChange);
        }
	}
}
