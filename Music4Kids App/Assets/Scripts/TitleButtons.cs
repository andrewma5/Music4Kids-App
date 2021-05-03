using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleButtons : MonoBehaviour
{

    [SerializeField] private Text SoundText;
    [SerializeField] private GameObject MainButtons, GameOptionsButtons, OptionsButtons;

    // Start is called before the first frame update
    void Start()
    {
        GameOptionsButtons.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        MainButtons.SetActive(false);
        GameOptionsButtons.SetActive(true);
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
}
