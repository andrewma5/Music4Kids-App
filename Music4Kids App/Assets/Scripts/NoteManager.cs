using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteManager : MonoBehaviour
{

    private List<RawImage> notes = new List<RawImage>();

    private string[] note_arr = { "C1", "D1", "E1", "F1", "G1", "A2", "B2", "C2", "D2", "E2", "F2", "G2", "A3" };

    private int counter = 0;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip C1, D1, E1, F1, G1, A2, B2, C2, D2, E2, F2, G2, A3;

    [SerializeField] private Text livesText;
    [SerializeField] private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform note in transform)
        {
            notes.Add(note.GetComponent<RawImage>());
        }
        Debug.Log(notes.Count);
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
        if (GameManager.instance.sounds) PlaySound(n);

        foreach (RawImage ri in notes) ri.enabled = false;
        notes[NoteToNumber(n)].enabled = true;
        GameManager.instance.currentNote = n.Substring(0, 1);

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

    private void PlaySound(string n)
    {
        if (String.Equals(n, "C1"))
        {
            audioSource.PlayOneShot(C1);
        }
        else if (String.Equals(n, "D1"))
        {
            audioSource.PlayOneShot(D1);
        }
        else if (String.Equals(n, "E1"))
        {
            audioSource.PlayOneShot(E1);
        }
        else if (String.Equals(n, "F1"))
        {
            audioSource.PlayOneShot(F1);
        }
        else if (String.Equals(n, "G1"))
        {
            audioSource.PlayOneShot(G1);
        }
        else if (String.Equals(n, "A2"))
        {
            audioSource.PlayOneShot(A2);
        }
        else if (String.Equals(n, "B2"))
        {
            audioSource.PlayOneShot(B2);
        }
        else if (String.Equals(n, "C2"))
        {
            audioSource.PlayOneShot(C2);
        }
        else if (String.Equals(n, "D2"))
        {
            audioSource.PlayOneShot(D2);
        }
        else if (String.Equals(n, "E2"))
        {
            audioSource.PlayOneShot(E2);
        }
        else if (String.Equals(n, "F2"))
        {
            audioSource.PlayOneShot(F2);
        }
        else if (String.Equals(n, "G2"))
        {
            audioSource.PlayOneShot(G2);
        }
        else if (String.Equals(n, "A3"))
        {
            audioSource.PlayOneShot(A3);
        }
    }

    public void UpdateLives(int lives)
    {
        livesText.text = "Lives: " + lives;
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }
}
