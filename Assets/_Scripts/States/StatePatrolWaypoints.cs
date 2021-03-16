using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePatrolWaypoints : State {

  public Transform[] waypoints;   
  SteerableBehaviour steerable;
  IShooter shooter;

  public override void Awake() {
      base.Awake();
      // Configure a transição para outro estado aqui.
      steerable = GetComponent<SteerableBehaviour>();
      shooter = steerable as IShooter;
      if(shooter == null)
      {
        throw new MissingComponentException("Este GameObject não implementa IShooter");
      }
  }

  public void Start() {
      waypoints[0].position = transform.position;
      waypoints[1].position = GameObject.FindWithTag("Player").transform.position;
  }

  public override void Update() {
      if((waypoints[1].position.y - transform.position.y) > .1f) {
        Vector3 direction = waypoints[1].position - transform.position;
        direction.Normalize();
        steerable.Thrust(0, direction.y);
      } else {
        shooter.Shoot();
        waypoints[1].position = GameObject.FindWithTag("Player").transform.position;
      }
  }
 
}
