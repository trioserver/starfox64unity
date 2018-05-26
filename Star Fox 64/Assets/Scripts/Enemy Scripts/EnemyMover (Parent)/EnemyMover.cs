using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class EnemyMover : MonoBehaviour
{
    protected bool reachedDestination = false;

    abstract public void Move();

    public bool HasReachedDestination()
    {
        return reachedDestination;
    }
}
