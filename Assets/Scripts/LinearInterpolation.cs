using UnityEngine;

public class LinearInterpolation : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public helicopterphysics helicopter;
    public float t;
    public float v;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t = helicopter.transform.position.x * v;
        while (t > 1) {
            t -= 1;
        }
        transform.position = Vector2.Lerp(start.transform.position, end.transform.position, t);
        
    }
}
