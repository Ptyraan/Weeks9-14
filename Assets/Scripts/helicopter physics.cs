using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using TMPro;

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

    public TMP_Text height;
    public TMP_Text width;
    public TMP_Text power;
    public TMP_Text[] enemies;
    public GameObject w;
    public GameObject l;
    public GameObject d;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // find angle of attack
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

        // find acceleration
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

        // apply acceleration
        velocity.x += acceleration.x * Time.deltaTime;
        velocity.y += acceleration.y * Time.deltaTime;

        // double acceleration if changing direction
        if (velocity.x * acceleration.x < 0)
        {
            velocity.x += acceleration.x * Time.deltaTime;
        }
        if (velocity.y * acceleration.x < 0)
        {
            velocity.y += acceleration.x * Time.deltaTime;
        }
        // max speed
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


        // apply velocity
        Vector3 pos = transform.position;
        pos.x += velocity.x * Time.deltaTime;
        pos.y += velocity.y * Time.deltaTime;

        // crash into water
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

        // check for win
        if (!boats[0].gameObject.activeInHierarchy &&
            !boats[1].gameObject.activeInHierarchy &&
            !boats[2].gameObject.activeInHierarchy &&
            !boats[3].gameObject.activeInHierarchy &&
            !boats[4].gameObject.activeInHierarchy)
        {
            gameState = 1;
        }

        // check for getting hit
        if (Vector2.Distance(missiles[0].transform.position, transform.position) < 0.3f ||
            Vector2.Distance(missiles[1].transform.position, transform.position) < 0.3f ||
            Vector2.Distance(missiles[2].transform.position, transform.position) < 0.3f ||
            Vector2.Distance(missiles[3].transform.position, transform.position) < 0.3f ||
            Vector2.Distance(missiles[4].transform.position, transform.position) < 0.3f)
        {
            hit = true;
        }

        // ocean and hills move
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

        // rocket crosshair and unused missile crosshair
        HUDCursorRKT.transform.position = mousePos + transform.position;
        HUDCursorMSL.transform.position = mousePos + transform.position;

        // HUD
        height.text = $"ALT {Mathf.Floor(transform.position.y * 100)}";
        if (transform.position.x < 0)
        {
            width.text = $"{Mathf.Floor(-transform.position.x * 100)} W";
        }
        else
        {
            width.text = $"{Mathf.Floor(transform.position.x * 100)} E";
        }
        power.text = $"{Mathf.Floor(pwr * 100)}% PWR";
        for (int i = 0; i < 5; i++)
        {
            if (boats[i].gameObject.activeInHierarchy)
            {
                enemies[i].gameObject.SetActive(true);
            }
            else
            {
                enemies[i].gameObject.SetActive(false);
            }
        }
        pos.x = transform.position.x;
        pos.y = transform.position.y - 2.28f;
        w.transform.position = pos;
        l.transform.position = pos;
        pos.y = transform.position.y + 2.2f;
        d.transform.position = pos;

        if (gameState == 0)
        {
            w.SetActive(false);
            l.SetActive(false);
        }
        else if (gameState == 1)
        {
            w.SetActive(true);
            l.SetActive(false);
        }
        else
        {
            w.SetActive(false);
            l.SetActive(true);
        }
        if (hit)
        {
            d.SetActive(true);
        }
        else 
        { 
            d.SetActive(false);
        }
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
