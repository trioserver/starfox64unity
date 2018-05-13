using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

    private Rigidbody rb;
    private bool col = false;
    private float bankAngle = 0.0f;
    private float hardBankAngle = 89.0f;
    private float bankAngleSpeed;
    private bool hardBankRightLock = false;
    private bool hardBankLeftLock = false;

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
        bool hardBankRight = Input.GetButton("HardBankRight");
        bool hardBankLeft = Input.GetButton("HardBankLeft");

        if ((hardBankRight || hardBankLeft) != true)
        {
            hardBankRightLock = false;
            hardBankLeftLock = false;
            bankAngleSpeed = 2.5f;

            if (moveHorizontal > 0)
            {
                bankAngle = -50.0f;
            }
            else if (moveHorizontal < 0)
            {
                bankAngle = 50.0f;
            }
            else
            {
                bankAngle = 0.0f;
            }
        }
        else
        {
            if ((hardBankRight == true) && (hardBankLeft == false))
            {
                bankAngle = hardBankAngle;
                hardBankRightLock = true;
            }
            else if ((hardBankLeft == true) && (hardBankRight == false))
            {
                bankAngle = -hardBankAngle;
                hardBankLeftLock = true;
            }
            /**
            else
            {
                if (hardBankRightLock == true)
                {
                    bankAngle = hardBankAngle;
                }
                else
                {
                    bankAngle = -hardBankAngle;
                }
            }
            */
            bankAngleSpeed = 5.0f;
        }
        Vector3 direction = new Vector3(moveHorizontal, moveVertical, 0);
        Vector3 finalDirection = new Vector3(moveHorizontal, moveVertical, 1.0f);
        Quaternion look = Quaternion.LookRotation(finalDirection);
        look = look*Quaternion.AngleAxis(bankAngle, Vector3.forward);

        transform.position += direction * speed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, look, bankAngleSpeed);

    }
    private void OnCollisionEnter(Collision collision)
    {
        col = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        col = false;
    }
}
