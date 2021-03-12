using UnityEngine;

public class StatePatrulha : State
{
    SteerableBehaviour steerable;

    public override void Awake()
    {
        base.Awake();

        if (GameObject.FindWithTag("Player"))
        {

            // Criamos e populamos uma nova transição
            Transition ToAtacando = new Transition();
            ToAtacando.condition = new ConditionDistLT(transform,
                GameObject.FindWithTag("Player").transform,
                30.0f);
            ToAtacando.target = GetComponent<StateAtaque>();
            // Adicionamos a transição em nossa lista de transições
            transitions.Add(ToAtacando);
            steerable = GetComponent<SteerableBehaviour>();

        }
    }
    float angle = 0;
    public override void Update()
    {
        if (GameObject.FindWithTag("Player"))
        {
            angle += 0.1f * Time.deltaTime;
            Mathf.Clamp(angle, 0.0f, 2.0f * Mathf.PI);
            float x = Mathf.Sin(angle);
            float y = Mathf.Cos(angle);

            steerable.Thrust(y, y);
        }

    }
}