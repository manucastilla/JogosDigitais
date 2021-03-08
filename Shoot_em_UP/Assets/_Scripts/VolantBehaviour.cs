using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolantBehaviour : SteerableBehaviour, IShooter, IDamageable
{
    float angle = 0;


    public void Shoot()
    {
        throw new System.NotImplementedException();
    }
    public int lifes = 1;
    public void TakeDamage()
    {

        lifes--;
        print(lifes);
        if (lifes <= 0) Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        angle += 0.1f;
        if (angle > 2.0f * Mathf.PI) angle = 0.0f;
        Thrust(0, Mathf.Cos(angle));
    }

}
