using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REstartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        Application.LoadLevel("Main Menu"); 
    }
}
