using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : SteerableBehaviour, IDamageable
{

    private GameManager gm;
    private void Start()
    {
        gm = GameManager.GetInstance();
    }

    public void TakeDamage() {
        Die();
    }

    public void Die() {
        gm.score++;
        Destroy(gameObject);
    }

    private void FixedUpdate() {
    }
}
