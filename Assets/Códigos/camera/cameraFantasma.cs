using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFantasma : MonoBehaviour
{

   /// Nesse script há o código da movimentação e animação

    //Variável com velocidade de força nula
    public Vector2 speedNulo;

    //Variável da velocidade - Andar
    [SerializeField]
    public float speedAtual;

    //Variável padrão de velocidade
    public float VelocidadePad;

    //Variável Base da velocidade - Andar
    [SerializeField]
    public float speedAndandoBaseX;

    [SerializeField]
    public float speedAndandoBaseY;  
    public bool paused;
    public GameObject telaPausa;
   
    void Start()
    {
      
    }


    void Update()
    {
        //Métodos 
        movimento();
    }

    public void movimento()
    {

        // método de movimentação do personagem

            if (Input.GetKeyDown(KeyCode.W))
        {
            speedAtual = VelocidadePad;
            speedAndandoBaseX = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector2(speedAndandoBaseX, speedAtual);
           
        }

            if (Input.GetKeyDown(KeyCode.S))
        {
            speedAtual = VelocidadePad;
            speedAndandoBaseX = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector2(speedAndandoBaseX, -speedAtual);
              
        }

            if (Input.GetKeyDown(KeyCode.A))
        {
            speedAtual = VelocidadePad;
            speedAndandoBaseY = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speedAtual, speedAndandoBaseY);
        }   

            if(Input.GetKeyDown(KeyCode.D))
        {   
            speedAtual = VelocidadePad;
            speedAndandoBaseY = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector2(speedAtual, speedAndandoBaseY);
        }

            if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
      
    
    }    
}
