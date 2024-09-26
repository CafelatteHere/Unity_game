using System.Collections;
using UnityEngine;

public class Enemy1Movement : Enemy
{
   
    [SerializeField] SpriteRenderer enemyRenderer;



    protected override void Start()
    {
        base.Start();
        enemyRenderer = GetComponent<SpriteRenderer>();
    }

    public override void TakeDamage(Vector2 direction, float enemyDamageAmount)
    {
        base.TakeDamage(direction,enemyDamageAmount);
        StartCoroutine(HandleEnemyState());
    }

    IEnumerator HandleEnemyState()
    {    
        int i = 0;
        while (i < 3) {
            enemyRenderer.enabled = false;
            yield return new WaitForSecondsRealtime(0.2f);
            enemyRenderer.enabled = true;
            yield return new WaitForSecondsRealtime(0.2f);
            i ++;
        }
 
        Destroy(gameObject);   
    }

}