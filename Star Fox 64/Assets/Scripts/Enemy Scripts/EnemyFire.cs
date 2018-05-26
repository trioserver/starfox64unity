using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public Rigidbody laser;

    private Rigidbody target;

    private bool fireTrigger = false;

    public void SetTarget(Rigidbody _target)
    {
        target = _target;
    }

    public void RotateTowardThenFire()
    {
        Vector3 targetDir = target.position - transform.position;
        Quaternion look = Quaternion.LookRotation(targetDir);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, look, 200.0f * Time.deltaTime);

        if (!fireTrigger)
        {
            if (transform.rotation == look)
            {
                InvokeRepeating("Fire", 0.0f, 1.5f);
                fireTrigger = true;
            }
        }
    }

    private void Fire()
    {
        Vector3 newDir = (target.position - transform.position);
        Rigidbody instance = Instantiate(laser, transform.position + transform.forward * 3.0f, transform.rotation);
        instance.AddForce(transform.forward * 4000.0f * Time.deltaTime, ForceMode.VelocityChange);
    }
}
