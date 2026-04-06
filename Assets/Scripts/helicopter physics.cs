using UnityEngine;
using UnityEngine.InputSystem;

public class helicopterphysics : MonoBehaviour
{
    public Vector2 velocity;
    public Vector2 acceleration;
    public float pwr;
    public float aoa;

    public SpriteRenderer spriteRenderer;
    public Camera camera;
    public GameObject ocean;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePos.z = 0;
        Vector3 vector = mousePos - transform.position;
        Vector3 direction = Vector3.zero;
        aoa = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        direction.z = aoa;
        if (mousePos.x - transform.position.x >= 0)
        {
            transform.eulerAngles = direction;
            spriteRenderer.flipY = false;
        }
        else 
        {
            transform.eulerAngles = direction;
            spriteRenderer.flipY = true;
        }

        if (Keyboard.current.wKey.isPressed && !Keyboard.current.sKey.isPressed && pwr < 1) 
        {
            pwr += 0.5f * Time.deltaTime;
        }
        if (Keyboard.current.sKey.isPressed && !Keyboard.current.wKey.isPressed && pwr > 0)
        {
            pwr -= 0.5f * Time.deltaTime;
        }

        if (mousePos.x - transform.position.x >= 0)
        {
            acceleration.x = -Mathf.Cos((aoa - 90) * Mathf.Deg2Rad) * pwr * 0.5f;
            acceleration.y = -Mathf.Sin((aoa - 90) * Mathf.Deg2Rad) * pwr * 0.5f - 0.3f;
        }
        else
        {
            acceleration.x = -Mathf.Cos((aoa + 90) * Mathf.Deg2Rad) * pwr * 0.5f;
            acceleration.y = -Mathf.Sin((aoa + 90) * Mathf.Deg2Rad) * pwr * 0.5f - 0.3f;
        }
        
        velocity.x += acceleration.x * Time.deltaTime;
        velocity.y += acceleration.y * Time.deltaTime;
        Vector3 pos = transform.position;
        pos.x += velocity.x * Time.deltaTime;
        pos.y += velocity.y * Time.deltaTime;
        transform.position = pos;
        pos.z = -10;
        camera.transform.position = pos;
        pos.z = 0;
        pos.y = -5;
        ocean.transform.position = pos;

    }
}
