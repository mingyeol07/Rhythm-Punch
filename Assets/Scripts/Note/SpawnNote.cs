using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNote : MonoBehaviour
{
    [SerializeField] private GameObject notePrefab;

    private void Start()
    {
        InvokeRepeating("Spawn", 0f, 0.7f);
    }

    private void Spawn()
    {
        Instantiate(notePrefab, transform);
    }
}
