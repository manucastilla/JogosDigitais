using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SteerableBehaviour, IDamageable, IShooter
{

    public GameObject tiro;
    GameManager gm;

    private Vector3 screenBounds;

    private void Start()
    {
        gm = GameManager.GetInstance();
    }
    public void Shoot()
    {
        if (GameObject.FindWithTag("Player"))
        {
            Instantiate(tiro, transform.position, Quaternion.identity);
            //throw new System.NotImplementedException();
        }
    }
    public int lifes = 2;
    public void TakeDamage()
    {
        gm.pontos += 10;
        lifes--;
        print(lifes);
        if (lifes <= 0) Die();
    }

    public void Die()
    {
        gm.pontos += 30;
        Destroy(gameObject);
    }

    // float angle = 0;

    public void OnBecameInvisible()
    {
        Die();

    }

    private void FixedUpdate()
    {
        if (GameObject.FindWithTag("Player"))
        {


            if (transform.position.x < (screenBounds.x - 15))
            {
                Destroy(gameObject);
            }

        }
        else
        {
            Die();
        }
    }


}
