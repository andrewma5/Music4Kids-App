using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool sounds;

    public string currentNote;

    private string[] note_arr = { "C1", "D1", "E1", "F1", "G1", "A2", "B2", "C2", "D2", "E2", "F2", "G2", "A3" };

    private NoteManager notemanager;


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
        if (string.Equals(n, currentNote))
        {
            int choice = (int)UnityEngine.Random.Range(0, note_arr.Length - 1);
            if (notemanager == null)
            {
                notemanager = GameObject.Find("Canvas").transform.GetChild(0).GetComponent<NoteManager>();
            }
            notemanager.ActivateNote(note_arr[choice]);
        }
    }
}
