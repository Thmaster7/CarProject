using UnityEngine;
using System.Collections.Generic;

public class CarBody : MonoBehaviour
{
    public Rigidbody rb;
    public List<WheelCollider> wheelsColliders;
    public int wheelsOnGround;
    public List<Wheel> wheelMeshes;
    public float velocity = 3000f;
    private float rotation = 40f;
    public float acceleration;
    private float deceleration = 10f;
    private float maxSpeed = 30f;
    private float minSpeed = 0.1f;
    private Quaternion currentRotation;
   

    

    public CarBody Auto;
    
    public bool canMove;
    private Vector3 initialPos;
    private Quaternion initialRot;
    private float forceJump = 500f;
    
    void Start()
    {

        initialPos = transform.position;
        initialRot = transform.rotation;
        rb.centerOfMass = new Vector3(0, -0.5f, 0);



    }
    void FixedUpdate()
    {
        
        
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
        if (Input.GetKey(KeyCode.W) && rb.linearVelocity.magnitude < maxSpeed)
        {
            //transform.position += transform.forward * velocity * Time.deltaTime;
            velocity = Mathf.Lerp(velocity, maxSpeed, acceleration * Time.deltaTime);
            rb.AddForce(transform.forward * velocity * Time.deltaTime, ForceMode.Acceleration);
            velocity = 3000f;
            acceleration = 10f;
            currentRotation = transform.rotation;
            foreach (var wheel in wheelsColliders)
            {
                wheel.transform.position = wheel.transform.position;
            }
        }
        else
        {
            velocity = Mathf.Lerp(velocity, minSpeed, deceleration * Time.deltaTime);
            velocity = Mathf.Max(velocity, minSpeed);
            
        }
        if (Input.GetKey(KeyCode.S) && rb.linearVelocity.magnitude < maxSpeed / 2)
        {
            //transform.position -= transform.forward * velocity * Time.deltaTime;
            rb.AddForce(-transform.forward * (velocity / 2) * Time.deltaTime, ForceMode.Acceleration);
            foreach (var wheel in wheelsColliders)
            {
                wheel.transform.position = wheel.transform.position;
            }
            currentRotation = transform.rotation;
            velocity = 1500f;

        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, Vector3.zero, deceleration * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            
            transform.Rotate(Vector3.down * rotation * Time.deltaTime);

            foreach (var wheel in wheelsColliders)
            {
                wheel.transform.position = wheel.transform.position;
            }
            wheelMeshes[0].transform.Rotate(Vector3.down * rotation * Time.deltaTime);
            wheelMeshes[1].transform.Rotate(Vector3.down * rotation * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            
            transform.Rotate(Vector3.up * rotation * Time.deltaTime);

            foreach (var wheel in wheelsColliders)
            {
                wheel.transform.position = wheel.transform.position;
            }
            wheelMeshes[0].transform.Rotate(Vector3.up * rotation * Time.deltaTime);
            wheelMeshes[1].transform.Rotate(Vector3.up * rotation * Time.deltaTime);
        }
        if(!Input.GetKey(KeyCode.A)&& !Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, currentRotation, Time.deltaTime * 2f);
        }
        /*if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * rotation * Time.deltaTime);
            foreach (var wheel in wheelsColliders)
            {
                wheel.transform.position = wheel.transform.position;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.down * rotation * Time.deltaTime);
            foreach (var wheel in wheelsColliders)
            {
                wheel.transform.position = wheel.transform.position;
            }
        }*/

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rotation = 60f;
            velocity -= deceleration * Time.deltaTime;
            
            acceleration = 0f;
        }
        else
        {
            rotation = 40f; 
            acceleration = 10f;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * forceJump, ForceMode.Impulse);
        }
    }
}
