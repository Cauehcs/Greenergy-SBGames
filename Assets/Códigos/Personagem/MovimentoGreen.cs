using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoGreen : MonoBehaviour
{
     //Variável da velocidade - Andar
    public float speedAtual;

    //Variável padrão de velocidade
    public float VelocidadePad;

    //Variável Base da velocidade - Andar
    [SerializeField]
    public float speedAndandoBaseX;

    [SerializeField]
    public float speedAndandoBaseY;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        movimento();
    }
  
     public void movimento()
    {

        // método de movimentação do personagem

            if (Input.GetAxisRaw("Vertical") > 0)
        {
            speedAtual = VelocidadePad;
            speedAndandoBaseX = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector2(speedAndandoBaseX, speedAtual);
           
        }

            if (Input.GetAxisRaw("Vertical") < 0)
        {
            speedAtual = VelocidadePad;
            speedAndandoBaseX = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector2(speedAndandoBaseX, -speedAtual);
              
        }

            if (Input.GetAxisRaw("Horizontal") < 0)
        {
            speedAtual = VelocidadePad;
            speedAndandoBaseY = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speedAtual, speedAndandoBaseY);
        }   

            if(Input.GetAxisRaw("Horizontal") > 0)
        {   
            speedAtual = VelocidadePad;
            speedAndandoBaseY = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector2(speedAtual, speedAndandoBaseY);
        }

            if (!(Input.GetAxisRaw("Horizontal") < 0) && !(Input.GetAxisRaw("Horizontal") > 0) && !(Input.GetAxisRaw("Vertical") > 0) && !(Input.GetAxisRaw("Vertical") < 0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

       
      
    }
}
