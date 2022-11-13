using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_Behavior : MonoBehaviour
{
    public Vector2 dir=new Vector2(0f,0f);
    private Rigidbody2D r;
    private SpriteRenderer s;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        s = GetComponent<SpriteRenderer>();
        r = GetComponent<Rigidbody2D>();
        s.color =new Color(s.color.r,s.color.g,s.color.b,0.25f);
    }

    public void IncreaseAlpha()
    {
        s.color =new Color(s.color.r,s.color.g,s.color.b,s.color.a+0.005f);

    }
    // Update is called once per frame
    void Update()
    {
        IncreaseAlpha();
    }

    private void FixedUpdate()
    {
        r.velocity = (100f*speed * Time.deltaTime * dir);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gun"))
        {
            
            Destroy(gameObject);
        }
    }
    
    
}
