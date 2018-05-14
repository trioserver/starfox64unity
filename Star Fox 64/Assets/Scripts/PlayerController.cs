using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool Rails_On = true;

    protected bool hardBankRightLock = false;
    protected bool hardBankLeftLock = false;

    protected bool boostLock = false;
    protected bool brakeLock = false;

    private Rigidbody rb;

    private const float MOVEMENT_SPEED_X_Y = 10.0f;
    private const float RAIL_SPEED = 10.0f;
    private const float BANK_ANGLE = 50.0f;
    private const float BANK_ANGLE_SPEED = 2.5f;
    private const float HARD_BANK_ANGLE = 89.0f;
    private const float HARD_BANK_ANGLE_SPEED = 5.0f;
    private const float LOOK_DIRECTION_SPEED = 1.0f;
    private const float BOOST_SPEED = 13.0f;
    private const float BRAKE_SPEED = 5.0f;

    private float movementSpeedStep_x_y;
    private float railSpeedStep;

    private float bankAngle = 0.0f;
    private float bankAngleSpeed;

    private bool usingBoost = false;
    private bool usingBrake = false;

    private bool col = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.detectCollisions = true;
        rb.freezeRotation = true;

        //rail = GetComponent<Rail>();

        movementSpeedStep_x_y = MOVEMENT_SPEED_X_Y * Time.deltaTime;
        railSpeedStep = RAIL_SPEED * Time.deltaTime;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = -Input.GetAxis("Vertical");
        //float moveForward = 0; // changes value when boosting or braking
        bool hardBankRight = Input.GetButton("HardBankRight");
        bool hardBankLeft = Input.GetButton("HardBankLeft");
        bool boost = Input.GetButton("Boost");
        bool brake = Input.GetButton("Brake");

        // R||L Bumper input == false
        if ((hardBankRight || hardBankLeft) == false)
        {
            hardBankRightLock = false;
            hardBankLeftLock = false;
            bankAngleSpeed = BANK_ANGLE_SPEED;

            if (moveHorizontal > 0)
            {
                bankAngle = -BANK_ANGLE;
            }
            else if (moveHorizontal < 0)
            {
                bankAngle = BANK_ANGLE;
            }
            else
            {
                bankAngle = 0;
            }
        }

        // R||L Bumper input == true
        else
        {
            if ((hardBankRight == true) && (hardBankLeft == false))
            {
                bankAngle = -HARD_BANK_ANGLE;
                hardBankRightLock = true;
            }
            else if ((hardBankLeft == true) && (hardBankRight == false))
            {
                bankAngle = HARD_BANK_ANGLE;
                hardBankLeftLock = true;
            }
            bankAngleSpeed = HARD_BANK_ANGLE_SPEED;
        }

        Vector3 direction = new Vector3(moveHorizontal, moveVertical, 0);
        Vector3 finalDirection = new Vector3(moveHorizontal, moveVertical, LOOK_DIRECTION_SPEED);

        Quaternion look = Quaternion.LookRotation(finalDirection) * Quaternion.AngleAxis(bankAngle, Vector3.forward);

        transform.position += direction * movementSpeedStep_x_y;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, look, bankAngleSpeed);

        // Boost input == true
        if (boost || brake)
        {
            if (boost && !brake)
            {
                boostLock = true;
            }
            else if (brake && !boost)
            {
                brakeLock = true;
            }
        }
        else
        {
            boostLock = false;
            brakeLock = false;
        }

        Rail();
    }

    private void Rail()
    {
        if (Rails_On == true)
        {
            if (boostLock)
            {
                railSpeedStep = BOOST_SPEED * Time.deltaTime;
            }
            else if (brakeLock)
            {
                railSpeedStep = BRAKE_SPEED * Time.deltaTime;
            }
            else
            {
                railSpeedStep = RAIL_SPEED * Time.deltaTime;
            }
            transform.position = transform.position + transform.forward * railSpeedStep;
        }
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