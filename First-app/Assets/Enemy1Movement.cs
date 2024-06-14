using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movement : MonoBehaviour, IDamageable
{
    public bool isHit;
   
    private SpriteRenderer enemyRenderer;

    public void TakeDamage(Vector2 direction)
    {
        Debug.Log("enemy1");
        StartCoroutine(HandleEnemyState());
        isHit = true;
    }

    IEnumerator HandleEnemyState()
    {    
        int i = 0;
        while (i < 3) {
            enemyRenderer.enabled = false;
            yield return new WaitForSecondsRealtime(0.2f);
            enemyRenderer.enabled = true;
            yield return new WaitForSecondsRealtime(0.2f);
            Debug.Log(i);
            i ++;
        }

        Destroy(gameObject);   
        Debug.Log("enemy is destroyed");
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}