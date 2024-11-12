using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints;
    public List<Transform> SpawnPoints => spawnPoints;
}
