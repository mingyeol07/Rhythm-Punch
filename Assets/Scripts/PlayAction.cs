using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayAction : MonoBehaviour
{
    public enum State { Idle, ReadyPunch, LeftPunch, RightPunch, LeftAvoid, RightAvoid, Guard }
    private State P1_State = State.Idle;
    public State P1_NextState = State.Idle;
    private State P2_State = State.Idle;
    public State P2_NextState = State.Idle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Note"))
        {
            StartCoroutine(StateChange(P1_NextState, P1_State));
        }
    }

    private IEnumerator StateChange(State nextState, State player)
    {
        
        yield return null;
    }
}
