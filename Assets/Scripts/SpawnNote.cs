using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNote : MonoBehaviour
{
    [SerializeField] private GameObject notePrefab;

    private void Start()
    {
        InvokeRepeating("Spawn", 1, 1);
    }

    private void Spawn()
    {
        Instantiate(notePrefab, transform.position, Quaternion.identity);
    }
}
