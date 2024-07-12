using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movement : EnemyTakeDamage
{
   
    [SerializeField] SpriteRenderer enemyRenderer;

    public void startTakeDamage(Vector2 direction){
        TakeDamage(direction);
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyRenderer = GetComponent<SpriteRenderer>();
    }

    public override void TakeDamage(Vector2 direction)
    {
        Debug.Log("enemy1 is doing its own take damage method");
        StartCoroutine(HandleEnemyState());
        //base.isHit = true;
    }

    IEnumerator HandleEnemyState()
    {    
        int i = 0;
        while (i < 3) {
            enemyRenderer.enabled = false;
            Debug.Log("enemyRenderer " + enemyRenderer);
            yield return new WaitForSecondsRealtime(0.2f);
            enemyRenderer.enabled = true;
                Debug.Log("enemyRenderer 2" + enemyRenderer);
            yield return new WaitForSecondsRealtime(0.2f);
            Debug.Log(i);
            i ++;
        }

        Destroy(gameObject);   
        Debug.Log("enemy is destroyed");
    }




}