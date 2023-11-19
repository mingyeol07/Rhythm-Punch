using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum EnemyState { Idle, JabLeft, JabRight, Ducking, Guard };
    public EnemyState enemyState;
    GameManager gameManager;
    public Sprite[] idle;
    public Sprite[] left;
    public Sprite[] right;
    public Player player;
    int ranNum = 0;

    WaitForSeconds delay02 = new WaitForSeconds(0.2f);
    WaitForSeconds delay05 = new WaitForSeconds(0.5f);
    WaitForSeconds delay07 = new WaitForSeconds(0.7f);
    WaitForSeconds delay1 = new WaitForSeconds(1f);

    Color yellow = new Color(1, 1, 0, 1);
    Color red = new Color(1, 0, 0, 1);

    SpriteRenderer spriteRenderer;
    public SpriteRenderer playerRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeState(EnemyState.Idle);
    }

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    private void ChangeState(EnemyState newState)
    {
        enemyState = newState;
        StartCoroutine(enemyState.ToString());
    }

    IEnumerator RanSKill()
    {
        yield return new WaitForSeconds(2f);
        ranNum = Random.Range(0, 10);
        if (0 <= ranNum && ranNum <= 2)
        {
            ChangeState(EnemyState.JabLeft);
        }
        if (3 <= ranNum && ranNum <= 5)
        {
            ChangeState(EnemyState.JabRight);
        }
        if (6 <= ranNum && ranNum <= 9)
        {
            ChangeState(EnemyState.Guard);
        }
    }

    IEnumerator Idle()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1);
        spriteRenderer.sprite = idle[0];
        Debug.Log("기본");
        StartCoroutine(RanSKill());
        yield return null;
    }
    IEnumerator JabLeft()
    {
        spriteRenderer.sprite = left[0];
        yield return delay07;
        Debug.Log("왼잽!");
        if (player.playerState.ToString() != "DuckingRight")
        {
            StartCoroutine(Hit());
        }
        spriteRenderer.sprite = left[1];
        yield return delay02;
        ChangeState(EnemyState.Idle);
    }
    IEnumerator JabRight()
    {
        spriteRenderer.sprite = right[0];
        yield return delay07;
        Debug.Log("오른잽!");
        if (player.playerState.ToString() != "DuckingLeft")
        {
            StartCoroutine(Hit());
        }
        StartCoroutine(Hit());
        spriteRenderer.sprite = right[1];
        yield return delay02;
        ChangeState(EnemyState.Idle);
    }
    IEnumerator Guard()
    {
        spriteRenderer.color = red;
        Debug.Log("가드");
        yield return delay1;
        ChangeState(EnemyState.Idle);
    }
    IEnumerator Hit()
    {
        gameManager.playerHp--;
        playerRenderer.color = new Color(1, 1, 1, 0.2f);
        yield return new WaitForSeconds(0.1f);
        playerRenderer.color = new Color(1, 1, 1, 1);
        if (player.playerState.ToString() == "Guard")
        {
            gameManager.playerHp++;
        }
    }
}
