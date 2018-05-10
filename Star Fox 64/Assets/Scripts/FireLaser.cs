using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLaser : MonoBehaviour {

    public Rigidbody laser;
    public float velocity = 100.0f;

	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
        {
            Rigidbody newLaser = Instantiate(laser, transform.position, laser.rotation) as Rigidbody;
            newLaser.AddForce(transform.forward * velocity, ForceMode.VelocityChange);
        }
	}
}
