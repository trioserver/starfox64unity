using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Ship : MonoBehaviour
{

    private const float X_MAX = 3;
    private const float Y_MAX = 3;

    public Rigidbody ship;

    private float relativeDistanceZ;
	
    // Use this for initialization
	void Start ()
    {
        relativeDistanceZ = transform.position.z - ship.position.z;
	}

    // Update is called once per frame
    void Update()
    {
        float updated_z = ship.position.z + relativeDistanceZ;
        float x = ship.position.x;
        float y = ship.position.y;
        if (x > X_MAX)
        {
            x = X_MAX;
        }
        if (x < -X_MAX)
        {
            x = -X_MAX;
        }
        if (y > Y_MAX)
        {
            y = Y_MAX;
        }
        if (y < -Y_MAX)
        {
            y = -Y_MAX;
        }
        transform.position = new Vector3(x,y,updated_z);
	}
}
