using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private int poolCount = 3;
    [SerializeField] private bool autoExpand = false;
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private float periodTime = 5f;

    private PoolOfObjects<Enemy> pool;

    [SerializeField] private Spawn Spawn;

    public event Action CreatedEnemy;
    private void Start()
    {
        this.pool = new PoolOfObjects<Enemy> (this.enemyPrefab, this.poolCount, this.transform);
        this.pool.autoExpand = autoExpand;
    }

    private void OnEnable()
    {
        this.StartCoroutine("CreateRoutine");
    }

    private void OnDisable()
    {
        this.StopCoroutine("CreateRoutine");
    }

    private IEnumerator CreateRoutine()
    {
        yield return new WaitForSeconds(periodTime);

        this.CreatedEnemy();
    }


    private void CreateEnemy()
    {
        for (int i = 0; i < Spawn.SpawnPoints.Count; i++)
        {
            Transform enemyPosition = Spawn.SpawnPoints[i];
            Enemy enemy = this.pool.GetFreeElement();
            enemy.transform.position = new Vector3(enemyPosition.position.x, enemyPosition.position.y, enemyPosition.position.z);
        }

        CreatedEnemy?.Invoke();
    }

}
