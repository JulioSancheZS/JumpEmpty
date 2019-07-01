using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tactil : MonoBehaviour
{
    public int FuerzaSalto;
    public bool EnElPiso = false;
    public Rigidbody2D JugadorBody;
    public float Velocidad;
    public bool MidandoDerecha = true;
    private Animator MiAnimacion;
    public float reboteEnemigo;
    public float alturaPerdiste;
    public bool Perdiste;
    public bool SiguienteNivel;
    public AudioSource Salto;
    public AudioSource Caida;


    // Start is called before the first frame update
    void Start()
    {
        JugadorBody = GetComponent<Rigidbody2D>();
        MiAnimacion = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        ControlarMovimiento(horizontal);
        Voltear(horizontal);

        if (Input.GetKeyDown("space") && EnElPiso)
        {
            Salto.Play();
            JugadorBody.AddForce(new Vector2(0, FuerzaSalto));
        }
    }

    private void ControlarMovimiento(float horizontal)
    {
        JugadorBody.velocity = new Vector2(horizontal * Velocidad, JugadorBody.velocity.y);
        MiAnimacion.SetFloat("velocidad", Mathf.Abs(horizontal));

    }

    private void OnCollisionEnter2D(Collision2D c1)
    {
        if (c1.collider.gameObject.tag == "plataforma")
        {
            MiAnimacion.SetFloat("salto", 0);
            //EnelPiso = true;
        }

    }

    private void Voltear(float horizontal)
    {
        if (EnElPiso)
        {
            if (horizontal > 0 && !MidandoDerecha || horizontal < 0 && MidandoDerecha)
            {
                MidandoDerecha = !MidandoDerecha;
                Vector3 LaEscala = transform.localScale;
                LaEscala.x *= -1;
                transform.localScale = LaEscala;
            }
        }

    }
}
