using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playerbehavior : MonoBehaviour
{    
    private float xiz = 0f;
    public static bool batida;
    public GameObject Canvas;
    //public GameObject telaMorta;

    //var pra mover sem teleporte
    public Vector2 posicaoAtual = new Vector2(0f, -3.86f); //auxilia na mudança do x do carro
    public int velocidade = 30;                    //velocidade que o carro se move

    //var pra animação
    public Animator animacao;
    public bool dir;
    public bool esq;
    public bool dir1;
    public bool esq1;
    public bool dirstay;
    public bool esqstay;
    public bool meiostay;

    IEnumerator TimerPw(){	
		yield return new WaitForSeconds(0f);
        batida = true;
	}


    void Start(){
        batida = false;
        transform.position = new Vector2(0f,-3.86f); 
        animacao = GetComponent<Animator>();
    }

    void Update(){
        posicaoAtual = new Vector2(xiz, -3.86f);
        Move();
    }

    private void Move(){   
        if(Input.GetKeyDown(KeyCode.A) && batida == false){
            xiz = xiz -6f;
            esq = true;
            dir = false;
            dir1 = false;
            esq1 = false;
        } else if(esq == true){
            esq = false;
            dir = false;
            dir1 = false;
            esq1 = true;
        }

        if(Input.GetKeyDown(KeyCode.D) && batida == false){
            xiz = xiz + 6f;
            esq = false;
            dir = true;
            dir1 = false;
            esq1 = false;
        } else if(dir == true){
            esq = false;
            dir = false;
            dir1 = true;
            esq1 = false;
        }
        
        if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)){
            esq = false;
            dir = false;
            dir1 = false;
            esq1 = false;
        }

        if(xiz > 6f){
            xiz = 6f;
        }
        
        if(xiz < -6f){
            xiz = -6f;
        }

        if(xiz == 6f){
            dirstay = true;
            esqstay = false;
            meiostay = false;
        } else if(xiz == -6){
            dirstay = false;
            esqstay = true;
            meiostay = false;
        } else {
            meiostay = true;
            dirstay = false;
            esqstay = false;
        }

        //move sem teleportar
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), posicaoAtual, velocidade * Time.deltaTime);

        //animações
        if(dir == true){
            animacao.SetBool("direita", true);
            animacao.SetBool("esquerda", false);
            animacao.SetBool("normal", false);
            animacao.SetBool("direitadenovo", false);
            animacao.SetBool("esquerdadenovo", false);
            animacao.SetBool("dirstay", false);
            animacao.SetBool("esqstay", false);
        } else if(esq == true){
            animacao.SetBool("direita", false);
            animacao.SetBool("esquerda", true);
            animacao.SetBool("normal", false);
            animacao.SetBool("direitadenovo", false);
            animacao.SetBool("esquerdadenovo", false);
            animacao.SetBool("dirstay", false);
            animacao.SetBool("esqstay", false);
        } else if(dir1 == true){
            animacao.SetBool("direita", false);
            animacao.SetBool("esquerda", false);
            animacao.SetBool("normal", false);
            animacao.SetBool("direitadenovo", true);
            animacao.SetBool("esquerdadenovo", false);
            animacao.SetBool("dirstay", false);
            animacao.SetBool("esqstay", false);
        } else if(esq1 == true){
            animacao.SetBool("direita", false);
            animacao.SetBool("esquerda", false);
            animacao.SetBool("normal", false);
            animacao.SetBool("direitadenovo", false);
            animacao.SetBool("esquerdadenovo", true);
            animacao.SetBool("dirstay", false);
            animacao.SetBool("esqstay", false);
        } else if(esqstay == true){
            animacao.SetBool("direita", false);
            animacao.SetBool("esquerda", false);
            animacao.SetBool("normal", false);
            animacao.SetBool("direitadenovo", false);
            animacao.SetBool("esquerdadenovo", false);
            animacao.SetBool("dirstay", false);
            animacao.SetBool("esqstay", true);
        } else if(dirstay == true){
            animacao.SetBool("direita", false);
            animacao.SetBool("esquerda", false);
            animacao.SetBool("normal", false);
            animacao.SetBool("direitadenovo", false);
            animacao.SetBool("esquerdadenovo", false);
            animacao.SetBool("dirstay", true);
            animacao.SetBool("esqstay", false);
        } else if(esq == false && esq1 == false && dir == false && dir1 == false && esqstay == false && dirstay == false && meiostay == true){
            animacao.SetBool("direita", false);
            animacao.SetBool("esquerda", false);
            animacao.SetBool("normal", true);
            animacao.SetBool("direitadenovo", false);
            animacao.SetBool("esquerdadenovo", false);
            animacao.SetBool("dirstay", false);
            animacao.SetBool("esqstay", false);
        } 
    } 

    public void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Colisor"){
            GetComponent<Renderer>().material.color = Color.grey;
            StartCoroutine(TimerPw());
        }	
    }
}
