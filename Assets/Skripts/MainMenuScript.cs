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
    public AudioClip onAnotherPage;
    AudioSource Sound;

    void Start()
    {
        Head.SetActive(false);
        SettingMenu.SetActive(false);
        LastMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OnButtonPlayClick()
    {        
        Sound = GetComponent<AudioSource>();
        Sound.Play();
        
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
        Sound = GetComponent<AudioSource>();
        Sound.Play();
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
        Sound = GetComponent<AudioSource>();
        Sound.Play();
        mainMenu.SetActive(false);
        SettingMenu.SetActive(true);
    }

    public void OnButtonBackInSettingClick()
    {
        Sound = GetComponent<AudioSource>();
        Sound.Play();
        mainMenu.SetActive(true);
        SettingMenu.SetActive(false);
        Head.SetActive(false);

    }

    void Update()
    {
        if (UpdateController.endGame)
        {
            Head.SetActive(false);
            LastMenu.SetActive(true);
        }
    }
}
