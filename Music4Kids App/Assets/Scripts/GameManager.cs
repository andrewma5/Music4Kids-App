using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool sounds;

    public string currentNote;

    public int currentNoteNumber;

    private string[] trebleNotes = { "C1", "D1", "E1", "F1", "G1", "A2", "B2", "C2", "D2", "E2", "F2", "G2", "A3" };

    private TrebleNoteManager trebleNoteManager;
    private BassNoteManager bassNoteManager;

    private GameButtons buttons;

    public bool treble = true;

    private int lives = 3;

    private int score = 0;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sounds = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckNote(string n)
    {
        if (trebleNoteManager == null && treble)
        {
            trebleNoteManager = GameObject.Find("Canvas").transform.GetChild(0).GetComponent<TrebleNoteManager>();
        }

        if (bassNoteManager == null && !treble)
        {

        }

        if (buttons == null)
        {
            buttons = GameObject.Find("Canvas").GetComponent<GameButtons>();
        }

        if (string.Equals(n, currentNote))
        {
            if (treble) SpawnTreble();
            else SpawnBass();

            score++;
            buttons.UpdateScore(score);
        }
        else
        {
            lives--;
            if (lives == 0)
            {
                // Lose
            }
            buttons.UpdateLives(lives);
        }
    }

    public void SpawnTreble()
    {
        int choice = (int)UnityEngine.Random.Range(0, trebleNotes.Length - 1);
        while (choice == currentNoteNumber)
        {
            choice = (int)UnityEngine.Random.Range(0, trebleNotes.Length - 1);
        }
        currentNoteNumber = choice;
        trebleNoteManager.ActivateNote(trebleNotes[choice]);
    }

    public void SpawnBass()
    {
        int choice = (int)UnityEngine.Random.Range(0, trebleNotes.Length - 1);
        while (choice == currentNoteNumber)
        {
            choice = (int)UnityEngine.Random.Range(0, trebleNotes.Length - 1);
        }
        currentNoteNumber = choice;
        trebleNoteManager.ActivateNote(trebleNotes[choice]);

    }
}
