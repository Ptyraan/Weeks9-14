using UnityEngine;

public class boat : MonoBehaviour
{
    public missile m;
    public spawner rockets;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // check for hit
        for (int i = 0; i < rockets.count; i++) 
        {
            if (Vector2.Distance(rockets.paint[i].transform.position, transform.position) < 0.5) {
                gameObject.SetActive(false);
                if (m.on == 0) { 
                    m.gameObject.SetActive(false);
                }
            }
        }
    }
}
