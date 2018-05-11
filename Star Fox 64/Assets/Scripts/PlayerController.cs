using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

    private Rigidbody rb;
    private bool col = false;
    private float bankAngle = 0.0f;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.detectCollisions = true;
        rb.freezeRotation = true;
	}

    // Update is called once per frame
    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = -Input.GetAxis("Vertical");

        if (moveHorizontal > 0)
        {
            bankAngle = 30.0f;
        }
        else if (moveHorizontal < 0)
        {
            bankAngle = -30.0f;
        }
        else
        {
            bankAngle = 0.0f;
        }

        Vector3 direction = new Vector3(moveHorizontal, moveVertical, 0);
        Vector3 finalDirection = new Vector3(moveHorizontal, moveVertical, 1.0f);
        Quaternion look = Quaternion.LookRotation(finalDirection);
        look = look*Quaternion.AngleAxis(bankAngle, Vector3.forward);

        transform.position += direction * speed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, look, Mathf.Deg2Rad * 50.0f);

        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, bankAngle);

        //moveHorizontal *= Time.deltaTime;
        //moveVertical *= Time.deltaTime;
        /**
        if (col == false) {
            rb.MovePosition(transform.position + (new Vector3(moveHorizontal, moveVertical, 0.0F)) * speed * Time.deltaTime);
            
        } else
        {

        }
    **/
    }
    private void OnCollisionEnter(Collision collision)
    {
        col = true;
        //rb.AddForce(transform.up * 10.0f);
        //rb.AddForce(transform.right * 10.0f);
    }

    private void OnCollisionExit(Collision collision)
    {
        col = false;
        //rb.ResetInertiaTensor();
    }
}
