using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class helicopterphysics : MonoBehaviour
{
    public Vector2 movement;
    public Vector2 cursor;
    public Vector2 velocity;
    public Vector2 acceleration;
    public float pwr;
    public float aoa;

    public SpriteRenderer spriteRenderer;
    public Camera camera;
    public GameObject ocean;
    public GameObject hill0;
    public GameObject hill1;
    public GameObject hill2;
    public GameObject HUDCursorRKT;
    public GameObject HUDCursorMSL;
    public missile[] missiles;
    public boat[] boats;
    public bool hit;

    public UnityEvent OnClick;
    public int gameState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Vector3.zero;
        mousePos.x = cursor.x;
        mousePos.y = cursor.y;
        mousePos.z = 0;
        Vector3 direction = Vector3.zero;
        aoa = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        direction.z = aoa;
        if (mousePos.x >= 0)
        {
            transform.eulerAngles = direction;
            spriteRenderer.flipY = false;
        }
        else
        {
            transform.eulerAngles = direction;
            spriteRenderer.flipY = true;
        }

        if (movement.y > 0)
        {
            pwr += 0.5f * Time.deltaTime;
            if (pwr > 1) 
            {
                pwr = 1;
            }
        }
        if (movement.y < 0)
        {
            pwr -= 0.5f * Time.deltaTime;
            if (pwr < 0)
            {
                pwr = 0;
            }
        }


        if (mousePos.x >= 0 && !hit)
        {
            acceleration.x = -Mathf.Cos((aoa - 90) * Mathf.Deg2Rad) * pwr;
            acceleration.y = -Mathf.Sin((aoa - 90) * Mathf.Deg2Rad) * pwr - 0.5f;
        }
        else if (!hit)
        {
            acceleration.x = -Mathf.Cos((aoa + 90) * Mathf.Deg2Rad) * pwr;
            acceleration.y = -Mathf.Sin((aoa + 90) * Mathf.Deg2Rad) * pwr - 0.5f;
        }
        else
        {
            acceleration.x = 0;
            acceleration.y = -0.5f;
        }

        velocity.x += acceleration.x * Time.deltaTime;
        velocity.y += acceleration.y * Time.deltaTime;
        if (velocity.x * acceleration.x < 0)
        {
            velocity.x += acceleration.x * Time.deltaTime;
        }
        if (velocity.y * acceleration.x < 0)
        {
            velocity.y += acceleration.x * Time.deltaTime;
        }
        if (velocity.x > 5)
        {
            velocity.x = 5;
        }
        if (velocity.x < -5)
        {
            velocity.x = -5;
        }
        if (velocity.y > 1)
        {
            velocity.y = 1;
        }
        if (velocity.y < -1)
        {
            velocity.y = -1;
        }



        Vector3 pos = transform.position;
        pos.x += velocity.x * Time.deltaTime;
        pos.y += velocity.y * Time.deltaTime;

        if (transform.position.y >= 0)
        {
            transform.position = pos;
        }
        else 
        {
            if (gameState == 0) 
            {
                gameState = 2;
            }
            pos = transform.position;
            pos.y -= 0.4f * Time.deltaTime;
            if (transform.position.y > -5.06f)
            {
                transform.position = pos;
            }
            else
            {
                pos.y = -5.06f;
                transform.position = pos;
            }
        }
        if (!boats[0].gameObject.activeInHierarchy && 
            !boats[1].gameObject.activeInHierarchy && 
            !boats[2].gameObject.activeInHierarchy && 
            !boats[3].gameObject.activeInHierarchy && 
            !boats[4].gameObject.activeInHierarchy)
        {
            gameState = 1;
        }
        pos.z = -10;
        camera.transform.position = pos;
        pos.z = 0;
        pos.y = -5;
        ocean.transform.position = pos;
        pos.y = 0.69f;
        pos.x = pos.x - pos.x % 19.96f;
        hill0.transform.position = pos;
        pos.x -= 19.96f;
        hill1.transform.position = pos;
        pos.x += 39.92f;
        hill2.transform.position = pos;
        HUDCursorRKT.transform.position = mousePos + transform.position;
        HUDCursorMSL.transform.position = mousePos + transform.position;

    }

    public void enginePower(InputAction.CallbackContext context) 
    {
        movement = context.ReadValue<Vector2>();
    }

    public void angleOfAttack(InputAction.CallbackContext context)
    {
        cursor = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>()) - transform.position;
    }

    public void click(InputAction.CallbackContext context)
    {
        if (context.performed == true) 
        {
            OnClick.Invoke();
        }
    }
}
