using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speedY = 100; // Y axis means forward and backward
    public float speedZ = 100; // Z axis means Up and down.
    public float speedR = 10;  // R means rotate.

    public float speedLimitY = 10;	// limit speed for forward and backward
    public float speedLimitZ = 10;	// limit speed for up and dowsn

    Rigidbody rgb;			   // We took rigidbody here. It helps us to physical movement.

    public Text text;		   // We took here text object which we will use it when we collide anywhere

    void Start()			   // Runs just one time.
    {
        Time.timeScale = 1;	   // To start game time
        rgb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision other)	//We check collision here
    {
        text.text = "Game Over";
        Time.timeScale = 0;					//When we collide anywhere game over and stop.
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            VelocityY(1);
        else if (Input.GetKey(KeyCode.LeftShift))
            VelocityY(-1);
        else
            VelocityY(0);
        if (Input.GetKey(KeyCode.W))
            VelocityZ(1);
        else if (Input.GetKey(KeyCode.S))
            VelocityZ(-1);
        else
            VelocityZ(0);
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(0, speedR * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.A))
            transform.Rotate(0, (-1) * speedR * Time.deltaTime, 0);
    }

    void VelocityY(int direction)	//To control vertical movement
    {
        int currentDirection = -1;	//We look here which side we are going
        if (transform.InverseTransformDirection(rgb.velocity).y > 0)
            currentDirection = 1;
        else
            currentDirection = -1;
        if(direction == 0)			//If we dont try to move up or down direction then player slow down at that direction
            rgb.AddForce(transform.up * Time.deltaTime * speedY * currentDirection * (-1));
        else
            rgb.AddForce(transform.up * Time.deltaTime * speedY * (4 * direction - 3 * currentDirection));// If player try to go a direction which opposite of it's direction already going then it use force more.
    }

    void VelocityZ(int direction)	//To control horizontal movement
    {
        int currentDirection = -1;	//We look here which side we are going
        int currentDirectionSide = -1;
        if (transform.InverseTransformDirection(rgb.velocity).z > 0)
            currentDirection = 1;
        else
            currentDirection = -1;
        if (transform.InverseTransformDirection(rgb.velocity).x > 0)
            currentDirectionSide = 1;
        else
            currentDirectionSide = -1;
        rgb.AddRelativeForce(Vector3.right * Time.deltaTime * speedZ * currentDirectionSide * (-3)); // We create drift effect here
        if (direction == 0)			//If we dont try to move forward or backward direction then player slow down at that direction
            rgb.AddRelativeForce(Vector3.forward * Time.deltaTime * speedZ * currentDirection * (-1));
        else
            rgb.AddRelativeForce(Vector3.forward * Time.deltaTime * speedZ * (4 * direction - 3 * currentDirection));
        if (transform.InverseTransformDirection(rgb.velocity).y > speedLimitZ) // we check speed and limited it here
            rgb.velocity = new Vector3(transform.InverseTransformDirection(rgb.velocity).x, transform.InverseTransformDirection(rgb.velocity).y, speedLimitZ);
        else if (rgb.velocity.y < (-1) * speedLimitZ)
            rgb.velocity = new Vector3(transform.InverseTransformDirection(rgb.velocity).x, transform.InverseTransformDirection(rgb.velocity).y, (-1) * speedLimitZ);
    }
}
