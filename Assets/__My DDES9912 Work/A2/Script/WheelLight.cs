using UnityEngine;

public class WheelLight : MonoBehaviour
{
    public Rigidbody wheelRb;              
    public Light statusLight;              

    public float greenRpm = 1f;           
    public float maxRpm = 60f;           

    void Update()
    {
        if (wheelRb == null || statusLight == null) return;

       
        float angVel = wheelRb.angularVelocity.magnitude;
        float rpm = angVel * 60f / (2f * Mathf.PI);
        float t = Mathf.Clamp01(rpm / maxRpm);

        
        if (rpm < greenRpm)
        {
            
            statusLight.color = Color.Lerp(Color.red, Color.green, rpm / greenRpm);
        }
        else
        {
           
            statusLight.color = Color.green;
        }

        
        statusLight.intensity = Mathf.Lerp(0.5f, 5f, t);
    }
}
