using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject menu;
    bool isOpenMenu;
    public void play()
    {
        SceneManager.LoadScene("1");
    }
    public void quit()
    {
        Application.Quit();
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("title");
    }
   public void Openmenu()
    {
        menu.SetActive(!isOpenMenu);
        isOpenMenu = !isOpenMenu;
    }
}
