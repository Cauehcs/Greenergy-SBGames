using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour
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
        cameraPrivando();
    }
    
    private void cameraPrivando()
    {
        posx = Personagem.transform.position.x;
        posy = Personagem.transform.position.y;
        
        //Camera sendo privada no eixo X
        //if (posx <= 2.79f && posx >= -2.95f)
        //{
            camPosx = posx;

        //}

        //Camera sendo privada no eixo Y
        //if (posy <= 1.91f && posy >= -1.54f)
        //{
            camPosy = posy;

        //}
        transform.position = new Vector3(camPosx, camPosy, Camera.main.transform.position.z);
    }
}
