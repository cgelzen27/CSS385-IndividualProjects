using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private int health = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Projectile"))
        {
            if(health > 0)
            {
                SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
                Color color = renderer.color;
                renderer.color = new Color(color.r, color.g, color.b, color.a * .8f);
                health--;
            }
            if(health == 0)
            {
                Destroy(gameObject);
            }
             Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }
}
