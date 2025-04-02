using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 controllerInput;
    public float speed = 5f;
    //odniesienie do komponentu Rigidbody gracza
    Rigidbody rb;
    // Start is called before the first frame update
    public List<GameObject> enemies;
    void Start()
    {
        //pobieramy odniesienie do komponentu Rigidbody
        rb = GetComponent<Rigidbody>();
        enemies = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //pobieramy wychylenie wirtualne joysticka w osi x (lewo/prawo) i y (g�ra/d�)
        controllerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //tworzymy wektor ruchu na podstawie wychylenia joysticka - zamieniamy y joysticka na z �wiata
        //Vector3 movementVector = new Vector3(controllerInput.x, 0, controllerInput.y);
        //przesuwamy obiekt gracza o wektor ruchu
        //transform.Translate(movementVector * Time.deltaTime * speed);

        //wyci�gamy sobie ze sceny wszystkie obiekty z tagiem Enemy i pakujemy na list�
        enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        //sortujemy list� wrog�w wed�ug odleg�o�ci od gracza i zpaisujemy ponownie jako liste
        //sk�adnia LINQ - to co jest w nawiasie po orderby czytamy jako
        //dla ka�dego wroga w li�cie enemies oblicz odleg�o�� od gracza i posortuj list� wed�ug tej odleg�o�ci
        enemies = enemies.OrderBy(enemy => Vector3.Distance(enemy.transform.position, transform.position)).ToList();
    }
    void FixedUpdate()
    {
        //wyliczamy docelow� pozycj� gracza _po_ ruchu
        //najpierw liczymy wektor przesuni�cia
        Vector3 movementVector = new Vector3(controllerInput.x, 0, controllerInput.y);
        //mno�ymy go przez czas od ostatniej klatki fizyki i predkosc ruchu
        //dodajemy go do obecnego po�o�enia gracza tworz�c pozycj� docelow�
        Vector3 targetPosition = transform.position + movementVector * Time.fixedDeltaTime * speed;
        //przesuwamy gracza przy u�yciu MovePosition
        rb.MovePosition(targetPosition);
    }
}
