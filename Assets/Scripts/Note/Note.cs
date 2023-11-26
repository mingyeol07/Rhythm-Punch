using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float moveSpeed;
    public bool isAnim = false;
    private Rigidbody2D rigid;
    private NoteCheck noteChecker = null;
    
    private void Start()
    {
        noteChecker = NoteCheck.instance;
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!isAnim)
        {
            rigid.velocity = Vector3.left * Mathf.Sign(rigid.position.x) * moveSpeed;
        }
        else rigid.velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destroy"))
        {
            Debug.Log("dd");
            noteChecker.NoteDieAnim();
        }
    }

    private void DieAnim()
    {
        Destroy(gameObject);
    }
}
