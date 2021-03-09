using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolantBehaviour : SteerableBehaviour, IDamageable
{
    float angle = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TakeDamage()
    {
        Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    void FixedUpdate() {
        angle += 0.1f;
        if (angle > 2.0f * Mathf.PI) angle = 0.0f;
        Thrust(0, Mathf.Cos(angle));
    }

    public void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Shoot")) {
            TakeDamage();
        }
    }
}
