using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAttack : State
{
    SteerableBehaviour steerable;
    IShooter shooter;

    public float shootDelay = 1.0f;
    private float _lastShootTimestamp = 0.0f;

    public override void Update() {

        //TODO: Movimentação quando atacando
        Transition ToPatrol = new Transition();
        ToPatrol.condition = new ConditionDistGT(transform,
            GameObject.FindWithTag("Player").transform,
            2.0f);
        ToPatrol.target = GetComponent<StatePatrol>();
        // Adicionamos a transição em nossa lista de transições
        transitions.Add(ToPatrol);

        if (Time.time - _lastShootTimestamp < shootDelay) return;
        _lastShootTimestamp = Time.time;
        shooter.Shoot();
    }

    public override void Awake() {
        base.Awake();
        steerable = GetComponent<SteerableBehaviour>();
        shooter = steerable as IShooter;
        if(shooter == null)
        {
            throw new MissingComponentException("Este GameObject não implementa IShooter");
        }
    }
}