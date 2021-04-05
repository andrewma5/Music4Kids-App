using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteManager : MonoBehaviour
{

    private List<RawImage> notes = new List<RawImage>();

    private string[] note_arr = { "C1", "D1", "E1", "F1", "G1", "A2", "B2", "C2", "D2", "E2", "F2", "G2", "A3" };

    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform note in transform)
        {
            notes.Add(note.GetComponent<RawImage>());
        }
        Debug.Log(notes.Count);
        notes[0].enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        counter++;
        if (counter > 1000)
        {
            counter = 0;
            int choice = (int)UnityEngine.Random.Range(0, note_arr.Length - 1);
            ActivateNote(note_arr[choice]);
        }
    }

    private int NoteToNumber(string n)
    {
        return Array.IndexOf(note_arr, n);
    }

    public void ActivateNote(string n)
    {
        foreach (RawImage ri in notes) ri.enabled = false;
        notes[NoteToNumber(n)].enabled = true;

        if (string.Equals(n, "C1")) // the lines for the notes at the top/bottom
        {
            notes[0].transform.GetChild(0).GetComponent<RawImage>().enabled = true;
            notes[notes.Count-1].transform.GetChild(0).GetComponent<RawImage>().enabled = false;
        }
        else if (string.Equals(n, "C1"))
        {
            notes[0].transform.GetChild(0).GetComponent<RawImage>().enabled = false;
            notes[notes.Count - 1].transform.GetChild(0).GetComponent<RawImage>().enabled = true;
        }
        else
        {
            notes[0].transform.GetChild(0).GetComponent<RawImage>().enabled = false;
            notes[notes.Count - 1].transform.GetChild(0).GetComponent<RawImage>().enabled = false;
        }
    }
}
