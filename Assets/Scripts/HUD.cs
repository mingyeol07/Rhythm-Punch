using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType { PlayerHp, EnemyHp }
    public InfoType type;

    GameManager gameManager;
    Slider mySlider;
    
    private void Awake() {
        mySlider = GetComponent<Slider>();
    }

    private void Start() {
        gameManager = GameManager.instance;
    }

    private void Update() {
        switch (type)
        {
            case InfoType.PlayerHp:
                mySlider.value = gameManager.playerHp / gameManager.playerMaxHp;
                break;
            case InfoType.EnemyHp:
                mySlider.value = gameManager.enemyHp / gameManager.enemyMaxHp;
                break;
        }
    }
}
