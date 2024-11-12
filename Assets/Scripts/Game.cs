using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private EnemyPool enemyPool;
    [SerializeField] private Enemy enemy;

    private void OnEnable()
    {
        enemyPool.CreatedEnemy += StartMove;
    }

    private void OnDisable()
    {
        enemyPool.CreatedEnemy -= StartMove;
    }

    private void StartMove()
    {
        enemy.Move();
    }

}
