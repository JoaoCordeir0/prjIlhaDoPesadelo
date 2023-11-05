using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]

public class Enemy : MonoBehaviour
{
    private NavMeshAgent navMeshEnemy;
    private GameObject player;
    private float enemySpeed = 6f;

    private GameObject enemyCollider;

    void Start()
    {
        navMeshEnemy = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        enemyCollider = GameObject.FindWithTag("Enemy");
        enemyCollider.SetActive(false);
    }
    void Update()
    {
        navMeshEnemy.destination = player.transform.position;

        if(Vector3.Distance(transform.position, player.transform.position) < 1f)
        {
            navMeshEnemy.speed = 0;
            enemyCollider.SetActive(true);
            StartCoroutine("Attack");
        }
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(2.8f);
        enemyCollider.SetActive(false);
        navMeshEnemy.speed = enemySpeed;
    }
}
