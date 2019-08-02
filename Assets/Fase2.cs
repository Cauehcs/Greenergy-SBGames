using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fase2 : MonoBehaviour
{
    public AudioSource somMusica, portaSom;
    public GameObject Player, camera, cameraPlugin, canvasLife, canvasCD;
    public float tempCutscene,temp;
    public bool entrou;
    // Start is called before the first frame update
    void Start()
    {
      portaSom = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(entrou){
            temp += Time.deltaTime;
            Destroy(Player);
            portaSom.enabled = true;
            canvasCD.SetActive(false);
            canvasLife.SetActive(false);
            cameraPlugin.SetActive(false);
            camera.transform.position = new Vector2(10f, -15f);
            if(temp >= tempCutscene){
                SceneManager.LoadScene("GameFase2");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player"){
         
            somMusica.enabled = false;
            entrou = true;
        }
    }
}
