using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRail : MonoBehaviour
{
    public bool Rails_On = true;
    public PlayerController pc;
    private Vector3 velocity;

    //private const float RAIL_SPEED = 10.0f;

    private float railSpeedStep;

    void Start ()
    {
        pc = GetComponent<PlayerController>();

        railSpeedStep = pc.getRailSpeed() * Time.deltaTime;
        velocity = transform.forward * railSpeedStep;
    }
	
	void FixedUpdate ()
    {
        if (Rails_On == true)
        {
            if (pc.getBoostLock())
            {
                //railSpeedStep = pc.getBrakeSpeed() * Time.deltaTime;
                Vector3 target = new Vector3(transform.position.x,transform.position.y,transform.position.z + pc.getBoostSpeed());
                transform.position = Vector3.SmoothDamp(transform.position, target,ref velocity,1.0f);
            }
            else if (pc.getBrakeLock())
            {
                //railSpeedStep = pc.getBrakeSpeed() * Time.deltaTime;
                Vector3 target = new Vector3(transform.position.x, transform.position.y, transform.position.z + pc.getBrakeSpeed());
                transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, 1.0f);
            }
            else
            {
                //railSpeedStep = pc.getRailSpeed() * Time.deltaTime;
                Vector3 target = new Vector3(transform.position.x,transform.position.y,transform.position.z + pc.getRailSpeed());
                transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, 1.0f);
            }
            //transform.position = transform.position + transform.forward * railSpeedStep;
        }
    }
}
