using UnityEngine;
using UnityEngine.Events;

public class rocket : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move forward
        Vector3 v = Vector3.zero;
        v.x = Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad);
        v.y = Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad);
        transform.position += v * Time.deltaTime * 8;

    }
}
