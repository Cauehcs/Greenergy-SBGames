using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posArma : MonoBehaviour
{
    public GameObject Green;
    public static bool seguir;

    public float temp, tempCabar;
    // Start is called before the first frame update
    void Start()
    {
        seguir = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(seguir)
            transform.position = Green.transform.position;
        
        if(!seguir){
            StartCoroutine("destruir");
            temp += Time.deltaTime;
            if(temp >= tempCabar){
                Destroy(this.gameObject);
                Green.GetComponent<Animator>().enabled = true;
            }
                
        }
    }

    IEnumerator destruir(){
        yield return new WaitForSeconds(2f);
    }
}
