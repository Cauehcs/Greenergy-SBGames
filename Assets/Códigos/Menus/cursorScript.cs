using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorScript : MonoBehaviour
{
    private SpriteRenderer render;
    public Sprite CursorClickado;
    public Sprite CursorPadrao;
    public Sprite Vazio; 

   public bool abertura;

   void Start()
   {
       Cursor.visible = false;
       render = GetComponent<SpriteRenderer>();

   }

   void Update()
   {
        //abertura = ScriptMenu.bAbertura;

        Cursor.visible = false;
       
       if(abertura){
           render.sprite = Vazio;
       }

        if(!abertura){
            render.sprite = CursorPadrao;

            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = cursorPos + new Vector2(0.3f, 0.25f);

            if(Input.GetMouseButtonDown(0)){
                render.sprite = CursorClickado;
            }
            else if(Input.GetMouseButtonUp(0)){
                render.sprite = CursorPadrao;
            }
        }
   }
}



