using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail : MonoBehaviour
{
    public float speed = 1.0f;
    public bool Rails_On = true;

	// Update is called once per frame
	void Update ()
    {
		if (Rails_On == true)
        {
            float step = speed * Time.deltaTime;
            transform.position = transform.position + transform.forward*step;
        }
	}
}
