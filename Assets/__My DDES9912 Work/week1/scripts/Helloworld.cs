using UnityEngine;

public class Helloworld : MonoBehaviour
{
    public int a;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("HelloWorld" + a);
        a= a+1;
    }
}
