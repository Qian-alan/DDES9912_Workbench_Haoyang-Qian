using UnityEngine;

public class ConveyorForce : MonoBehaviour
{
    public float speed = 3;
    public Vector3 direction = Vector3.forward;
    void OnTriggerStay(Collider other)

    {
        Rigidbody rb = other.attachedRigidbody;
        if (rb != null)
        {
            rb.AddForce(direction.normalized*speed, ForceMode.Acceleration);
          }
}
}