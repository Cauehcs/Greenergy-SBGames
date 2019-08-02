using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pigMoviment : MonoBehaviour
{
    public float velAvanco;
    public Rigidbody2D rb;

    void Start()  {
    transform.position = new Vector2(-4f, 0f);    
    rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if(Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W)){
            rb.velocity = Vector2.up * velAvanco;
        }
    }
}

