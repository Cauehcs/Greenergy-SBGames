using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public bool morto, jogando;
    public string nomeCena;
    public Scene cenaAtual;
   
    public GameObject Player;
    public GameObject CanvasPause, CanvasVida, CanvasCoolDown, CanvasGameOver;
    public GameObject btnselReiniciarSel, btnSairSel;
    public GameObject btnReiniciar, btnSair;
    public AudioSource somMorte, somMusica;    
    public int indice;

    
    // Start is called before the first frame update
    void Start()
    {
        CanvasGameOver.SetActive(false);
        somMorte = GetComponent<AudioSource>();
        indice = 0;
        jogando = true;
    }

    // Update is called once per frame
    void Update()
    {            
            cenaAtual = SceneManager.GetActiveScene();   
            nomeCena = cenaAtual.name;

            if(novoSistemaVida.vidaAtual <= 0 && nomeCena == "GameFase 1"){
                morto = true;
                jogando = false;
            }

            if(playerbehavior.batida && nomeCena == "GameFase2"){
                 morto = true;
                jogando = false;
            }

            if(morto && nomeCena == "GameFase 1"){
                somMorte.enabled = true;
                somMusica.enabled = false;
                CanvasCoolDown.SetActive(false);
                CanvasGameOver.SetActive(true);
                CanvasPause.SetActive(false);
                CanvasVida.SetActive(false);
                Player.GetComponent<MovimentoGreen>().enabled = false;
                Player.GetComponent<AtaqueGreen>().enabled = false;
                indiceGO();
            }
                else if(!morto && !jogando){
                    Player.GetComponent<MovimentoGreen>().enabled = true; 
                }
                    else if(morto && nomeCena == "GameFase2"){
                        somMorte.enabled = true;
                        somMusica.enabled = false;
                        CanvasGameOver.SetActive(true);
                        Destroy(Player);
                        indiceGO();
                    }
    }


    void indiceGO(){
        if(Input.GetKeyUp(KeyCode.D) ||  Input.GetKeyUp(KeyCode.RightArrow)){
            indice++;
        }
            else if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)){
                indice--;
            }
    
        if(indice < 0){
            indice = 1;
        }
            else if(indice > 1){
                indice = 0;
            }

        if(indice == 0){
                btnselReiniciarSel.SetActive(true);
                btnSairSel.SetActive(false);
                btnReiniciar.SetActive(false);
                btnSair.SetActive(true);
        }
            else if(indice == 1){
                btnselReiniciarSel.SetActive(false);
                btnSairSel.SetActive(true);
                btnSair.SetActive(false);
                btnReiniciar.SetActive(true);
            }
    
    
        if(Input.GetKeyUp(KeyCode.KeypadEnter) || Input.GetKeyUp(KeyCode.Return)){
            if(indice == 0){
                Time.timeScale = 1f;
                morto = false;
                    if(nomeCena == "GameFase 1"){
                        SceneManager.LoadScene("GameFase 1");
                    }
                        else if(nomeCena == "GameFase2"){
                            SceneManager.LoadScene("GameFase2");
                        }
            }
                else if(indice == 1){
                    SceneManager.LoadScene("MenuInicial");
                    Time.timeScale = 1f;
                }
        }
    }
}
