using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptMenu : MonoBehaviour
{
    public void btnIniciar(){
        anim.SetBool("IrSelPersona", true);
    }

    /*Posições de cada menu (Plano cartesiano (x,y))
    Abertura (0,0)
    MenuInicial (50,0)
    Opções (50,-40)
    SelecionarModoDeJogo (50, 40)
    Créditos (100, 0)
    */

    //Componentes possíveis
    public Animator anim, creditos;
    public GameObject cutsceneInicial;
    public AudioSource musicaCredito;

    //Váriveis de posição - Menus
    public Vector3 Abertura;
    public Vector3 MenuInicial;
    public Vector3 Opcoes;
    public Vector3 SelecionarModoDeJogo;
    public Vector3 Creditos;

    //Váriaveis sobre controle de estado - Onde o Player está, referente ao menu.
    public bool bAbertura, bMenuInicial, bSelPersona, bCreditos, bCutsceneHist;
    public bool cabouCredito;

    //Váriaveis de índice de menu.
    public int indiceMenu, indiceSelPersona;
    public GameObject selMenuJogar, selMenuCreditos, selMenuSair, GPSelecao, BG, pularCutscene;

    //Váriaveis de tempo
    public float temp, tempCredAcabar;
    public float tempCutscene, tempCreditos;
    

    void Start(){
        //Estado de controle inicial
        bAbertura = true;
        indiceMenu = 0;

        //Coleta de componente
        anim = GetComponent<Animator>();
        cutsceneInicial.SetActive(false);

        //MenuInicial - Seleção
        selMenuJogar.SetActive(false);
        selMenuCreditos.SetActive(false);
        selMenuSair.SetActive(false);
   }

    void FixedUpdate() {
        Cursor.visible = false;
    }
    void Update(){
        
        trocaDeMenu();
        
        if(bSelPersona)
                selIndex();
    
        if(bCutsceneHist){
            GetComponent<AudioSource>().Pause();
            
            temp += Time.deltaTime;
            
            GPSelecao.SetActive(false);
            BG.SetActive(false);
            pularCutscene.SetActive(true);

            if(temp >= tempCutscene || Input.GetKeyUp(KeyCode.Escape)){
                SceneManager.LoadScene("GameFase 1");
            }
        }
    }

    void trocaDeMenu(){
        if(bAbertura)
            aberturaGame();

        if(bMenuInicial){
            menuIndex();
            cabouCredito = false;
        }
            
        
        if(bSelPersona){    
            if(Input.GetKeyUp(KeyCode.Escape)){
                anim.SetBool("irSelPersona", false);
                anim.SetBool("irMenuInicial", true);
            }
        }
        
        if(bCreditos){
            GetComponent<AudioSource>().Pause();
            creditos.enabled = true;
            musicaCredito.enabled = true;
            
            tempCredAcabar += Time.deltaTime;
            
            if(tempCredAcabar >= tempCreditos)
                cabouCredito = true;

             if(cabouCredito){
              anim.SetBool("irCreditos", false);   
              anim.SetBool("irMenuInicial", true); 
              GetComponent<AudioSource>().Play();
              tempCredAcabar = 0;
              creditos.enabled = false;
              musicaCredito.enabled = false;  
            }
        }
    }

    void aberturaGame(){
        transform.position = new Vector3(0, 0, transform.position.z);
            if(Input.anyKey && !Input.GetMouseButton(0) && !Input.GetMouseButton(1) && !Input.GetMouseButton(2)){
                    anim.SetBool("irMenuInicial", true);
            }       
    }

    void menuIndex(){
        if(Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)){
            indiceMenu++;
        }
            else if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)){
                indiceMenu--;
            }
                else if(Input.GetKeyUp(KeyCode.KeypadEnter) || Input.GetKeyUp(KeyCode.Return)){
                    if(indiceMenu == 0){
                        anim.SetBool("irSelPersona", true);
                        anim.SetBool("irMenuInicial", false);
                    }
                    if(indiceMenu == 1){
                        anim.SetBool("irCreditos", true);   
                        anim.SetBool("irMenuInicial", false);
                    }
                    if(indiceMenu == 2){
                        Application.Quit();
                    }
                }
        
        if(indiceMenu == 3){
            indiceMenu = 0;
        }
            else if(indiceMenu == -1){
                indiceMenu = 2;
            }

        if(indiceMenu == 0){
            selMenuJogar.SetActive(true);
            selMenuCreditos.SetActive(false);
            selMenuSair.SetActive(false);
        }
            else if(indiceMenu == 1){
                selMenuJogar.SetActive(false);
                selMenuCreditos.SetActive(true);
                selMenuSair.SetActive(false);
            }
                else if(indiceMenu == 2){
                    selMenuJogar.SetActive(false);
                    selMenuCreditos.SetActive(false);
                    selMenuSair.SetActive(true);
                }

    }

    void selIndex(){
        // if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)){
        //     indiceSelPersona--;
        // }
        //     else if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)){
        //         indiceSelPersona++;
        //     }

        if(indiceSelPersona > 1){
            indiceSelPersona = 0;
        }
            else if(indiceSelPersona < 0){
                indiceSelPersona = 0;
            }
        
        if(indiceSelPersona == 0){
            if(Input.GetKeyUp(KeyCode.KeypadEnter) || Input.GetKeyUp(KeyCode.Return)){
                cutsceneInicial.SetActive(true);
                bCutsceneHist = true;
            }
        }
    }
}
   


