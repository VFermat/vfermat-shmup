using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePatrol: State
{
    SteerableBehaviour steerable;
    IShooter shooter;
    
    float angle = 0;

    public override void Awake() {
        base.Awake();

        // Criamos e populamos uma nova transição
        Transition ToAttack = new Transition();
        ToAttack.condition = new ConditionDistLT(transform,
            GameObject.FindWithTag("Player").transform,
            2.0f);
        ToAttack.target = GetComponent<StateAttack>();
        // Adicionamos a transição em nossa lista de transições
        transitions.Add(ToAttack);

        steerable = GetComponent<SteerableBehaviour>();
        shooter = steerable as IShooter;
        if(shooter == null)
        {
            throw new MissingComponentException("Este GameObject não implementa IShooter");
        }

        steerable = GetComponent<SteerableBehaviour>();
    }
    public override void Update() {
        angle += 0.1f * Time.deltaTime;
        Mathf.Clamp(angle, 0.0f, 2.0f * Mathf.PI);
        float x = Mathf.Sin(angle);
        float y = Mathf.Cos(angle);

        steerable.Thrust(y, y);
    }
}