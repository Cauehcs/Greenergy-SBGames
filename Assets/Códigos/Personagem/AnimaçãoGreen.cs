using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaçãoGreen : MonoBehaviour
{
    public Animator animAtual;
    public RuntimeAnimatorController animDesarmado;
    public RuntimeAnimatorController animArmado;
    public SpriteRenderer SRenderer;
    public Sprite spritePegarArma;
    public Vector2 speedNulo;

    public GameObject Green, Porta, GpCoolDown, posArmaInicial;

    
    public float nextFire;
    public float fireRate;
    public bool atirou, tiro, parar;
    public float temp;

    // Start is called before the first frame update
    void Start() {
        animAtual = GetComponent<Animator>();
        SRenderer = GetComponent<SpriteRenderer>();
        atirou = false;
        tiro = false;
    }

    // Update is called once per frame
    void Update(){
        animMovimento();      
        animAtirar();

        if(parar){
            transform.position = posArmaInicial.transform.position;
        }

        if(tiro)
            sairAnim();
        }

    public void animMovimento(){
         //Anim - Andando Apenas
        if(GetComponent<Rigidbody2D>().velocity.x > 0 && !Input.GetKeyUp(KeyCode.LeftArrow) && !Input.GetKeyUp(KeyCode.RightArrow) && !Input.GetKeyUp(KeyCode.UpArrow) && !Input.GetKeyUp(KeyCode.DownArrow))
        {
            animAtual.SetBool("andarD", true);
            animAtual.SetBool("andarE", false);
            animAtual.SetBool("andarC", false);
            animAtual.SetBool("andarB", false);
            animAtual.SetBool("parado", false);
            
        }
      
        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            animAtual.SetBool("andarD", false);
            animAtual.SetBool("andarE", true);
            animAtual.SetBool("andarC", false);
            animAtual.SetBool("andarB", false);
            animAtual.SetBool("parado", false);

        }
       
        else if (GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            animAtual.SetBool("andarD", false);
            animAtual.SetBool("andarE", false);
            animAtual.SetBool("andarC", true);
            animAtual.SetBool("andarB", false);
            animAtual.SetBool("parado", false);

        }
        
        else if (GetComponent<Rigidbody2D>().velocity.y < 0)
        {  
            animAtual.SetBool("andarD", false);
            animAtual.SetBool("andarE", false);
            animAtual.SetBool("andarC", false);
            animAtual.SetBool("andarB", true);
            animAtual.SetBool("parado", false);

        }

         if (GetComponent<Rigidbody2D>().velocity == speedNulo)
        {
            animAtual.SetBool("parado" , true);
            animAtual.SetBool("andarD", false);
            animAtual.SetBool("andarE", false);
            animAtual.SetBool("andarC", false);
            animAtual.SetBool("andarB", false);
        }
    }
    public void animAtirar(){
        
        if(Input.GetKeyUp(KeyCode.RightArrow)){ 
            
             if (Time.time > nextFire){       
                nextFire = fireRate + Time.time;
                
                tiro = true;

                animAtual.SetBool("atirarD", true);  
                animAtual.SetBool("atirarE", false);
                animAtual.SetBool("atirarC", false);
                animAtual.SetBool("atirarB", false);
            }
        }

         if(Input.GetKeyUp(KeyCode.LeftArrow)){

             if (Time.time > nextFire){       
                nextFire = fireRate + Time.time;

                tiro = true;

                animAtual.SetBool("atirarE", true);  
                animAtual.SetBool("atirarD", false);
                animAtual.SetBool("atirarC", false);
                animAtual.SetBool("atirarB", false);
             }
           
        }

         if(Input.GetKeyUp(KeyCode.DownArrow)){

                if (Time.time > nextFire){       
                    nextFire = fireRate + Time.time;         
                    
                    tiro = true;

                    animAtual.SetBool("atirarB", true); 
                    animAtual.SetBool("atirarD", false);
                    animAtual.SetBool("atirarE", false);
                    animAtual.SetBool("atirarC", false);
            }
        }

         if(Input.GetKeyUp(KeyCode.UpArrow)){

              if (Time.time > nextFire){       
                nextFire = fireRate + Time.time;      

                tiro = true;

                animAtual.SetBool("atirarC", true);  
                animAtual.SetBool("atirarD", false);
                animAtual.SetBool("atirarE", false);
                animAtual.SetBool("atirarB", false);
            } 
        }
      
    }


        void sairAnim(){
                temp += Time.deltaTime;

                if(temp >= 0.2f){
                animAtual.SetBool("atirarD", false);  
                animAtual.SetBool("atirarE", false);
                animAtual.SetBool("atirarC", false);
                animAtual.SetBool("atirarB", false);
                temp = 0;
                tiro = false;
                }    
        }

        void OnTriggerEnter2D(Collider2D col) {
            //Troca de controller desarmado para armado, quando pegar a arma no chão (Modo Campanha)
            if(col.tag == "armaInicial"){
                animAtual.runtimeAnimatorController = animArmado;
                Green.GetComponent<AtaqueGreen>().enabled = true;
                GpCoolDown.SetActive(true);
                animAtual.enabled = false;
                SRenderer.sprite = spritePegarArma;
                posArma.seguir = false;
                //Porta.GetComponent<abrirPorta>().enabled = true;
                Destroy(col.gameObject);
                parar = true;
            }
        }
}
