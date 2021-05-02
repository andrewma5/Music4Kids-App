using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BassNoteManager : MonoBehaviour
{

    private List<RawImage> notes = new List<RawImage>();

    private string[] note_arr = { "E1", "F1", "G1", "A1", "B2", "C2", "D2", "E2", "F2", "G2", "A3", "B3", "C3" };

    private int counter = 0;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips; // E1, F1, G1, A1, B2, C2, D2, E2, F2, G2, A3, B3, C3;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance.treble)
        {
            gameObject.SetActive(false);
        }

        foreach (Transform note in transform)
        {
            notes.Add(note.GetComponent<RawImage>());
        }
        notes[0].enabled = false;
        int choice = (int)UnityEngine.Random.Range(0, note_arr.Length - 1);
        GameManager.instance.currentNoteNumber = choice;
        ActivateNote(note_arr[choice]);
    }

    // Update is called once per frame
    void Update()
    {
        /*counter++;
        if (counter > 1000)
        {
            counter = 0;
            int choice = (int)UnityEngine.Random.Range(0, note_arr.Length - 1);
            ActivateNote(note_arr[choice]);
        } */
    }

    private int NoteToNumber(string n)
    {
        return Array.IndexOf(note_arr, n);
    }

    public void ActivateNote(string n)
    {
        if (GameManager.instance.sounds) StartCoroutine(PlaySound(n));

        foreach (RawImage ri in notes) ri.enabled = false;
        notes[NoteToNumber(n)].enabled = true;
        GameManager.instance.currentNote = n.Substring(0, 1);

        if (string.Equals(n, "E1")) // the lines for the notes at the top/bottom
        {
            notes[0].transform.GetChild(0).GetComponent<RawImage>().enabled = true;
            notes[notes.Count - 1].transform.GetChild(0).GetComponent<RawImage>().enabled = false;
        }
        else if (string.Equals(n, "C3"))
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

    private IEnumerator PlaySound(string n)
    {
        yield return new WaitForSeconds(0.25f);

        audioSource.PlayOneShot(audioClips[Array.IndexOf(note_arr, n)]);

    }
}
