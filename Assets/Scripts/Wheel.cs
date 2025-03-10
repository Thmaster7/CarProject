using UnityEngine;

public class Wheel : MonoBehaviour
{
    public CarBody car;
    public float velocity;
    public float rotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x + velocity * Time.time, transform.position.y, transform.position.z);
            car.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
