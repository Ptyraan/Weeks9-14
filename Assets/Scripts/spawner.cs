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
            spawnedPaint = Instantiate(prefab, transform.position, transform.rotation);
            count += 1;
            paint.Add(spawnedPaint);
        }
        else {
            /*physics.gameState = 0;
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
            pos.x = 1.08f;
            pos.y = -0.08811905f;
            physics.boats[0].m.transform.position = pos;
            physics.boats[1].m.on = 0;
            physics.boats[1].m.gameObject.SetActive(true);
            physics.boats[0].m.transform.position = pos;
            physics.boats[2].m.on = 0;
            physics.boats[2].m.gameObject.SetActive(true);
            physics.boats[0].m.transform.position = pos;
            physics.boats[3].m.on = 0;
            physics.boats[3].m.gameObject.SetActive(true);
            pos.x = -1.08f;
            physics.boats[0].m.transform.position = pos;
            physics.boats[4].m.on = 0;
            physics.boats[4].m.gameObject.SetActive(true);
            physics.boats[0].m.transform.position = pos;
            */

        }
    }
}
