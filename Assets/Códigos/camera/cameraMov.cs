using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMov : MonoBehaviour
{

    public GameObject Personagem;
    private Vector3 Cam;
    private float posx;
    private float posy;
    private float camPosx;
    private float camPosy;

    // Start is called before the first frame update
    void Start()
    {
    
       Cam = transform.position - Personagem.transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {

        cameraPrive();
    }
    
    private void cameraPrive()
    {
        posx = Personagem.transform.position.x;
        posy = Personagem.transform.position.y;
        
            camPosx = posx;
            camPosy = posy;
       
        transform.position = new Vector3(camPosx, camPosy, Camera.main.transform.position.z);
    }
}
