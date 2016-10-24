using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject Head;
    public GameObject SettingMenu;
    public GameObject LastMenu;
    public static int life = 0;
    public static bool newGame = false;
    public static AudioClip playAll;
    public AudioClip playEate;
    public AudioClip playChangePanel;
    AudioSource Sound;
    private bool isPlayAllGame = true;

    void Start()
    {
        Head.SetActive(false);
        SettingMenu.SetActive(false);
        LastMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OnButtonPlayClick()
    {
        PLayWhenChaingePanel();

        if (UpdateController.endGame)
        {
            newGame = true;
            life = 3;
            UpdateController.endGame = false;
        }
        mainMenu.SetActive(false);
        SettingMenu.SetActive(false);
        Head.SetActive(true);
        LastMenu.SetActive(false);

    }

    public void OnButtonPlayAgainClick()
    {
        PLayWhenChaingePanel();
        UpdateController.endGame = false;
        life = 3;
        LastMenu.SetActive(false);
        Head.SetActive(true);
        mainMenu.SetActive(false);
        SettingMenu.SetActive(false);
        newGame = true;
    }

    public void OnButtonSettingClick()
    {
        PLayWhenChaingePanel();
        mainMenu.SetActive(false);
        SettingMenu.SetActive(true);
    }

    public void OnButtonBackInSettingClick()
    {
        PLayWhenChaingePanel();
        mainMenu.SetActive(true);
        SettingMenu.SetActive(false);
        Head.SetActive(false);

    }

    void PLayWhenChaingePanel()
    {
        Sound = GetComponent<AudioSource>();
        //Sound.Play();
        Sound.PlayOneShot(playChangePanel);
        
    }

    void PLayAllGame()
    {
        Sound = GetComponent<AudioSource>();
        Sound.clip = playAll;
        Sound.Play();
    }

    void PlayIfEate()
    {
        Sound = GetComponent<AudioSource>();        
        Sound.PlayOneShot(playEate);        
    }

    void Update()
    {
        //if (isPlayAllGame)
        //{
        //    PLayAllGame();
        //}


        if (UpdateController.musicForEate)
        {
            PlayIfEate();
        }

        if (UpdateController.endGame)
        {
            Head.SetActive(false);
            LastMenu.SetActive(true);
        }
    }
}
