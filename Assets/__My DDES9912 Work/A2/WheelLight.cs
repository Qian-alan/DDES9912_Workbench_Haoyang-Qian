using UnityEngine;

public class WheelLight : MonoBehaviour
{
    public Rigidbody wheelRb;              // 水车的 Rigidbody
    public Light statusLight;              // 控制的灯泡

    public float greenRpm = 1f;           // 超过多少RPM变绿色
    public float maxRpm = 60f;            // 最高亮度对应的最大RPM

    void Update()
    {
        if (wheelRb == null || statusLight == null) return;

        // 1. 计算RPM（真实物理）
        float angVel = wheelRb.angularVelocity.magnitude;
        float rpm = angVel * 60f / (2f * Mathf.PI);

        // 2. 根据转速计算比例 0~1
        float t = Mathf.Clamp01(rpm / maxRpm);

        // 3. 颜色判断：
        if (rpm < greenRpm)
        {
            // 还很慢：红色 → 绿色的过渡
            statusLight.color = Color.Lerp(Color.red, Color.green, rpm / greenRpm);
        }
        else
        {
            // 达到绿色后保持绿色
            statusLight.color = Color.green;
        }

        // 4. 亮度：越快越亮（范围从 0.5 到 5，可以调）
        statusLight.intensity = Mathf.Lerp(0.5f, 5f, t);
    }
}
