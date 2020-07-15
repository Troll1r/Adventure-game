using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCam : MonoBehaviour
{
    public GameObject TPC;
    public GameObject FPC;
    public bool SwitchCam;
    
    void Start() 
    {
        SwitchCam = true;
        

    }

    void Update()
    {
        if (Input.GetKeyUp("c"))
        {

            if (SwitchCam == false)
                SwitchCam = true;
            else if (SwitchCam == true)
                SwitchCam = false;
        }

        if (SwitchCam == false)
        {
            TPC.SetActive(true);
            FPC.SetActive(false);
        }
        if (SwitchCam == true)
        {
            TPC.SetActive(false);
            FPC.SetActive(true);
        }
    }
}
