using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake() {
        instance = this;
    }
    private void Start()
    {
        enemyHp = enemyMaxHp;
        playerHp = playerMaxHp;
    }

    public GameObject[] enemy;
    public GameObject[] player;

    public float enemyHp;
    public float enemyMaxHp = 100;
    public float playerHp;
    public float playerMaxHp = 100;
}
