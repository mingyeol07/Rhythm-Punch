using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Sprite")]
    [SerializeField] private Sprite leftReady;
    [SerializeField] private Sprite rightReady;
    [SerializeField] private Sprite leftJab;
    [SerializeField] private Sprite rightJab;
    [SerializeField] private Sprite guard;
    [SerializeField] private Sprite hit;

    private Animator animCon;

    private void Start()
    {
        animCon = GetComponent<Animator>();
        InvokeRepeating("Beat", 1, 1);
    }

    private void Beat()
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

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {

        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {

        }
    }
}
