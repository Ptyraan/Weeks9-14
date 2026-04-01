using UnityEditor.Rendering;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;

public class knight : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioClip[] footsteps;
    public Grid tilemap;
    public GameObject idle;
    public Camera camera;
    public float shook = 0;
    Vector3 scale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = tilemap.transform.position;


        if (Keyboard.current.wKey.isPressed)
        {
            pos.y -= 0.05f;
            scale.x = 3;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            pos.y += 0.05f;
            scale.x = -3;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            pos.x -= 0.05f;
            scale.x = 3;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            pos.x += 0.05f;
            scale.x = -3;
        }
        if (Keyboard.current.anyKey.isPressed)
        {
            transform.localScale = scale;
            idle.transform.localScale = Vector3.one * 0;
            scale = transform.localScale;
        }
        else
        {
            transform.localScale = Vector3.one * 0;
            idle.transform.localScale = scale;
            scale = idle.transform.localScale;
        }
        tilemap.transform.position = pos;
        Vector3 CameraPos = Vector3.zero;
        CameraPos.z = -10;
        if (shook > 0)
        {
            CameraPos.y = 0.2f;
            camera.transform.position = CameraPos;
        }
        else 
        {
            camera.transform.position = CameraPos;
        }
        shook -= Time.deltaTime;

    }

    public void Footstep()
    {
        if (Keyboard.current.anyKey.isPressed)
        {
            AudioSource.PlayClipAtPoint(footsteps[Random.Range(0, 9)], transform.position);
            shook = 0.2f;
        }
    
    }
}
