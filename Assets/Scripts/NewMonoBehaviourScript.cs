using System;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] array;
    int index;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        array = new Sprite[10];
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sprite = array[index];
    }

    public void ChangeSprite() {
        if (index < array.Length)
        {
            index++;
        } else
        {
            index = 0;
        }
    }
}
