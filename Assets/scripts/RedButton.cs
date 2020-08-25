using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Color white = new Color(1, 1, 1, 1);
    Color transparent = new Color(0, 0, 0, 0);
    AudioSource audioSource;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponentInParent<AudioSource>();
    }
    void Update()
    {
        RedOnClick();
    }

    public void RedOnClick()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Vector3 myTouch = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                if (GetComponent<Collider2D>().OverlapPoint(myTouch))
                {
                    if (spriteRenderer.color == transparent) // Turn On
                    {
                        spriteRenderer.color = white;
                        audioSource.volume = 1;
                    }
                    else if (spriteRenderer.color == white) // Turn Off
                    {
                        spriteRenderer.color = transparent;
                        audioSource.volume = 0;
                    }
                }
            }

            
        }
    }
}
