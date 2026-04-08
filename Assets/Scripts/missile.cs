using UnityEngine;

public class missile : MonoBehaviour
{
    public helicopterphysics tgt;
    public float heading;
    public Vector3 velocity;
    public float tgtAngle;
    public int on;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // turns only slightly if tracking turns too much
        if (on == 1)
        {
            tgtAngle = Mathf.Atan2(transform.position.y - tgt.transform.position.y, transform.position.x - tgt.transform.position.x);
            if ((tgtAngle - heading) * Mathf.Rad2Deg > Time.deltaTime * 10)
            {
                heading += Time.deltaTime * Mathf.Deg2Rad * 19;
            }
            else if ((tgtAngle - heading) * Mathf.Rad2Deg < -Time.deltaTime * 10)
            {
                heading -= Time.deltaTime * Mathf.Deg2Rad * 10;
            }
            else
            {
                heading = tgtAngle;
            }
            velocity = Vector3.zero;
            velocity.x = -Mathf.Cos(heading) * Time.deltaTime;
            velocity.y = -Mathf.Sin(heading) * Time.deltaTime;
            transform.position += velocity;
        }
        else if (on == 2) 
        {
            Vector3 pos = transform.position;
            pos.y -= Time.deltaTime;
            transform.position = pos;
        } 
        else if (Vector2.Distance(transform.position, tgt.transform.position) < 9)
        {
            on = 1;
        }
        Vector3 angle = Vector3.zero;
        angle.z = heading * Mathf.Rad2Deg + 180;
        transform.eulerAngles = angle;

        if (on == 1 && (transform.position.y < 0 || Vector2.Distance(transform.position, tgt.transform.position) > 10)) 
        {
            on = 2;
        }
    }
}
