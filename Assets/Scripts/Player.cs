using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [Header("Sprite")]
    public Sprite leftReady;
    public Sprite rightReady;
    public Sprite leftPunch;
    public Sprite rightPunch;
    public Sprite leftAvoid;
    public Sprite rightAvoid;
    public Sprite Idle;

    private Animator animCon;
    private SpriteRenderer spriteRenderer;
    private NoteCheck noteChecker;
    private StateCheck stateChecker;

    private void Start()
    {
        noteChecker = NoteCheck.instance;
        stateChecker = StateCheck.instance;
        animCon = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        InputKey();
    }

    // 플레이어의 입력
    private void InputKey()
    {
        if (Input.anyKeyDown && noteChecker.noteList != null && noteChecker.OnBeat == true)
        {
            animCon.SetTrigger("Beat");
            noteChecker.NoteDieAnim();

            // 왼쪽 펀치
            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.UpArrow))
            {
                LeftPunch();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
            {
                LeftPunch();
            }

            // 오른쪽 펀치
            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.UpArrow))
            {
                RightPunch();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
            {
                RightPunch();
            }

            // 왼쪽 회피
            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.DownArrow))
            {
                SpriteChange(leftAvoid, StateCheck.State.LeftAvoid); 
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
            {
                SpriteChange(leftAvoid, StateCheck.State.LeftAvoid);
            }

            // 오른쪽 회피
            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.DownArrow))
            {
                SpriteChange(rightAvoid, StateCheck.State.RightAvoid);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
            {
                SpriteChange(rightAvoid, StateCheck.State.RightAvoid);
            }

            stateChecker.Fight();
        }
        else if (Input.anyKeyDown) // Miss
        {
            noteChecker.Miss();
        }
    }

    private void LeftPunch()
    {
        if (spriteRenderer.sprite != leftReady) SpriteChange(leftReady, StateCheck.State.ReadyPunch);
        else SpriteChange(leftPunch, StateCheck.State.LeftPunch);
    }

    private void RightPunch()
    {
        if (spriteRenderer.sprite != rightReady) SpriteChange(rightReady, StateCheck.State.ReadyPunch);
        else SpriteChange(rightPunch, StateCheck.State.RightPunch);
    }

    private void SpriteChange(Sprite sprite, StateCheck.State nextState)
    {
        spriteRenderer.sprite = sprite;
        stateChecker.StateChange(stateChecker.P1_State, nextState);
    }

}
