using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// 플레이어 둘의 상태를 보고 연산처리를 하는 스크립트
public class StateCheck : MonoBehaviour
{
    public static StateCheck instance;

    public enum State { Idle, ReadyPunch, LeftPunch, RightPunch, LeftAvoid, RightAvoid, Guard }
    public State P1_State = State.Idle;
    public State P2_State = State.Idle;

    private void Awake()
    {
        instance = this;
    }

    public void StateChange(State player, State changeState)
    {
        player = changeState;
    }

    public void Fight()
    {
        if(P1_State == State.Idle) 
        {
            if (P2_State == State.RightPunch || P2_State == State.LeftPunch)
            {

            }
        } // P1 오른가만히
        else if(P1_State == State.ReadyPunch) 
        {
            if (P2_State == State.RightPunch || P2_State == State.LeftPunch)
            {

            }
        } // P1 공격준비
        else if (P1_State == State.RightPunch) 
        {
            if (P2_State == State.RightPunch || P2_State == State.LeftPunch)
            {

            }
            else if (P2_State == State.RightAvoid)
            {

            }
            else if (P2_State == State.Guard)
            {

            }
        } // P1 오른공격
        else if (P1_State == State.LeftPunch) 
        {
            if (P2_State == State.RightPunch || P2_State == State.LeftPunch)
            {

            }
            else if (P2_State == State.LeftAvoid)
            {

            }
            else if (P2_State == State.Guard)
            {

            }
        } // P1 왼쪽공격
        else if (P1_State == State.RightAvoid) 
        {
            if (P2_State == State.RightPunch || P2_State == State.LeftPunch)
            {

            }
        } // P1 오른회피
        else if (P1_State == State.LeftAvoid) 
        {
            if (P2_State == State.RightPunch || P2_State == State.LeftPunch)
            {

            }
        } // P1 왼쪽회피
        else if(P1_State == State.Guard) 
        {
            if (P2_State == State.RightPunch || P2_State == State.LeftPunch)
            {

            }
        } // P1 가드
    }
}
