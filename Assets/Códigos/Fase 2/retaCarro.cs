using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retaCarro : MonoBehaviour
{  
    public float speed = 0.035f;
    public bool passarFase;
    public AudioSource SomFase;
    public GameObject CutsceneFinal, pularCutscene, camera, Green, cabeçaGreen;
    public float temp, tempCutscene;
 
    void Update(){
        if(passarFase){
           SomFase.enabled = false;
           temp += Time.deltaTime;
           
           Destroy(Green);
           CutsceneFinal.SetActive(true);
           pularCutscene.SetActive(true);
           camera.transform.position = new Vector2(30f, 30f);

           if(temp >= tempCutscene || Input.GetKeyUp(KeyCode.Escape)){
               SceneManager.LoadScene("MenuInicial");
           }
        }

        if(transform.position.y <= 7){
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        if(transform.position.y >= 6.9f){
            passarFase = true;
        }
    }
}
