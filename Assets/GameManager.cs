using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //ta funkcja zpobiega usuni�ciu gameManagera z gry przy zmianie sceny
        DontDestroyOnLoad(gameObject);
    }
    public void NewGame()
    {
        SceneManager.LoadScene("CharacterSelection");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
