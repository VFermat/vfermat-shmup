using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotFollowerBehaviour : SteerableBehaviour
{

  private Vector3 direction;

  private void OnTriggerEnter2D(Collider2D collision)
  {
      if (collision.CompareTag("Enemy") || collision.CompareTag("EnemyShot")) return;

      IDamageable damageable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
      if (!(damageable is null))
      {
          damageable.TakeDamage();
      }
      Destroy(gameObject);
  }

  void Start()
  {

  }

  void Update()
  {
      Thrust(-1, 0);
  }

  private void OnBecameInvisible()
  {
      gameObject.SetActive(false);
  }

}