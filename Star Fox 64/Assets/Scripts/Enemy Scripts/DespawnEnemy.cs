using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnEnemy : MonoBehaviour
{

    public Rigidbody ship;
	
	void Update ()
    {
		if ((transform.position.z - ship.position.z) < (-10.0f))
        {
            //Debug.Log("destroy me");
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Inside DespawnEnemy - Trigger");
        Debug.Log(other.tag);
        if (other.tag == "Laser")
        {
            Debug.Log("Destroy clause should be called");
            Destroy(gameObject);
        }
    }
}
