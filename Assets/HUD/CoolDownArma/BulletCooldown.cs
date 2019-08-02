using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BulletCooldown : MonoBehaviour
{
    Image cooldownBar;
    public float cooldown;
    public float tempo;
    float timeLeft;
    bool isCooldown;
    bool aa;
    // Start is called before the first frame update
    void Start()
    {
        cooldownBar = GetComponent<Image>();
        aa = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            isCooldown = true;
        }
        if(isCooldown && cooldownBar.fillAmount != 0 && aa == false)
        {
            cooldownBar.fillAmount -= 1 / cooldown * Time.deltaTime;
            if(cooldownBar.fillAmount == 0)
            {
                aa = true;
            }
        }
        else if(cooldownBar.fillAmount >= 0 && aa == true)
            { 
                cooldownBar.fillAmount += tempo;
                if(cooldownBar.fillAmount == 1)
                {
                isCooldown = false;
                aa = false;
                }
            }
    }
}
