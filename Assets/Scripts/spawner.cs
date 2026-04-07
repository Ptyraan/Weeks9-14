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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shoot() {

        spawnedPaint = Instantiate(prefab, transform.position, transform.rotation);
        count += 1;
        paint.Add(spawnedPaint);

    }
}
