using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroEnemy : MonoBehaviour
{
   //Velocidade da bala//
    public float speed;
    //Pega o Player//
    private Transform target;
    //Traduz o 'target' em Vector2//
    private Vector2 tradutor;
    //Booliana pra marcar se o tiro segue ou não//
    public bool teleguiado;
    //Tempo em que a bala continua em movimento//
    public float tempoDeVoo;
    //Direção formula//
    private Vector2 heading;
    private float distance;
    private Vector2 direction;
    void Start()
    {
        //Destroi a bala após o fim do tempo de voo//
        Destroy(this.gameObject,tempoDeVoo);
        // Pega a posição do objeto com a tag 'Player' e Converte para Vector 2 logo abaixo//
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        tradutor = new Vector2 (target.position.x,target.position.y);
        heading = target.position - transform.position;
        distance = heading.magnitude;
        direction = heading / distance;
    }

    void Update()
    {   
        //Movimento da bala//
        if(teleguiado == false){transform.Translate(direction * speed * Time.deltaTime);}
        else{transform.position = Vector2.MoveTowards(transform.position, tradutor, speed * Time.deltaTime);}
        
        if(transform.position.x == tradutor.x && transform.position.y == tradutor.y && teleguiado == false)
        {
            //Caso ele chegue no ponto alvo ele é destruido//
            Destroy(this.gameObject);
        }
        else if(transform.position.x == tradutor.x && transform.position.y == tradutor.y && teleguiado == true)
        {
            //Caso chegue a o ponto alvo, procura um novo alvo//
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            tradutor = new Vector2 (target.position.x,target.position.y);
            transform.position = Vector2.MoveTowards(transform.position, tradutor, speed * Time.deltaTime);
        }
    }
    //Caso colida com algum objeto que não tenha a tag de inimigo, é destruido// 
    void OnCollisionEnter2D(Collision2D col)
    {
       if(col.gameObject.tag != "Enemy")//Lembrar de por Enemy no inimigo :p//
       {
           Destroy(this.gameObject);
       }
    }
    
}
