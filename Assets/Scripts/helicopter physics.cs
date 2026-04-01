 using UnityEngine;

public class helicopterphysics : MonoBehaviour
{
    public Vector2 velocity;
    public Vector2 acceleration;
    public float pwr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        acceleration.x = 0;
        acceleration.y = -0.98f;
        velocity.x += acceleration.x * Time.deltaTime;
        velocity.y += acceleration.y * Time.deltaTime;
        Vector3 pos = transform.position;
        pos.x += velocity.x * Time.deltaTime;
        pos.y += velocity.y * Time.deltaTime;
        transform.position = pos;
    }
}
