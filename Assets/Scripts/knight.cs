using UnityEngine;

public class knight : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioClip[] footsteps;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Footstep()
    {
        AudioSource.PlayClipAtPoint(footsteps[Random.Range(0, 9)], transform.position);
    }
}
