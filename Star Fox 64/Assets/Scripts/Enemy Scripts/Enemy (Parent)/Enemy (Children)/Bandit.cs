using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandit : Enemy
{

    public override void Start()
    {
        fireScript.SetTarget(target);
    }

    public override void Update ()
    {
		if (!moverScript.HasReachedDestination())
        {
            moverScript.Move();
        }
        else
        {
            fireScript.RotateTowardThenFire();
        }
	}
}
