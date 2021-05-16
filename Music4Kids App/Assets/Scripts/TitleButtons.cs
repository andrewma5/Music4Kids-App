using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleButtons : MonoBehaviour
{

    [SerializeField] private Text SoundText;
    [SerializeField] private GameObject MainButtons, GameOptionsButtons, OptionsButtons;
    [SerializeField] private Text HighScore;
    [SerializeField] private Text SoundLevelText;

    // Start is called before the first frame update
    void Start()
    {
        MainButtons.SetActive(true);
        GameOptionsButtons.SetActive(false);
        OptionsButtons.SetActive(false);
        HighScore.text = "High Score: " + PlayerPrefs.GetInt("highscore", 0);
        SoundLevelText.text = "Sound: " + GameManager.instance.soundLevel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        MainButtons.SetActive(false);
        GameOptionsButtons.SetActive(true);
        OptionsButtons.SetActive(false);
    }

    public void OptionsButton()
    {
        MainButtons.SetActive(false);
        GameOptionsButtons.SetActive(false);
        OptionsButtons.SetActive(true);
    }

    public void TrebleButton()
    {
        GameManager.instance.treble = true;
        SceneManager.LoadScene("GameScene");
    }

    public void BassButton ()
    {
        GameManager.instance.treble = false;
        SceneManager.LoadScene("GameScene");
    }

    public void SoundButton ()
    {
        GameManager.instance.sounds = !GameManager.instance.sounds;

        if (GameManager.instance.sounds)
        {
            SoundText.text = "Sound On";
        }
        else
        {
            SoundText.text = "Sound Off";
        }

    }

    public void BackButton ()
    {
        OptionsButtons.SetActive(false);
        GameOptionsButtons.SetActive(false);
        MainButtons.SetActive(true);
    }

    public void IncreaseSound()
    {
        if (GameManager.instance.soundLevel < 10)
            GameManager.instance.soundLevel++;
        SoundLevelText.text = "Sound: " + GameManager.instance.soundLevel;
    }
    public void DecreaseSound()
    {
        if (GameManager.instance.soundLevel > 0)
            GameManager.instance.soundLevel--;
        SoundLevelText.text = "Sound: " + GameManager.instance.soundLevel;
    }
}
