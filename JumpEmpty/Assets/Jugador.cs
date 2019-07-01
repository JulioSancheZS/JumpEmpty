using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Jugador : MonoBehaviour
{

    public int FuerzaSalto;
    public bool EnElPiso = false;
    public Rigidbody2D JugadorBody;
    public float Velocidad;
    public bool MidandoDerecha = true;
    private Animator MiAnimacion;
    public float reboteEnemigo;
    public float alturaPerdiste;
    public bool Perdiste = false;
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
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        ControlarMovimiento(horizontal);
        Voltear(horizontal);

        if (CrossPlatformInputManager.GetButtonDown("Jump") && EnElPiso)
        {
            Salto.Play();
            JugadorBody.AddForce(new Vector2(0, FuerzaSalto));
        }

        if (gameObject.transform.position.y < alturaPerdiste)
        {
            Perdiste = true;
            JugadorBody.constraints = RigidbodyConstraints2D.FreezeAll;
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

        if (c1.collider.gameObject.tag == "enemigo")
        {
            Perdiste = true;
            JugadorBody.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        if (c1.collider.gameObject.tag == "sigNivel")
        {
            SiguienteNivel = true;
            JugadorBody.constraints = RigidbodyConstraints2D.FreezeAll;
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
