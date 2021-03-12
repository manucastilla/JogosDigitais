using UnityEngine;
public class StateAtaque : State
{
    GameManager gm;
    SteerableBehaviour steerable;
    IShooter shooter;
    public override void Awake()
    {
        gm = GameManager.GetInstance();
        base.Awake();

        if (GameObject.FindWithTag("Player"))
        {
            Transition ToPatrol = new Transition();
            ToPatrol.condition = new ConditionDistGT(transform, GameObject.FindWithTag("Player").transform, 20.0f);
            ToPatrol.target = GetComponent<StatePatrulha>();
            // Adicionamos a transição em nossa lista de transições
            transitions.Add(ToPatrol);

            steerable = GetComponent<SteerableBehaviour>();
            shooter = steerable as IShooter;
            if (shooter == null)
            {
                throw new MissingComponentException("This GameObject doesn't implement IShooter");
            }
        }


    }

    public float shootDelay = 1.0f;
    private float _lastShootTimestamp = 0.0f;
    public override void Update()
    {

        //TODO: Movimentação quando atacando

        if (Time.time - _lastShootTimestamp < shootDelay) return;
        _lastShootTimestamp = Time.time;


        if (gm.gameState != GameManager.GameState.GAME)
        {
            return;
        }

        shooter.Shoot();

    }
}