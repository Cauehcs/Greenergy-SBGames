using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class praquatro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(transform.position.z<=0)
        {
        transform.position = new Vector3(transform.position.x,transform.position.y, 6.2f); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z<=0)
        {
        transform.position = new Vector3(transform.position.x,transform.position.y, 6.2f); 
        }
    }
}
