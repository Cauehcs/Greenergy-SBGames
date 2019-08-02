using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracaoGreen : MonoBehaviour
{
    public GameObject Green;
    public GameObject Spawn;

    public GameObject RbotShield;
    public GameObject RbotShoot1;

    public GameObject RbotShoot2;
    void Update()
    {
        if(transform.position.y < -0.96f){
            StartCoroutine("Espera");
            Spawn.SetActive(true);
           
        }
    }

    IEnumerator Espera(){
        yield return new WaitForSeconds(1f);
    }
}
