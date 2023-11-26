using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class NoteCheck : MonoBehaviour
{
    public static NoteCheck instance;

    public List<GameObject> noteList = new List<GameObject>();
    public bool OnBeat;
    [SerializeField] private GameObject missText;
    [SerializeField] private Transform canvas;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Note"))
        {
            noteList.Add(collision.gameObject);
            OnBeat = true;
        }
    }

    public void NoteDieAnim()
    {
        for (int i = 0; i < noteList.Count; i++)
        {
            noteList[i].GetComponent<Note>().isAnim = true;
            noteList[i].GetComponent<Animator>().SetTrigger("IsBeat");
        }
        noteList.Clear();
        OnBeat = false;
    }

    public void Miss()
    {
        Destroy(Instantiate(missText, canvas), 0.5f);
    }
}
