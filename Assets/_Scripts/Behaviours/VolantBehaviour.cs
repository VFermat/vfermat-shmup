using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolantBehaviour : SteerableBehaviour, IShooter, IDamageable
{

    public GameObject tiro;

    private GameManager gm;

    private void Start()
    {
        gm = GameManager.GetInstance();
    }

    public void Shoot() {
        Instantiate(tiro, transform.position, Quaternion.identity);
    }

    public void TakeDamage() {
        Die();
    }

    public void Die() {
        gm.score += 5;
        Destroy(gameObject);
    }

    float angle = 0;

    private void FixedUpdate() {
        angle += 0.1f;
        if (angle > 2.0f * Mathf.PI) angle = 0.0f;
        Thrust(0, Mathf.Cos(angle));
    }
}

