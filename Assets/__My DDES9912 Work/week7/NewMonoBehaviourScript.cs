using UnityEngine;
using UnityEngine.AI;

public class GhostWalk : MonoBehaviour
{
    [Header("Navigation Settings")]
    public Transform target;
    public NavMeshAgent myagent;
    public SinYBob characterBouncer;
    public SinYBob [] hairBouncers;

    [Header("Animation Settings")]
    public float charaterBouncerSpeed= 730f;
    void Start()
    {
        myagent = GetComponent<NavMeshAgent>();
        characterBouncer=GetComponent<SinYBob>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
