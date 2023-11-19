using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum PlayerState { Idle, Jab, DuckingLeft, DuckingRight, Guard };
    public PlayerState playerState;
    public Sprite[] idle;
    public Sprite[] left;
    public Sprite[] right;
    public Sprite[] jab;

    private bool isChanged = false;
    private float doubleClickTimeThreshold = 0.2f;
    private float lastClickTime;

    WaitForSeconds delay01 = new WaitForSeconds(0.1f);
    WaitForSeconds delay02 = new WaitForSeconds(0.2f);
    WaitForSeconds delay05 = new WaitForSeconds(0.5f);
    WaitForSeconds delay1 = new WaitForSeconds(1f);

    SpriteRenderer spriteRenderer;
    public SpriteRenderer enemyRenderer;
    GameManager gameManager;
    public Enemy enemy;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeState(PlayerState.Idle);
    }
    private void Start()
    {
        gameManager = GameManager.instance;
    }

    private void Update()
    {
        InputState();
    }

    private void InputState()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (Time.time - lastClickTime < doubleClickTimeThreshold)
            {
                if (playerState.ToString() == "Idle" && isChanged == true)
                {
                    ChangeState(PlayerState.Jab);
                }
            }
            lastClickTime = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (Time.time - lastClickTime < doubleClickTimeThreshold)
            {
                if (playerState.ToString() == "Idle" && isChanged == true)
                {
                    ChangeState(PlayerState.DuckingLeft);
                }
            }
            lastClickTime = Time.time;
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (Time.time - lastClickTime < doubleClickTimeThreshold)
            {
                if (playerState.ToString() == "Idle" && isChanged == true)
                {
                    ChangeState(PlayerState.DuckingRight);
                }
            }
            lastClickTime = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (Time.time - lastClickTime < doubleClickTimeThreshold)
            {
                if (playerState.ToString() == "Idle" && isChanged == true)
                {
                    ChangeState(PlayerState.Guard);
                }
            }
            lastClickTime = Time.time;
        }
    }

    private void ChangeState(PlayerState newState)
    {
        isChanged = true;
        playerState = newState;
        StartCoroutine(playerState.ToString());
    }

    IEnumerator Idle()
    {
        isChanged = false;
        spriteRenderer.color = new Color(1, 1, 1, 1);
        spriteRenderer.sprite = idle[0];
        Debug.Log("기본");
        yield return delay02;
        isChanged = true;
    }
    IEnumerator Jab()
    {
        Debug.Log("플레이어잽!");
        spriteRenderer.sprite = jab[0];
        yield return delay01;
        StartCoroutine(Hit());
        yield return delay01;
        ChangeState(PlayerState.Idle);
    }
    IEnumerator DuckingLeft()
    {
        Debug.Log("플레이어왼덬");
        spriteRenderer.sprite = left[0];
        yield return delay05;
        ChangeState(PlayerState.Idle);
    }
    IEnumerator DuckingRight()
    {
        Debug.Log("플레이어오른덬");
        spriteRenderer.sprite = right[0];
        yield return delay05;
        ChangeState(PlayerState.Idle);
    }
    IEnumerator Guard()
    {
        Debug.Log("플레이어가드");
        spriteRenderer.color = new Color(0, 1, 1, 1);
        yield return delay1;
        ChangeState(PlayerState.Idle);
    }
    IEnumerator Hit()
    {
        if (enemy.enemyState.ToString() == "Idle")
        {
            gameManager.enemyHp--;
            enemyRenderer.color = new Color(1, 1, 1, 0.2f);
            yield return new WaitForSeconds(0.1f);
            enemyRenderer.color = new Color(1, 1, 1, 1);
        }
        if (enemy.enemyState.ToString() == "Guard")
        {
            gameManager.enemyHp++;

        }
    }
}