using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerBehaviour : SteerableBehaviour, IShooter, IDamageable
{

    public GameObject tiro;
    public Transform gun;

    private float shootDelay = 1f;
    private float _lastShootTimestamp = 0.0f;
    private GameManager gm;
    private void Start()
    {
        gm = GameManager.GetInstance();
    }

    public void Shoot() {
        if (Time.time - _lastShootTimestamp > shootDelay) {
            _lastShootTimestamp = Time.time;
            Instantiate(tiro, gun.position, Quaternion.identity);
        }
    }

    public void TakeDamage() {
        Die();
    }

    public void Die() {
        gm.score += 3;
        Destroy(gameObject);
    }

    private void FixedUpdate() {
    }
}
