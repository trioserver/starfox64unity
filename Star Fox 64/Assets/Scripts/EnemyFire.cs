using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{

    public Rigidbody laser;
    public Rigidbody target;

    // used public temporary floats to find good location for laser spawn
    public float x;
    public float y;
    public float z;
    public float velocity;

    private bool triggered = false;

	// Use this for initialization
	void Start ()
    {
        target = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    private void OnTriggerEnter(Collider other)
    {
        triggered = true;
        InvokeRepeating("Fire",2.0f,1.5f);
    }

    void Fire()
    {
        Vector3 newDir = (target.position - transform.position);
        Rigidbody instance = Instantiate(laser,transform.position + transform.forward*3.0f,transform.rotation);
        instance.AddForce(transform.forward * 2000.0f * Time.deltaTime, ForceMode.VelocityChange);
    }

    /*
     * public Rigidbody laser;
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
    */
}
