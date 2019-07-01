using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EsenaLogica : MonoBehaviour
{
    public AudioSource Musica;
    public AudioSource Perdiste;
    public Jugador Jugador;
    public GameObject PuntoInicio;
    public GameObject[] NivelPrefap;
    private int IndiceNiveles;
    private GameObject ObjetoNivel;
    private GameObject moneda;
    public int Puntaje = 0;
    public Text TextoDeJuego;
    public bool YaSeEscucho = false;
   


    // Start is called before the first frame update
    void Start()
    {
        Musica.Play();
        IndiceNiveles = 0;
        ObjetoNivel = Instantiate(NivelPrefap[IndiceNiveles]);
        ObjetoNivel.transform.SetParent(this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        TextoDeJuego.text = "Nivel: " + (IndiceNiveles + 1) + "\nPuntaje: " + Puntaje;
        

        if (Jugador.Perdiste)
        {
            if (!YaSeEscucho)
            {
                Perdiste.Play();
                YaSeEscucho = true;
                TextoDeJuego.text = "Nivel: " + (IndiceNiveles + 1) + "\nPuntaje: " + Puntaje + "\nPerdiste";
            }

            TextoDeJuego.text = "Nivel: " + (IndiceNiveles + 1) + "\nPuntaje: " + Puntaje + "\nPerdiste";                      
        
            if (Jugador.Perdiste ==true)
            {
                Puntaje = 0;
                Jugador.JugadorBody.constraints = RigidbodyConstraints2D.None;
                Jugador.JugadorBody.constraints = RigidbodyConstraints2D.FreezeRotation;

                Jugador.gameObject.transform.position = PuntoInicio.transform.position;
                Destroy(ObjetoNivel);
                ObjetoNivel = Instantiate(NivelPrefap[IndiceNiveles]);
                ObjetoNivel.transform.SetParent(this.transform);
                Jugador.Perdiste = false;
                YaSeEscucho = false;
            }
        }
        if (Jugador.SiguienteNivel)
        {
            TextoDeJuego.text = "Nivel: " + (IndiceNiveles + 1) + "\nPuntaje: " + Puntaje + "\nCompletaste el Nivel";
          
            if (IndiceNiveles == NivelPrefap.Length -1)
            {
                TextoDeJuego.text = "Completaste el Juego Gracias por Jugar!";
            }

            //if (Jugador.SiguienteNivel == true)
            //{
                Jugador.JugadorBody.constraints = RigidbodyConstraints2D.None;
                Jugador.JugadorBody.constraints = RigidbodyConstraints2D.FreezeRotation;
                Jugador.gameObject.transform.position = PuntoInicio.transform.position;

                if (IndiceNiveles == NivelPrefap.Length - 1)
                {
                    Destroy(ObjetoNivel);
                    IndiceNiveles = 0;
                    ObjetoNivel = Instantiate(NivelPrefap[0]);
                    ObjetoNivel.transform.SetParent(this.transform);
                    Jugador.SiguienteNivel = false;
                }
                else
                {
                    Destroy(ObjetoNivel);
                    IndiceNiveles += 1;
                    ObjetoNivel = Instantiate(NivelPrefap[IndiceNiveles]);
                    ObjetoNivel.transform.SetParent(this.transform);
                    Jugador.SiguienteNivel = false;
                }
            //}
        }

    }
}
