using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightLineMover : EnemyMover
{

    public float transformPositionX;
    public float transformPositionY;
    public float transformPositionZ;

    public override void Move()
    {
        if (!reachedDestination)
        {
            Vector3 destination = new Vector3(transformPositionX, transformPositionY, transformPositionZ);
            transform.position = Vector3.MoveTowards(transform.position, destination, 30.0F * Time.deltaTime);

            if (transform.position == destination)
            {
                reachedDestination = true;
            }
        }
    }
}
