using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sumonado : MonoBehaviour
{
    public float summon = 2f;
    public float ata = 2f;
    [SerializeField]
    private GameObject azul;
    private float xxx = 0f;
    private float last = -5f;
    
    void Update()
    {   
        float a = Random.Range(0f, 3f);

        if(a <= 1){
            xxx = -2f;
        } else if(a > 1 && a <= 2){
            xxx = 2f;
        } else {
            xxx = 0f;
        }
        
        if(Time.time > summon && ata > 0.3f){
			summon = ata + Time.time;
            Instantiate(azul, transform.position = new Vector3(xxx, 5f, last), Quaternion.identity);
            ata = ata - 0.025f;
            last = last + 0.1f;
        }
    }
}
