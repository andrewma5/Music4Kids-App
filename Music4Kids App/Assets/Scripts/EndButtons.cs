using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndButtons : MonoBehaviour
{
    [SerializeField] private Text ScoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        ScoreDisplay.text = "Score: " + GameManager.instance.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndButton()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
