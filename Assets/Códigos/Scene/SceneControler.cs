using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneControler : MonoBehaviour
{
        public AudioSource Som;
        public AudioClip fxGeral;
        public AudioClip fxSair;
        public GameObject Canvas;

        public void ClickPlay()
        {
        Som.clip = fxGeral;
        Som.Play();
        SceneManager.LoadScene("CutsceneInicial");
        }
       
        public void ClickRestartF2()
        {
           Som.clip = fxGeral;
           Som.Play();
           SceneManager.LoadScene("GameFase2"); 
           Time.timeScale = 1f;
        }

         public void ClickRestartF1()
        {
           Som.clip = fxGeral;
           Som.Play();
           SceneManager.LoadScene("GameFase1"); 
           Time.timeScale = 1f;
        }

         public void ClickRestartF3()
        {
           Som.clip = fxGeral;
           Som.Play();
           SceneManager.LoadScene("GameFase3"); 
           Time.timeScale = 1f;
        }

        public void VoltarJogar(){
            Som.clip = fxGeral;
            Som.Play();
            Canvas.SetActive(false);
            Time.timeScale = 1f;    
        }

        public void Menu(){
            Som.clip = fxGeral;
            Som.Play();
            SceneManager.LoadScene("Menu");
            Time.timeScale = 1f;
        }

        public void ClickOpcoes(){
            SceneManager.LoadScene("Opções");
        }

        public void ClickExit()
        {
            Som.clip = fxSair;
            Som.Play();
            Application.Quit();
        }
        void OnTriggerEnter2D(Collider2D col)
        {
            if(col.tag == "Player"){
                SceneManager.LoadScene("GameFase2");
            }
            
        }

}
