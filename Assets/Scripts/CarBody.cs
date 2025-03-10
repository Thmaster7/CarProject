using UnityEngine;

public class CarBody : MonoBehaviour
{
    public Wheel wheel1, wheel2, wheel3, wheel4;
    public float velocity;
    public float rotation;
    public CarBody Auto;
    public bool onGround;
    public bool canMove;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + velocity * Time.deltaTime);
                wheel1.transform.position = new Vector3(wheel1.transform.position.x, wheel1.transform.position.y, wheel1.transform.position.z);
                wheel2.transform.position = new Vector3(wheel2.transform.position.x, wheel2.transform.position.y, wheel2.transform.position.z);
                wheel3.transform.position = new Vector3(wheel3.transform.position.x, wheel3.transform.position.y, wheel3.transform.position.z);
                wheel4.transform.position = new Vector3(wheel4.transform.position.x, wheel4.transform.position.y, wheel4.transform.position.z);
                transform.position += transform.forward * velocity;
            }
            if (Input.GetKey(KeyCode.S))
            {
                //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - velocity * Time.deltaTime);
                wheel1.transform.position = new Vector3(wheel1.transform.position.x, wheel1.transform.position.y, wheel1.transform.position.z);
                wheel2.transform.position = new Vector3(wheel2.transform.position.x, wheel2.transform.position.y, wheel2.transform.position.z);
                wheel3.transform.position = new Vector3(wheel3.transform.position.x, wheel3.transform.position.y, wheel3.transform.position.z);
                wheel4.transform.position = new Vector3(wheel4.transform.position.x, wheel4.transform.position.y, wheel4.transform.position.z);
                transform.position -= transform.forward * velocity;
            }
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
            {
                //transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y - rotation * Time.deltaTime, transform.rotation.z, transform.rotation.w);
                transform.Rotate(Vector3.down * rotation);
                transform.position = new Vector3(transform.position.x - velocity * Time.deltaTime, transform.position.y, transform.position.z + velocity * Time.deltaTime);
                wheel1.transform.position = new Vector3(wheel1.transform.position.x, wheel1.transform.position.y, wheel1.transform.position.z);
                wheel2.transform.position = new Vector3(wheel2.transform.position.x, wheel2.transform.position.y, wheel2.transform.position.z);
                wheel3.transform.position = new Vector3(wheel3.transform.position.x, wheel3.transform.position.y, wheel3.transform.position.z);
                wheel4.transform.position = new Vector3(wheel4.transform.position.x, wheel4.transform.position.y, wheel4.transform.position.z);
            }
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
            {
                //transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y + rotation * Time.deltaTime, transform.rotation.z, transform.rotation.w);
                transform.Rotate(Vector3.up * rotation);
                transform.position = new Vector3(transform.position.x + velocity * Time.deltaTime, transform.position.y, transform.position.z + velocity * Time.deltaTime);
                wheel1.transform.position = new Vector3(wheel1.transform.position.x, wheel1.transform.position.y, wheel1.transform.position.z);
                wheel2.transform.position = new Vector3(wheel2.transform.position.x, wheel2.transform.position.y, wheel2.transform.position.z);
                wheel3.transform.position = new Vector3(wheel3.transform.position.x, wheel3.transform.position.y, wheel3.transform.position.z);
                wheel4.transform.position = new Vector3(wheel4.transform.position.x, wheel4.transform.position.y, wheel4.transform.position.z);

            }
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
            {
                transform.position = new Vector3(transform.position.x - velocity * Time.deltaTime, transform.position.y, transform.position.z - velocity * Time.deltaTime);
                wheel1.transform.position = new Vector3(wheel1.transform.position.x, wheel1.transform.position.y, wheel1.transform.position.z);
                wheel2.transform.position = new Vector3(wheel2.transform.position.x, wheel2.transform.position.y, wheel2.transform.position.z);
                wheel3.transform.position = new Vector3(wheel3.transform.position.x, wheel3.transform.position.y, wheel3.transform.position.z);
                wheel4.transform.position = new Vector3(wheel4.transform.position.x, wheel4.transform.position.y, wheel4.transform.position.z);
            }
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
            {
                transform.position = new Vector3(transform.position.x + velocity * Time.deltaTime, transform.position.y, transform.position.z - velocity * Time.deltaTime);
                wheel1.transform.position = new Vector3(wheel1.transform.position.x, wheel1.transform.position.y, wheel1.transform.position.z);
                wheel2.transform.position = new Vector3(wheel2.transform.position.x, wheel2.transform.position.y, wheel2.transform.position.z);
                wheel3.transform.position = new Vector3(wheel3.transform.position.x, wheel3.transform.position.y, wheel3.transform.position.z);
                wheel4.transform.position = new Vector3(wheel4.transform.position.x, wheel4.transform.position.y, wheel4.transform.position.z);
            }
        }
        else
        {
            
        }
            
        
        
        
        
    }

    void CanMove()
    {
        if(onGround == true)
        {
            canMove = true;
        }
    }
    void CheckIfIsGround()
    {
        if(wheel1.GetComponent<Collider>().CompareTag("Piso"))
        {
            onGround = true;
        }
    }
    
}
