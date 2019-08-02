using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abrirPorta : MonoBehaviour
{
    public Sprite aberta, fechada;
    public SpriteRenderer SR;
    // Start is called before the first frame update
    void Start()
    {
     SR = GetComponent<SpriteRenderer>();   
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Player" || col.tag == "Enemy"){
            SR.sprite = aberta;
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        if(col.tag == "Player" || col.tag == "Enemy"){
            SR.sprite = fechada;
        }
    }
}
