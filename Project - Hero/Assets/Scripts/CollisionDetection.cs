using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    // Planes Health
    private int health = 4;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Identify the object that's colliding
        if(collision.gameObject.tag.Equals("Projectile"))
        {
            if(health > 0)
            {
                // Change the alpha component to be 80% of the previous
                SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
                Color color = renderer.color;
                renderer.color = new Color(color.r, color.g, color.b, color.a * .8f);
                health--;       // subtract 1 to HP
            }
            // This means the plane is out of health and should be destroyed
            if(health == 0)
            {
                Destroy(gameObject);
                EventManager.current.StartEnemiesDestroyedEvent();
            }
            Destroy(collision.gameObject);
            EventManager.current.StartDecreaseEggCounterEvent();
        }

        // This means the player touched a plane
        if(collision.gameObject.tag.Equals("Player"))
        {
            // Destroy the plane and raise both events
            Destroy(gameObject);
            EventManager.current.StartEnemiesDestroyedEvent();
            EventManager.current.StartEnemiesTouchEvent();
        }
    }
}
