using UnityEngine;

public class EmissionController : MonoBehaviour
{
    public Rigidbody wheelRb;         
    public Renderer rend;             
    public Color slowColor = Color.red;
    public Color fastColor = Color.green;
    public float maxRpm = 60;       

    Material mat;                    

    void Start()
    {
        mat = rend.material;  
    }

    void Update()
    {
        float rpm = wheelRb.angularVelocity.magnitude * 60f / (2f * Mathf.PI);
        float t = Mathf.Clamp01(rpm / maxRpm);

        // red to green

        Color emissionColor = Color.Lerp(slowColor, fastColor, t);

        // the faster, the brighter
        float intensity = Mathf.Lerp(0.2f, 2.5f, t);

        // set emission color
        mat.SetColor("_EmissionColor", emissionColor * intensity);
    }
}
