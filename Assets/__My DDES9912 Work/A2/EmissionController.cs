using UnityEngine;

public class EmissionController : MonoBehaviour
{
    public Rigidbody wheelRb;          // 水车刚体
    public Renderer rend;              // 球的 Renderer
    public Color slowColor = Color.red;
    public Color fastColor = Color.green;
    public float maxRpm = 100f;        // 最高速度对应的亮度

    Material mat;                      // 材质实例

    void Start()
    {
        mat = rend.material;  // 注意：生成实例，否则会影响整个材质球
    }

    void Update()
    {
        float rpm = wheelRb.angularVelocity.magnitude * 60f / (2f * Mathf.PI);
        float t = Mathf.Clamp01(rpm / maxRpm);

        // 颜色渐变（红→绿）
        Color emissionColor = Color.Lerp(slowColor, fastColor, t);

        // 越快越亮（乘上一个亮度系数）
        float intensity = Mathf.Lerp(0.2f, 2.5f, t);

        // 设置 emission：必须乘以 intensity
        mat.SetColor("_EmissionColor", emissionColor * intensity);
    }
}
