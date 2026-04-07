using UnityEngine;

public class missile : MonoBehaviour
{
    public helicopterphysics tgt;
    public float heading;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float tgtAngle = Mathf.Atan2(transform.position.y - tgt.transform.position.y, transform.position.x - tgt.transform.position.x);
        if ((tgtAngle - heading) * Mathf.Rad2Deg > Time.deltaTime)
        {
            heading += Time.deltaTime;
        }
        else if ((tgtAngle - heading) * Mathf.Rad2Deg < -Time.deltaTime)
        {
            heading -= Time.deltaTime;
        }
        else
        {
            heading = tgtAngle;
        }
        Vector3 velocity = Vector3.zero;
        velocity.x = Mathf.Cos(heading) * 0.3f * Time.deltaTime;
        velocity.y = Mathf.Sin(heading) * 0.3f * Time.deltaTime;
        transform.position += velocity;
        Vector3 angle = Vector3.zero;
        angle.z = heading;
        transform.eulerAngles = angle; 
    }
}
