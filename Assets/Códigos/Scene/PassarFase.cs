using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PassarFase : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)){
            SceneManager.LoadScene("GameFase1");
        }
        if(Time.timeSinceLevelLoad>37f)
        {
            SceneManager.LoadScene("GameFase1");
        }
    }
}
