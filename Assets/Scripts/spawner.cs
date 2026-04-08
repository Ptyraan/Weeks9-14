using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class spawner : MonoBehaviour
{
    public GameObject prefab;
    public GameObject spawnedPaint;
    public List<GameObject> paint;
    public int count = 0;
    public helicopterphysics physics;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void click() {
        if (physics.gameState == 0)
        {
            // shoot rocket
            spawnedPaint = Instantiate(prefab, transform.position, transform.rotation);
            count += 1;
            paint.Add(spawnedPaint);
        }
        else {
            // reset game if over
            physics.gameState = 0;
            Vector3 pos = Vector3.zero;
            pos.y = 2.66f;
            transform.position = pos;
            physics.boats[0].gameObject.SetActive(true);
            physics.boats[1].gameObject.SetActive(true);
            physics.boats[2].gameObject.SetActive(true);
            physics.boats[3].gameObject.SetActive(true);
            physics.boats[4].gameObject.SetActive(true);
            physics.boats[0].m.on = 0;
            physics.boats[0].m.gameObject.SetActive(true);
            physics.boats[0].m.heading = -1.57f;
            physics.boats[0].m.velocity = Vector3.zero;
            pos.x = 7.160428f;
            pos.y = -0.08811905f;
            physics.boats[0].m.transform.position = pos;
            physics.boats[1].m.on = 0;
            physics.boats[1].m.gameObject.SetActive(true);
            physics.boats[1].m.heading = -1.57f;
            physics.boats[1].m.velocity = Vector3.zero;
            pos.x = 19.75543f;
            physics.boats[1].m.transform.position = pos;
            physics.boats[2].m.on = 0;
            physics.boats[2].m.gameObject.SetActive(true);
            physics.boats[2].m.heading = -1.57f;
            physics.boats[2].m.velocity = Vector3.zero;
            pos.x = 39.15543f;
            physics.boats[2].m.transform.position = pos;
            physics.boats[3].m.on = 0;
            physics.boats[3].m.gameObject.SetActive(true);
            physics.boats[3].m.heading = -1.57f;
            physics.boats[3].m.velocity = Vector3.zero;
            pos.x = -18.15543f;
            physics.boats[3].m.transform.position = pos;
            physics.boats[4].m.on = 0;
            physics.boats[4].m.gameObject.SetActive(true);
            physics.boats[4].m.heading = -1.57f;
            physics.boats[4].m.velocity = Vector3.zero;
            pos.x = -33.04239f;
            physics.boats[4].m.transform.position = pos;

            physics.velocity = Vector3.zero;
            physics.hit = false;
        }
    }
}
