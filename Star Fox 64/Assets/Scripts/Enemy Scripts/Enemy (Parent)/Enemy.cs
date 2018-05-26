using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Enemy : MonoBehaviour {

    public Rigidbody target;

    [SerializeField]
    protected EnemyMover moverScript;

    [SerializeField]
    protected EnemyFire fireScript;

    abstract public void Start();

    abstract public void Update();
}
