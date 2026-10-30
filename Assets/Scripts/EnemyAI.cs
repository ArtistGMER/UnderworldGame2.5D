using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Pool;
public class EnemyAI : MonoBehaviour
{

    public NavMeshAgent enemy;
    public Transform mainTarget;
    public Transform secondTarget;
    private IObjectPool<EnemyAI> enemyPool;
    public float EnemyHealth = 10;

    public void SetPool(IObjectPool<EnemyAI> pool)
    {
        enemyPool = pool;
    }
    void Update()
    {
        enemy.SetDestination(mainTarget.position);

        float maindist = Vector3.Distance(mainTarget.transform.position, transform.position);
        float seconddist = Vector3.Distance(secondTarget.transform.position, transform.position);
        if (seconddist < maindist)
        {

            enemy.SetDestination(secondTarget.position);
        }

        
    }
    public void OnMouseDown()
    {
        EnemyHealth -= 5;
        if (EnemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Center"))
        {
            enemyPool.Release(this);
        }
    }

}
