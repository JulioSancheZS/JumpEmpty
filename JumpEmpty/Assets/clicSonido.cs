using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class clicSonido : MonoBehaviour
{
    public AudioClip sonido;
    private Button boton { get { return GetComponent<Button>(); } }
    private AudioSource audio { get { return GetComponent<AudioSource>(); } }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        audio.clip = sonido;
        audio.playOnAwake = false;
        boton.onClick.AddListener(() => InicioSonido());
    }

    void InicioSonido()
    {
        audio.PlayOneShot(sonido);
    }
    // Update is called once per frame
    
   
}
