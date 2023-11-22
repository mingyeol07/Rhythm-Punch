using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Sprite")]
    public Sprite leftReady;
    public Sprite rightReady;
    public Sprite leftJab;
    public Sprite rightJab;
    public Sprite guard;
    public Sprite hit;

    private Animator animCon;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        animCon = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating("Beat", 1, 1);
    }

    public void Beat()
    {
        animCon.SetTrigger("Beat");
    }

    private void Update()
    {
        InputKey();
    }

    // 플레이어의 입력
    private void InputKey()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            spriteRenderer.sprite = leftReady;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            spriteRenderer.sprite = rightReady;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            spriteRenderer.sprite = guard;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            spriteRenderer.sprite = hit;
        }
    }
}
