using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLaser : MonoBehaviour
{

    public Rigidbody laser;
    private float velocity = 10000.0f;
    public float laserBeginsAheadFloat = 2.0f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 laserBeginsAt = transform.position;
            laserBeginsAt.z += laserBeginsAheadFloat;
            Rigidbody newLaser = Instantiate(laser, laserBeginsAt, transform.rotation) as Rigidbody;
            newLaser.AddForce(transform.forward * velocity * Time.deltaTime, ForceMode.VelocityChange);
        }
	}
    /*
    public void fireLaser(Transform t, float _velocity = 10000.0f)
    {
        Rigidbody newLaser = Instantiate(laser, t.position, t.rotation) as Rigidbody;
        newLaser.AddForce(t.forward * _velocity * Time.deltaTime, ForceMode.VelocityChange);
    }
    */
    /*
    public void AddPrefab(GameObject prefab)
    {
        prefab.AddComponent<Rigidbody>();
        Instantiate(laser, t.position, t.rotation) as Rigidbody;
        newLaser.AddForce(t.forward * 10000.0f * Time.deltaTime, ForceMode.VelocityChange);
    }
    */
}
