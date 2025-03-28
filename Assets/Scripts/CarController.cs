using UnityEngine;
using System.Collections.Generic;

public class CarController : MonoBehaviour
{
    public List<Wheel> wheelMeshes;
    public List<WheelCollider> wheelsColliders;

    public CarController Auto;
    public Rigidbody rb;

    public int wheelsOnGround;
    public bool canMove;

    public float velocity = 3000f;
    private float rotation = 40f;
    public float acceleration;
    private float deceleration = 10f;
    private float forceJump = 2500f;

    public float maxSpeed = 30f;
    private float minSpeed = 0.1f;

    private float maxRotation = 20f;
    private float wheelRotation;

    private Quaternion currentWheelRotation;
    private Quaternion currentRotation;

    private Vector3 initialPos;
    private Quaternion initialRot;

    

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
        if (wheelsOnGround > 0)
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
            velocity = 3000f;
            acceleration = 10f;
            velocity = Mathf.Lerp(velocity, maxSpeed, acceleration * Time.deltaTime);
            rb.AddForce(transform.forward * velocity * Time.deltaTime, ForceMode.Acceleration);
            foreach (var wheel in wheelMeshes)
            {
                wheel.transform.Rotate(Vector3.right * 500f);
                currentWheelRotation = wheel.transform.rotation;
            }
            foreach (var wheel in wheelsColliders)
            {
                wheel.transform.position = wheel.transform.position;
            }
            currentRotation = transform.rotation;
        }
        else
        {
            velocity = Mathf.Lerp(velocity, minSpeed, deceleration * Time.deltaTime);
            velocity = Mathf.Max(velocity, minSpeed);
        }
        if (Input.GetKey(KeyCode.S) && rb.linearVelocity.magnitude < maxSpeed / 2)
        {
            //transform.position -= transform.forward * velocity * Time.deltaTime;
            velocity = 1500f;
            rb.AddForce(-transform.forward * (velocity / 2) * Time.deltaTime, ForceMode.Acceleration);
            foreach (var wheel in wheelMeshes)
            {
                wheel.transform.Rotate(Vector3.left * 500f);
            }
            foreach (var wheel in wheelsColliders)
            {
                wheel.transform.position = wheel.transform.position;
            }
            currentRotation = transform.rotation;
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * (velocity / 2) * Time.deltaTime, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.down * rotation * Time.deltaTime);
            wheelRotation = Mathf.Min(transform.rotation.y, -maxRotation);
            rb.AddForce(-transform.forward * (velocity / 4) * Time.deltaTime, ForceMode.Acceleration);
            foreach (var wheel in wheelMeshes)
            {
                wheel.transform.Rotate(Vector3.right * 500f);
            }
            foreach (var wheel in wheelsColliders)
            {
                wheel.transform.position = wheel.transform.position;
            }
            wheelMeshes[0].transform.localRotation = Quaternion.Euler(transform.rotation.x * 150000f, wheelRotation, 0);
            wheelMeshes[1].transform.localRotation = Quaternion.Euler(transform.rotation.x * 150000f, wheelRotation, 0);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.up * rotation * Time.deltaTime);
            wheelRotation = Mathf.Max(transform.rotation.y, maxRotation);
            rb.AddForce(-transform.forward * (velocity / 4) * Time.deltaTime, ForceMode.Acceleration);
            foreach (var wheel in wheelMeshes)
            {
                wheel.transform.Rotate(Vector3.right * 500f);
            }
            foreach (var wheel in wheelsColliders)
            {
                wheel.transform.position = wheel.transform.position;
            }
            wheelMeshes[0].transform.localRotation = Quaternion.Euler(transform.rotation.x * 150000f, wheelRotation, 0);
            wheelMeshes[1].transform.localRotation = Quaternion.Euler(transform.rotation.x * 150000f, wheelRotation, 0);
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.up * rotation * Time.deltaTime);
            wheelRotation = Mathf.Min(transform.rotation.y, -maxRotation);
            foreach (var wheel in wheelMeshes)
            {
                wheel.transform.Rotate(Vector3.left * 500f);
            }
            foreach (var wheel in wheelsColliders)
            {
                wheel.transform.position = wheel.transform.position;
            }
            wheelMeshes[0].transform.localRotation = Quaternion.Euler(transform.rotation.x * -150000f, wheelRotation, 0);
            wheelMeshes[1].transform.localRotation = Quaternion.Euler(transform.rotation.x * -150000f, wheelRotation, 0);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.down * rotation * Time.deltaTime);
            wheelRotation = Mathf.Max(transform.rotation.y, maxRotation);
            foreach (var wheel in wheelMeshes)
            {
                wheel.transform.Rotate(Vector3.left * 500f);
            }
            foreach (var wheel in wheelsColliders)
            {
                wheel.transform.position = wheel.transform.position;
            }
            wheelMeshes[0].transform.localRotation = Quaternion.Euler(transform.rotation.x * -150000f, wheelRotation, 0);
            wheelMeshes[1].transform.localRotation = Quaternion.Euler(transform.rotation.x * -150000f, wheelRotation, 0);
        }
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            /*transform.rotation = Quaternion.Lerp(transform.rotation, currentRotation, Time.deltaTime);
            wheelMeshes[0].transform.rotation =  Quaternion.Lerp(transform.rotation, currentWheelRotation, Time.deltaTime);
            wheelMeshes[1].transform.rotation =  Quaternion.Lerp(transform.rotation, currentWheelRotation, Time.deltaTime);*/
            wheelMeshes[0].transform.localRotation = Quaternion.Lerp(wheelMeshes[0].transform.localRotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 5f); // Controla la velocidad de regreso
            wheelMeshes[1].transform.localRotation = Quaternion.Lerp(wheelMeshes[1].transform.localRotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 5f);
        }
        if (Input.GetKey(KeyCode.Space))
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
        
        

    }
}
