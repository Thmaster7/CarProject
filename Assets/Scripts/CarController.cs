using UnityEngine;

public class CarController : MonoBehaviour
{
    private bool rayDidHit;
    public Wheel tireTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rayDidHit)
        {
            //Vector3 springDir = tireTransform.up;

            //Vector3 tireWorldVel = carRigidBody.GetPointVelocity(tireTransform.position);

            //float offset = suspensionRestDist - tireRay.discante;

            //float vel = Vector3.Dot(springDir, tireWorldVel);

            //floar force = (offset * springStrenght) - (vel * springDamper);

            //carRigidBody.AddForceAtPosition(springDir * force, tireTransform.position);
        }
    }
}
