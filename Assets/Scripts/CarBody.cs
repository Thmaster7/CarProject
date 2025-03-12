using UnityEngine;
using System.Collections.Generic;

public class CarBody : MonoBehaviour
{
    public Rigidbody rb;
    public List<WheelCollider> wheelsColliders;
    public int wheelsOnGround;
    public List<Wheel> wheelMeshes;
    public float velocity = 3000f;
    private float rotation = 50f;
    public float acceleration;
    private float deceleration = 10f;
    private float maxSpeed = 20f;
    private float minSpeed = 0.1f;
   

    

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
    void Update()
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
            rb.AddForce(transform.forward * velocity * Time.deltaTime, ForceMode.Acceleration);

            velocity = 3000f;
            acceleration = 10f;
            //transform.position += transform.forward * velocity * Time.deltaTime;

            velocity = Mathf.Lerp(velocity, maxSpeed, acceleration * Time.deltaTime);

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
        if (Input.GetKey(KeyCode.S) && rb.linearVelocity.magnitude < maxSpeed / 2)
        {
            //transform.position -= transform.forward * velocity * Time.deltaTime;
            rb.AddForce(-transform.forward * (velocity / 2) * Time.deltaTime, ForceMode.Acceleration);
            foreach (var wheel in wheelsColliders)
            {
                wheel.transform.position = wheel.transform.position;
            }
            
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
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rotation = 100f;
            velocity -= deceleration * Time.deltaTime;
            velocity = Mathf.Max(velocity, minSpeed);
            acceleration = 0f;
        }
        else
        {
            rotation = 50f;
        }*/
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * forceJump, ForceMode.Impulse);
        }
    }
}
