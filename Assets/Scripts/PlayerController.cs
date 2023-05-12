using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public AudioClip[] audios;
    public GameObject gameManager;
    public GameObject bala;
    
    
    private Animator animator;
    private Rigidbody2D rb;
    private AudioSource audioSource;
    private Transform balaTransform;
    
    private int currentAnimation = 1;
    public float tiempoDeRetraso = 2.0f;
    public int vida = 3;
    public bool Muerte = false;
    private bool balaExiste = false;
    

    private GameManager gm;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        gm = FindObjectOfType<GameManager>();

        
    }

    void Update()
    {
        Saltar();
        Disparar();
        DividirDisparo();
        CambioEscena();
        animator.SetInteger("Estado", currentAnimation);

    }

    private void Saltar() {
      if(Input.GetKeyUp(KeyCode.Space)) {
        audioSource.PlayOneShot(audios[0], 0.2f);
      }
    }

    private void Disparar() {

      var gm = gameManager.GetComponent<GameManager>();
      var uim = gameManager.GetComponent<UiManager>();
      //int BalaMoneda = gm.GetPuntaje();

      if(Input.GetKeyUp(KeyCode.U)) {
        audioSource.PlayOneShot(audios[1]);
        balaExiste = true;
        var position = transform.position;
        var x = position.x + 1;
        var newPosition = new Vector3(x, position.y, position.z);
        
        GameObject balaGenerada = Instantiate(bala, newPosition, Quaternion.identity);
        balaTransform = balaGenerada.transform;
        
        //gm.PerderPuntos();
        //uim.PrintPuntaje(gm.GetPuntaje());
        //GanarPuntos();
      }
    }

    private void DividirDisparo() {
      // solo se divide si la bala existe y presiono O
      //transform.position
      if(balaExiste && Input.GetKeyUp(KeyCode.O)) {

        var position = balaTransform.position;
        var positionBala2 = new Vector3(position.x + 1, position.y + 1, position.z); 
        var positionBala3 = new Vector3(position.x + 1, position.y - 1, position.z); 

        GameObject balaGenerada2 = Instantiate(bala, positionBala2, Quaternion.identity);

        (balaGenerada2.GetComponent<BalaController>()).velocityY = 1;

        GameObject balaGenerada3 = Instantiate(bala, positionBala3, Quaternion.identity);

        (balaGenerada3.GetComponent<BalaController>()).velocityY = -1;
      }
    }

    /*
    private void GanarPuntos() {
      var gm = gameManager.GetComponent<GameManager>();
      var uim = gameManager.GetComponent<UiManager>();

      gm.GanarPuntos();
      uim.PrintPuntaje(gm.GetPuntaje());
    }
    */

    /*
    //Colisión para morir
    private void OnCollisionEnter2D(Collision2D other){
        Muerte = false;
        currentAnimation = 1;
      if (other.gameObject.CompareTag("Enemy")){

          audioSource.PlayOneShot(audios[3], 0.5f);
          gameManager = GameObject.Find("GameManager");
          var gm = gameManager.GetComponent<GameManager>();
          var uim = gameManager.GetComponent<UiManager>();

          gm.PerderVidas();
          uim.PrintVida(gm.GetVidas());

          int morir = gm.GetVidas();

          if(morir == 0){
            audioSource.PlayOneShot(audios[4]);
            Muerte = true;
            Debug.Log("Muerte");
            currentAnimation = 2;
            Invoke("DetenerTiempo", tiempoDeRetraso);
          } 

          
          //Destroy(this.gameObject);
          //currentAnimation = 5;

      }
    }

    */
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si el objeto que ha entrado en el trigger tiene la etiqueta "Coin", entonces lo hacemos desaparecer
        if (other.gameObject.CompareTag("Coin"))
        {
            audioSource.PlayOneShot(audios[2]);
            //Debug.Log("OnTrigger");
            other.gameObject.SetActive(false);
            GanarMonedas();
            //jumpEnemy = true;
        }
    }

    private void DetenerTiempo()
    {
        Time.timeScale = 0;
    }

    private void GanarMonedas()
    {
        gm.GanarMoneda();
    }

    private void CambioEscena(){
      gm.CambiarScena();
    }

}
