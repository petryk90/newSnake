using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject Head;
    public GameObject SettingMenu;
    public GameObject LastMenu;
    public static int life = 0;

    void Start()
    {
        Head.SetActive(false);
        SettingMenu.SetActive(false);
        LastMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OnButtonPlayClick()
    {
        mainMenu.SetActive(false);
        SettingMenu.SetActive(false);
        Head.SetActive(true);
        life = 3;
        //UpdateController newGame = new UpdateController();
        //newGame.GameStart();
    }

    public void OnButtonSettingClick()
    {
        mainMenu.SetActive(false);
        SettingMenu.SetActive(true);
    }

    public void OnButtonBackInSettingClick()
    {
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
