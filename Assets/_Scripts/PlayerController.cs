using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{
  
    Animator animator;

    public GameObject shoot;
    public Transform gun;
    public float shootDelay = 1.0f;
    public float _lastShoot = 0.0f;

    private int lifes;

    private void Start()
    {
        lifes = 10;
        animator = GetComponent<Animator>();
    }

    public void Shoot()
    {
        if (Time.time - _lastShoot > shootDelay) {
            _lastShoot = Time.time;
            Instantiate(shoot, gun.position, Quaternion.identity);
        }
    }

    public void TakeDamage()
    {
        lifes--;
        if (lifes <= 0) {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");
        Thrust(xInput, yInput);
        if (yInput != 0 || xInput != 0)
        {
            animator.SetFloat("Velocity", 1.0f);
        }
        else
        {
            animator.SetFloat("Velocity", 0.0f);
        }
        if (Input.GetAxis("Jump") != 0) {
                Shoot();
        }
    }    

    public void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Enemy")) {
            Destroy(collider.gameObject);
            TakeDamage();
        }
    }

}
