using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pies : MonoBehaviour
{
    public float rebore;
    public Jugador jugador;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D c1)
    {
        if (c1.tag == "plataforma")
        {
            jugador.EnElPiso = true;
            jugador.Caida.Play();
        }

        //if (c1.tag == "enemigo")
        //{
        //    jugador.Salto.Play();
        //    Destroy(c1.gameObject);
        //    jugador.JugadorBody.velocity = new Vector2(jugador.JugadorBody.velocity.x, rebore);
        //}
    }

    private void OnTriggerExit2D(Collider2D c1)
    {
        if (c1.tag == "plataforma")
        {
            jugador.EnElPiso = false;
        }
    }
}
