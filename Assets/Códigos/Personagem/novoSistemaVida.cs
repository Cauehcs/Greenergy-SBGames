using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class novoSistemaVida : MonoBehaviour
{
    //var de vida
    public int vidaMax = 3;
    public int vidaMostrar;
    public static bool recuperarVida, levarDano;
    [SerializeField]public static int vidaAtual;

    //var imagens dos coraçoes
    public Image[] arrayCoracoes;       //3 elementos
    public Sprite coracaoCheio;         //sprite coracao cheio
    public Sprite coracaoVazio;         //sprite coracao da morena vazio

    //var de objetos que vão piscar
    //public GameObject goXXeyes;         //gameobject filho do objeto "CabeçaLife" que fica desativado
                                        //é o X-X do zequinho quando levar dano
    public Image coracaoUm;             //sprite do coracao 1
                                        //deve ter um objeto filho com sprite de coração vazio atrás dele
                                        //é só copiar o coraçao 1, mudar o sprite e por ele atrás
    public bool varAuxPisca = false;    //variavel que auxilia coracao um piscar
    //public GameObject goCoracoes;       //esse game object vazio que fica no canvas, guarda objetos filhos, que sao as 3 vidas
                                        //nesse projeto se chama "Hearts" 
    public GameObject chuquinGO;        //g.o. do choque

    //va de objetos que recuperam vida
    public bool colidiu;                //variavel pra ver se o zeq colidiu no colider trigger do obj vazio filho do obj q recupera vida
                                        //esse obj tem q estar com a tag e deve ser maior que o colider sem trigger do obj mae
    public Animator rosto;
    public SpriteRenderer green;

    [SerializeField]
    private float flashLenght = 1f;     //é a duração da piscada, é pra ser proporcional a duração da invencibilidade
    private float flashCounter = 0f;    //variavel que vai comparar pra fazer ele piscar relaxa só finge que não viu



    void Start()
    {
       vidaAtual = vidaMax;             //vida cheia ao inicio da cena
       green = GetComponent<SpriteRenderer>();
    }

    void Update(){ 
        vidaMostrar = vidaAtual;
        if (vidaAtual > vidaMax) 
            vidaAtual = vidaMax;        //vida não passa do num de hearts

        // if(varAuxPisca == true){
        //     Invoke("Apaga", 0.5f);      
        // } else {
        //     CancelInvoke("Apaga");      //se nao tiver, vai bugar
        // }

        for (int i = 0; i < arrayCoracoes.Length; i++){ 
            if (i < vidaAtual){
                arrayCoracoes[i].sprite = coracaoCheio;  //se tiver vida, coracao fica cheio       
            } else {
                arrayCoracoes[i].sprite = coracaoVazio;
            }
        }

        // if(vidaAtual == 1){                          //se tiver com 1 vida
        //     varAuxPisca = true;
        // }

    }

    public void Apaga(){           //o coração 1 vai ficar invisível, dando visão para o sprite vazio que fica atrás
        coracaoUm.enabled = false;
        Invoke("Normaliza", 0.3f); //tempo para voltar ao normal
    }

    public void Normaliza(){       //coração 1 volta a ficar visível
        // coracaoUm.enabled = true;
        // Espera();
        // varAuxPisca = false;
    }

    public IEnumerator Espera(){   //só um timer pra harmonizar e não bugar
        yield return new WaitForSeconds(0.5f);
    }

    public void LevarDano(){  
        //StartCoroutine("PiscarHeart", 0.21f);
        StartCoroutine("Choque", 0.5f);
        StartCoroutine("PiscarEyes", 0.51f);    //Rosto dano
        vidaAtual--;                            //diminui 1 da vida atual
        levarDano = true;
    }

    public IEnumerator Choque(){
        chuquinGO.SetActive(true);
        green.enabled = false;
        yield return new WaitForSeconds(0.5f);
        green.enabled = true;
        chuquinGO.SetActive(false);
    }

    // public IEnumerator PiscarHeart(){          //piscaria todos coracoes ao levar dano
    //     goCoracoes.SetActive(false);           //ele vai desativar...
    //     yield return new WaitForSeconds(0.2f);
    //     goCoracoes.SetActive(true);            //e ativar...
    // }

    public IEnumerator PiscarEyes(){
        rosto.SetBool("levouDano", true);
        rosto.SetBool("idle", false);
        yield return new WaitForSeconds(0.5f);
        rosto.SetBool("levouDano", false);            //desativa
        rosto.SetBool("idle", true);
    }

    public void Recarregacena(){
        //if (vidaAtual < 1)                       //vida for zero
            //SceneManager.LoadScene("GameOver1"); //gameover
    }

    public void OnTriggerEnter2D(Collider2D collision){
        if (/*collision.gameObject.tag == "Enemy" || */collision.gameObject.tag == "tiro" || collision.gameObject.tag == "tiroSegue"){ //em colisao com eles
            LevarDano();    
            Destroy(collision.gameObject);                                                //leva dano
        }
        if (collision.gameObject.tag == "Grink" && vidaAtual < vidaMax){ //em colisao com eles
            vidaAtual = vidaMax;
            Destroy(collision.gameObject);
            recuperarVida = true;                                                                     //leva dano
        }
    }

    IEnumerator CountDownDano(){ //seria o countdown
        yield return new WaitForSeconds(11f);
    }
    

   
}

