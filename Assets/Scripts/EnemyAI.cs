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
    //public Transform secondTarget;
    private IObjectPool<EnemyAI> enemyPool;
    public float EnemyHealth = 10;
    
    public float ChaseBufferTime;
    public float ChaseBufferWaitTime = 1;

    public void SetPool(IObjectPool<EnemyAI> pool)
    {
        enemyPool = pool;
    }
    void Update()
    {
      
        transform.LookAt(Camera.main.transform);
        ChaseBufferTime += Time.deltaTime;
        if (ChaseBufferTime >= ChaseBufferWaitTime)
        {
            Debug.Log("0");
            ChaseBufferTime = 0f;
            float maindist = Vector3.Distance(mainTarget.position, transform.position);
            float seconddist = Vector3.Distance(PlayerController.Player.transform.position, transform.position);
            if (seconddist < (maindist - 1f))
            {
                Debug.Log("1");
                enemy.SetDestination(PlayerController.Player.transform.position);
                Debug.Log(PlayerController.Player.transform.position);
            }
            else
            {
                Debug.Log("2");
                enemy.SetDestination(mainTarget.position);
                Debug.Log(mainTarget.position);
            }
        }
        

        
    }
    public void OnMouseDown()
    {
        if (PlayerController.Player != null && PlayerController.Player.FightMode)
        {
            EnemyHealth -= 5;
            
            if (EnemyHealth <= 0)
            {
                //EnemyHealth = 10;
                //enemyPool.Release(this);
                Destroy(gameObject);
            }
        }    
        
       
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.CompareTag("Center"))
    //    {
    //        enemyPool.Release(this);

    //    }
    //}

}
