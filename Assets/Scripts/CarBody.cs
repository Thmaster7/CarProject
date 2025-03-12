using UnityEngine;
using System.Collections.Generic;

public class CarBody : MonoBehaviour
{
    public Rigidbody rb;
    public List<WheelCollider> wheelsColliders;
    public int wheelsOnGround;
    public List<Wheel> wheelMeshes;
    public float velocity = 20f;
    private float rotation = 5f;
    public float acceleration;
    private float deceleration = 5f;
    private float maxSpeed = 50f;
    private float minSpeed = 10f;
    private float iners;

    

    public CarBody Auto;
    
    public bool canMove;
    private Vector3 initialPos;
    private Quaternion initialRot;
    private float forceJump = 500f;
    
    void Start()
    {

        initialPos = transform.position;
        initialRot = transform.rotation;
        

    }
    void Update()
    {
        iners = velocity;
        
        CheckIfCanMove();
        if (canMove == true)
        {
            Move();
        }
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in wheelsColliders)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (Input.GetKey(KeyCode.F))
        {
            transform.position = initialPos;
            transform.rotation = initialRot;
            rb.linearVelocity = Vector3.zero;
        }
    }

    void CheckIfCanMove()
    {
        if(wheelsOnGround > 0)
        {
            canMove = true;
            
        }
        else
        {
            canMove = false;
            

        }
        
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {

            //transform.position += transform.forward * velocity * Time.deltaTime;
            rb.linearVelocity += transform.forward * velocity * Time.deltaTime;
            velocity = Mathf.Lerp(velocity, maxSpeed, acceleration * Time.deltaTime);
            acceleration = 0.001f;
            foreach (var wheel in wheelsColliders)
            {
                wheel.transform.position = wheel.transform.position;
            }
        }
        else
        {
            velocity = Mathf.Lerp(velocity, minSpeed, deceleration * Time.deltaTime);
            velocity = Mathf.Max(velocity, minSpeed);
            acceleration = 0;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //transform.position -= transform.forward * velocity * Time.deltaTime;
            rb.linearVelocity -= transform.forward * velocity * Time.deltaTime;
            foreach (var wheel in wheelsColliders)
            {
                wheel.transform.position = wheel.transform.position;
            }
            
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.down * rotation * Time.deltaTime);
            foreach (var wheel in wheelsColliders)
            {
                wheel.transform.position = wheel.transform.position;
            }
            wheelMeshes[0].transform.Rotate(Vector3.down * rotation * Time.deltaTime);
            wheelMeshes[1].transform.Rotate(Vector3.down * rotation * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.up * rotation * Time.deltaTime);
            foreach (var wheel in wheelsColliders)
            {
                wheel.transform.position = wheel.transform.position;
            }
            wheelMeshes[0].transform.Rotate(Vector3.up * rotation * Time.deltaTime);
            wheelMeshes[1].transform.Rotate(Vector3.up * rotation * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.up * rotation * Time.deltaTime);
            foreach (var wheel in wheelsColliders)
            {
                wheel.transform.position = wheel.transform.position;
            }
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.down * rotation * Time.deltaTime);
            foreach (var wheel in wheelsColliders)
            {
                wheel.transform.position = wheel.transform.position;
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rotation = 50f;
            velocity -= deceleration * Time.deltaTime;
            velocity = Mathf.Max(velocity, minSpeed);
            acceleration = 0f;
        }
        else
        {
            rotation = 25f;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * forceJump * Time.deltaTime, transform.position.z);
        }
    }
}
