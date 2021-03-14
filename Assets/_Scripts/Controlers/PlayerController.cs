using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{
  
    Animator animator;

    private GameManager gm;

    public GameObject shoot;
    public Transform gun;
    public float shootDelay = 1.0f;
    public float _lastShoot = 0.0f;

    public AudioClip shootSFX;

    private void Start()
    {
        animator = GetComponent<Animator>();
        gm = GameManager.GetInstance();
    }

    public void Shoot()
    {
        if (Time.time - _lastShoot > shootDelay) {
            AudioManager.PlaySFX(shootSFX);
            _lastShoot = Time.time;
            Instantiate(shoot, gun.position, Quaternion.identity);
        }
    }

    public void TakeDamage()
    {
        gm.playerLifes--;
        if (gm.playerLifes <= 0) {
            Die();
        }
    }

    public void Die()
    {
        gm.ChangeState(GameManager.GameState.ENDGAME);
        SceneManager.LoadScene("GameoverScene", LoadSceneMode.Single);
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
        if (!collider.CompareTag("Shoot")) {
            Destroy(collider.gameObject);
            gm.score++;
            TakeDamage();
        }
    }

}
