using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{

    GameManager gm;
    public AudioClip shootSFX;

    public GameObject bullet;
    public Transform arma01;

    public float shootDelay = 0.25f;

    private float _lattShootTimestamp = 0.0f;
    Animator animator;

    public HealthBar healthBar;

    private void Start()
    {
        animator = GetComponent<Animator>();
        healthBar.SetMaxHealth();
        gm = GameManager.GetInstance();

    }

    void FixedUpdate()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        float yInput = Input.GetAxisRaw("Vertical");
        float xInput = Input.GetAxisRaw("Horizontal");
        Thrust(xInput, yInput);
        if (yInput != 0 || xInput != 0)
        {
            animator.SetFloat("Velocity", 1.0f);
        }
        else
        {
            animator.SetFloat("Velocity", 0.0f);
        }
        if (Input.GetAxisRaw("Fire1") != 0)
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME)
        {
            gm.ChangeState(GameManager.GameState.PAUSE);
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigos"))
        {
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }
    public void Shoot()
    {
        //Instantiate(bullet, transform.position + new Vector3(1.0f, 0.0f, 0.0f), Quaternion.identity);
        if (Time.time - _lattShootTimestamp < shootDelay) return;
        _lattShootTimestamp = Time.time;
        Instantiate(bullet, arma01.position, Quaternion.identity);
        AudioManager.PlaySFX(shootSFX);

    }

    public void TakeDamage()
    {
        gm.health--;
        healthBar.SetHealth(gm.health);
        if (gm.health <= 0) Die();
    }

    public void Die()
    {
        gameObject.SetActive(false);
        if (gm.health <= 0 && gm.gameState == GameManager.GameState.GAME)
        {
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }
        // Destroy(gameObject);

    }

}
