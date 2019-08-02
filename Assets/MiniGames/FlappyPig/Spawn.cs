using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private float tempoMax = 2;
    public float tempo, altura;
    public GameObject obstaculo;


    // Start is called before the first frame update
    void Start(){
        GameObject novoObstaculo = Instantiate(obstaculo);
        novoObstaculo.transform.position = transform.position + new Vector3(0, Random.Range(-altura, altura), 0);
    }

    // Update is called once per frame
    void Update(){
        tempo += Time.deltaTime;
        
        if(tempo > tempoMax){
            GameObject novoObstaculo = Instantiate(obstaculo);
            novoObstaculo.transform.position = transform.position + new Vector3(0, Random.Range(-altura, altura), 0);
            tempo = 0;
        }  
    }

}
