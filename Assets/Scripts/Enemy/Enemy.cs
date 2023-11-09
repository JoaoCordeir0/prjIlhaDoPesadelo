using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]

public class Enemy : MonoBehaviour
{
    private NavMeshAgent navMeshEnemy;
    private GameObject player;
    private float enemySpeed = 40f;

    private GameObject enemyCollider;

    void Start()
    {
        navMeshEnemy = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        enemyCollider = GameObject.FindWithTag("Enemy");
    }
    void Update()
    {
        navMeshEnemy.destination = player.transform.position;

        if(Vector3.Distance(transform.position, player.transform.position) < 2f)
        {
            navMeshEnemy.speed = 0;
            StartCoroutine("Attack");
        }
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(2.8f);
        navMeshEnemy.speed = enemySpeed;
    }
}
