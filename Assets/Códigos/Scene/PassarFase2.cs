using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PassarFase2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)){
            SceneManager.LoadScene("Contine...");
        }
        if(Time.timeSinceLevelLoad>10f)
        {
            SceneManager.LoadScene("Contine...");
        }
    }
}
