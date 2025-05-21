using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //to jest instancja (wyst�pienie) klasy GameManager
    //jedyne s�uszne - zawsze w programie mo�e by� tylko jeden
    //GameManager - singleton
    public static GameManager Instance;

    private void Awake()
    {
        //je�eli w grze jest ju� GameManager i nie jest to ten sam obiekt
        //kt�ry w�a�nie uruchomili�my to go usuwamy nadmiarowy (nowy)
        //to si� wywo�a je�li przypadkiem zrobimy drugi GameManager
        if (Instance != null && Instance != this)
        {
            //niszczymy obecny (nieprawid�owy) obiekt GameManager
            Destroy(gameObject);
            //wychodzimy z funkcji
            return;
        }
        //je�eli nie ma GameManagera to zapisujemy ten obiekt jako instancj�
        if(Instance == null)
            Instance = this;

        //ta funkcja zpobiega usuni�ciu gameManagera z gry przy zmianie sceny
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
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
