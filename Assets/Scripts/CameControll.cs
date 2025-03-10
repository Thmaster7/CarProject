using UnityEngine;

public class CameControll : MonoBehaviour
{
    public CarBody car;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(car.transform.position.x, car.transform.position.y + 0.5f, car.transform.position.z - 5);
        transform.rotation = new Quaternion(car.transform.rotation.x, car.transform.rotation.y, car.transform.rotation.z, car.transform.rotation.w);
    }
}
