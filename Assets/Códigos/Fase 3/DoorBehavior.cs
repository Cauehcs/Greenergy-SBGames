using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    [SerializeField] private bool desenvolvedor;
    // Start is called before the first frame update
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;
    public GameObject door5;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Porta();
    }

    void Porta()
    {
        if(desenvolvedor)
        {
            Destroy(door1);
            Destroy(door2, 1f);
            Destroy(door3, 1f);
            
        }
    }

}
