using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private bool hardBankRightLock = false;
    private bool hardBankLeftLock = false;

    private bool boostLock = false;
    private bool brakeLock = false;

    private Rigidbody rb;

    private const float MOVEMENT_SPEED_X_Y = 15.0f;
    private const float RAIL_SPEED = 10.0f;
    private const float BANK_ANGLE = 50.0f;
    private const float BANK_ANGLE_SPEED = 2.5f;
    private const float HARD_BANK_ANGLE = 89.0f;
    private const float HARD_BANK_ANGLE_SPEED = 5.0f;
    private const float LOOK_DIRECTION_SPEED = 1.0f;
    private const float BOOST_SPEED = 30.0f;
    private const float BRAKE_SPEED = 5.0f;

    private float movementSpeedStep_x_y;

    private bool col = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.detectCollisions = true;
        rb.freezeRotation = true;

        movementSpeedStep_x_y = MOVEMENT_SPEED_X_Y * Time.deltaTime;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = -Input.GetAxis("Vertical");
        bool hardBankRight = Input.GetButton("HardBankRight");
        bool hardBankLeft = Input.GetButton("HardBankLeft");
        bool boost = Input.GetButton("Boost");
        bool brake = Input.GetButton("Brake");

        float bankAngle = 0.0f;
        float bankAngleSpeed = 0.0f;

        Vector3 direction = new Vector3(moveHorizontal, moveVertical, 0);
        Vector3 finalDirection = new Vector3(moveHorizontal, moveVertical, LOOK_DIRECTION_SPEED);
        transform.position += direction * movementSpeedStep_x_y;

        // R||L Bumper input == false; give ship banking behavior based on joystick input
        if ((hardBankRight || hardBankLeft) == false)
        {
            BankAngle(moveHorizontal, moveVertical, ref bankAngle, ref bankAngleSpeed);
        }

        // R||L Bumper input == true; give ship banking behavior based on bumper input
        else
        {
            HardBankAngle(hardBankRight, hardBankLeft, ref bankAngle, ref bankAngleSpeed);
        }

        Quaternion look = Quaternion.LookRotation(finalDirection) * Quaternion.AngleAxis(bankAngle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, look, bankAngleSpeed);

        // Boost input
        if (boost && brake) { }
        else if (boost && !brake)
        {
            boostLock = true;
            brakeLock = false;
        }
        else if (brake && !boost)
        {
            brakeLock = true;
            boostLock = false;
        }
        else
        {
            brakeLock = false;
            boostLock = false;
        }
    }

    /*
     * Gives the ship a rotation based on the moveHorizontal and moveVertical inputs.
     * */
    private void BankAngle(float moveHorizontal, float moveVertical, ref float bank_angle, ref float bank_angle_speed)
    {
        hardBankRightLock = false;
        hardBankLeftLock = false;
        bank_angle_speed = BANK_ANGLE_SPEED;

        if (moveHorizontal > 0)
        {
            bank_angle = -BANK_ANGLE;
        }
        else if (moveHorizontal < 0)
        {
            bank_angle = BANK_ANGLE;
        }
        else
        {
            bank_angle = 0;
        }
    }


    /*
     * Gives the ship a rotation based on the hardBankRight and hardBankLeft inputs.
     * */
    private void HardBankAngle(bool hardBankRight, bool hardBankLeft, ref float bank_angle, ref float bank_angle_speed)
    {
        if (hardBankRight && hardBankLeft)
        {
            if (hardBankRightLock)
            {
                bank_angle = -HARD_BANK_ANGLE;
            }
            else if (hardBankLeftLock)
            {
                bank_angle = HARD_BANK_ANGLE;
            }
        }
        else if (hardBankRight)
        {
            bank_angle = -HARD_BANK_ANGLE;
            hardBankRightLock = true;
            hardBankLeftLock = false;
        }
        else if (hardBankLeft)
        {
            bank_angle = HARD_BANK_ANGLE;
            hardBankLeftLock = true;
            hardBankRightLock = false;
        }
        bank_angle_speed = HARD_BANK_ANGLE_SPEED;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Laser")
        {
            Debug.Log("destroy laser");
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Ship hit");
        col = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        col = false;
    }

    public bool getBoostLock()
    {
        return boostLock;
    }

    public bool getBrakeLock()
    {
        return brakeLock;
    }

    public float getBoostSpeed()
    {
        return BOOST_SPEED;
    }

    public float getBrakeSpeed()
    {
        return BRAKE_SPEED;
    }

    public float getRailSpeed()
    {
        return RAIL_SPEED;
    }
}