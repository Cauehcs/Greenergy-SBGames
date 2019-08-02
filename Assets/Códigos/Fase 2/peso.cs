using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peso : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private float deslocaPoLado;
    public const string LAYER_NAME = "BackGround";
    public int sortingOrdem = 1;
    private SpriteRenderer sprite;
    private float grandau = 0.115f;
    
    void Start(){
      speed = speed + Time.timeSinceLevelLoad/10;
      deslocaPoLado = deslocaPoLado + Time.timeSinceLevelLoad/50;
      grandau = grandau + Time.timeSinceLevelLoad/1000;
    }

    public IEnumerator ComecaaAnda(){
        yield return new WaitForSeconds(2f);
        sprite = GetComponent<SpriteRenderer>();

        if (sprite){
            sprite.sortingOrder = sortingOrdem;
            sprite.sortingLayerName = LAYER_NAME;
        }
    
        Move();
    }

    void Update(){

        transform.Translate(Vector2.up * 0.4f * Time.deltaTime);
        StartCoroutine(ComecaaAnda());
    }

    public void Move(){
        transform.Translate(Vector2.up * -speed * Time.deltaTime);
        transform.localScale += new Vector3(grandau, grandau);

        if(transform.position.x > 0){
            transform.Translate(Vector2.right * deslocaPoLado * Time.deltaTime);
        } else if(transform.position.x < 0){
            transform.Translate(Vector2.right * -deslocaPoLado * Time.deltaTime);
        }

        if(transform.position.y < -10f){
            Destroy(this.gameObject);
        }
    }    
}

        

