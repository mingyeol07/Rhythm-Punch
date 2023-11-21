using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChanger : MonoBehaviour
{
    public enum State { Idle , ReadyPunch, LeftPunch, RightPunch, Guard}
    public State playerState = State.Idle;
    public State player2State = State.Idle;
}
