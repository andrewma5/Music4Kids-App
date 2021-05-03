using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector] public bool sounds;

    public string currentNote;

    public int currentNoteNumber;

    private string[] trebleNotes = { "C1", "D1", "E1", "F1", "G1", "A2", "B2", "C2", "D2", "E2", "F2", "G2", "A3" };
    private string[] bassNotes = { "E1", "F1", "G1", "A1", "B2", "C2", "D2", "E2", "F2", "G2", "A3", "B3", "C3" };

    private TrebleNoteManager trebleNoteManager;
    private BassNoteManager bassNoteManager;

    private GameButtons buttons;

    [HideInInspector] public bool treble;

    private int lives = 3;

    [HideInInspector] public int score = 0;


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
        treble = true;
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
            bassNoteManager = GameObject.Find("Canvas").transform.GetChild(1).GetComponent<BassNoteManager>();
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
                Lose();
            }
            buttons.UpdateLives(lives);
        }
    }

    public void SpawnTreble()
    {
        int choice = (int)UnityEngine.Random.Range(0, trebleNotes.Length);
        while (choice == currentNoteNumber)
        {
            choice = (int)UnityEngine.Random.Range(0, trebleNotes.Length);
        }
        currentNoteNumber = choice;
        trebleNoteManager.ActivateNote(trebleNotes[choice]);
    }

    public void SpawnBass()
    {
        int choice = (int)UnityEngine.Random.Range(0, bassNotes.Length);
        while (choice == currentNoteNumber)
        {
            choice = (int)UnityEngine.Random.Range(0, bassNotes.Length);
        }
        currentNoteNumber = choice;
        bassNoteManager.ActivateNote(bassNotes[choice]);

    }

    public void Lose ()
    {
        SceneManager.LoadScene("EndScene");
    }
}
