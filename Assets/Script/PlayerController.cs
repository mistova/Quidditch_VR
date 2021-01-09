using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speedY = 100;
    public float speedZ = 100;
    public float speedR = 10;

    public float speedLimitY = 10;
    public float speedLimitZ = 10;

    Rigidbody rgb;

    public Text text;

    void Start()
    {
        Time.timeScale = 1;
        rgb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision other)
    {
        text.text = "Game Over";
        Time.timeScale = 0;
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

    void VelocityY(int direction)
    {
        int currentDirection = -1;
        if (transform.InverseTransformDirection(rgb.velocity).y > 0)
            currentDirection = 1;
        else
            currentDirection = -1;
        if(direction == 0)
            rgb.AddForce(transform.up * Time.deltaTime * speedY * currentDirection * (-1));
        else
            rgb.AddForce(transform.up * Time.deltaTime * speedY * (4 * direction - 3 * currentDirection));
        /*if (rgb.velocity.y > speedLimitY)
            rgb.velocity = new Vector3(rgb.velocity.x, speedLimitY, rgb.velocity.z);
        else if (rgb.velocity.y < (-1) * speedLimitY)
            rgb.velocity = new Vector3(rgb.velocity.x, (-1) * speedLimitY, rgb.velocity.z);*/
    }

    void VelocityZ(int direction)
    {
        int currentDirection = -1;
        int currentDirectionSide = -1;
        if (transform.InverseTransformDirection(rgb.velocity).z > 0)
            currentDirection = 1;
        else
            currentDirection = -1;
        if (transform.InverseTransformDirection(rgb.velocity).x > 0)
            currentDirectionSide = 1;
        else
            currentDirectionSide = -1;
        rgb.AddRelativeForce(Vector3.right * Time.deltaTime * speedZ * currentDirectionSide * (-3));
        if (direction == 0)
            rgb.AddRelativeForce(Vector3.forward * Time.deltaTime * speedZ * currentDirection * (-1));
        else
            rgb.AddRelativeForce(Vector3.forward * Time.deltaTime * speedZ * (4 * direction - 3 * currentDirection));
        if (transform.InverseTransformDirection(rgb.velocity).y > speedLimitZ)
            rgb.velocity = new Vector3(transform.InverseTransformDirection(rgb.velocity).x, transform.InverseTransformDirection(rgb.velocity).y, speedLimitZ);
        else if (rgb.velocity.y < (-1) * speedLimitZ)
            rgb.velocity = new Vector3(transform.InverseTransformDirection(rgb.velocity).x, transform.InverseTransformDirection(rgb.velocity).y, (-1) * speedLimitZ);
    }
}
