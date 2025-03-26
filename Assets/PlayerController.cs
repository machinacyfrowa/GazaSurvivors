using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 controllerInput;
    public float speed = 5f;
    //odniesienie do komponentu Rigidbody gracza
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //pobieramy odniesienie do komponentu Rigidbody
        rb = GetComponent<Rigidbody>();
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
