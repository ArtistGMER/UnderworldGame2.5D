using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
public class EnemyAI : MonoBehaviour
{

    public NavMeshAgent enemy;
    public Transform player;

    void Update()
    {
        enemy.SetDestination(player.position);
    }
    
}
