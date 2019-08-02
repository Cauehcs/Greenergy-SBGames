using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public bool paused, jogando;
   
    public GameObject Player;
    public GameObject CanvasPause, CanvasVida, CanvasCoolDown;
    public GameObject btnVoltarSel, btnReiniciarSel, btnSairSel;
    public GameObject btnVoltar, btnReiniciar, btnSair;
    
    public int indice;

    
    // Start is called before the first frame update
    void Start()
    {
        CanvasPause.SetActive(false);
        indice = 0;
        jogando = true;
    }

    // Update is called once per frame
    void Update()
    {
        pause();
            
            if(paused){
                Player.GetComponent<MovimentoGreen>().enabled = false;
                Player.GetComponent<AtaqueGreen>().enabled = false;
                Player.GetComponent<Animator>().enabled = false;
                indicePause();
            }
                else if(!paused && !jogando){
                    Player.GetComponent<MovimentoGreen>().enabled = true; 
                    Player.GetComponent<AtaqueGreen>().enabled = true;
                    Player.GetComponent<Animator>().enabled = true;
                }
    }

    void pause()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && paused == false)
        {
            Time.timeScale = 0f;
            paused = true;
            jogando = false;
            CanvasPause.SetActive(true);
            CanvasCoolDown.SetActive(false);
            CanvasVida.SetActive(false);

        }
        else if(Input.GetKeyDown(KeyCode.Escape) && paused == true)
        {
            CanvasPause.SetActive(false);
            CanvasCoolDown.SetActive(true);
            CanvasVida.SetActive(true);
            Time.timeScale = 1f;
            paused = false;
        }
    }

    void indicePause(){
        if(Input.GetKeyUp(KeyCode.D) ||  Input.GetKeyUp(KeyCode.RightArrow)){
            indice++;
        }
            else if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)){
                indice--;
            }
    
        if(indice < 0){
            indice = 2;
        }
            else if(indice > 2){
                indice = 0;
            }

        if(indice == 0){
            btnVoltarSel.SetActive(true);
            btnVoltar.SetActive(false);
            btnReiniciarSel.SetActive(false);
            btnSairSel.SetActive(false);
            btnReiniciar.SetActive(true);
            btnSair.SetActive(true);
        }
            else if(indice == 1){
                btnVoltarSel.SetActive(false);
                btnReiniciarSel.SetActive(true);
                btnSair.SetActive(true);
                btnReiniciar.SetActive(false);
                btnVoltar.SetActive(true);
                btnSairSel.SetActive(false);
            }
                else if(indice == 2){
                    btnVoltarSel.SetActive(false);
                    btnReiniciarSel.SetActive(false);
                    btnSairSel.SetActive(true);
                    btnSair.SetActive(false);
                    btnReiniciar.SetActive(true);
                    btnVoltar.SetActive(true);
                }
    
    
        if(Input.GetKeyUp(KeyCode.KeypadEnter) || Input.GetKeyUp(KeyCode.Return)){
            if(indice == 0){
                CanvasPause.SetActive(false);
                CanvasCoolDown.SetActive(true);
                CanvasVida.SetActive(true);
                Time.timeScale = 1f;
                paused = false;
            }
                else if(indice == 1){
                    SceneManager.LoadScene("GameFase 1");
                    Time.timeScale = 1f;
                }
                    else if(indice == 2){
                        SceneManager.LoadScene("MenuInicial");
                        Time.timeScale = 1f;
                    }
        }
    }

}
