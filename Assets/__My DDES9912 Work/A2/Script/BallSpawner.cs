using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab; 
    public Transform spawnPoint;  
    public float spawnInterval = 2f; 

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
            timer = 0f;
        }
    }
}
