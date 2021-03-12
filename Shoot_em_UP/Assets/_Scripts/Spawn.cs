using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// https://www.youtube.com/watch?v=E7gmylDS1C4

public class Spawn : MonoBehaviour
{
    public GameObject enemy;
   public float time = 5f;

    private Vector3 screenBounds;

    void Start(){
        if(GameObject.FindWithTag("Player")){
            screenBounds = GameObject.FindWithTag("Player").transform.position;
            StartCoroutine(enemyWave());
        }
        
    }

    void Update(){
        if(GameObject.FindWithTag("Player")){
            screenBounds = GameObject.FindWithTag("Player").transform.position;
        }
        
    }

    private void spawnEnemy(){
        GameObject x = Instantiate(enemy as GameObject);

        x.transform.position = new Vector2(screenBounds.x + 15, Random.Range(5, -5));

    }

    IEnumerator enemyWave(){
        while(true){
            yield return new WaitForSeconds(time);
            spawnEnemy();
        }
    }

}