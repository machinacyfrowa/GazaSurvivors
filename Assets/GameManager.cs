using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //to jest instancja (wyst¹pienie) klasy GameManager
    //jedyne s³uszne - zawsze w programie mo¿e byæ tylko jeden
    //GameManager - singleton
    public static GameManager Instance;

    private void Awake()
    {
        //je¿eli w grze jest ju¿ GameManager i nie jest to ten sam obiekt
        //który w³aœnie uruchomiliœmy to go usuwamy nadmiarowy (nowy)
        //to siê wywo³a jeœli przypadkiem zrobimy drugi GameManager
        if (Instance != null && Instance != this)
        {
            //niszczymy obecny (nieprawid³owy) obiekt GameManager
            Destroy(gameObject);
            //wychodzimy z funkcji
            return;
        }
        //je¿eli nie ma GameManagera to zapisujemy ten obiekt jako instancjê
        if(Instance == null)
            Instance = this;

        //ta funkcja zpobiega usuniêciu gameManagera z gry przy zmianie sceny
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
