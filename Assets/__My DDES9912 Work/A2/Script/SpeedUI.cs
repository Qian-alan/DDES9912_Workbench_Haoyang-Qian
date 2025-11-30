using TMPro;
using UnityEngine;

public class SpeedUI : MonoBehaviour
{
    public TMP_Text text;
    public Rigidbody wheel;

    void Update()
    {
        float rpm = wheel.angularVelocity.magnitude * 60f / (2 * Mathf.PI);
        int rpmInt = Mathf.FloorToInt(rpm);

        text.text = rpmInt.ToString();
    }
}
