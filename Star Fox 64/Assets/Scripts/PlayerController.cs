using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

    private Rigidbody rb;
    private bool col = false;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.detectCollisions = true;
        rb.freezeRotation = true;
	}

    // Update is called once per frame
    void Update() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = -Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(moveHorizontal,moveVertical,0);
        Vector3 finalDirection = new Vector3(moveHorizontal,moveVertical,1.0f);

        transform.position += direction* speed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(finalDirection),Mathf.Deg2Rad*50.0f);
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
