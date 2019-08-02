using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quebrokk : MonoBehaviour
{
    public GameObject btnResume;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(this.gameObject);
        }
    }
}
