using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BackgroundMusic : MonoBehaviour
{
    [SerializeField]
    Sounds[] musics;

    Sounds soundScript = new Sounds();

    // Start is called before the first frame update
    void Start()
    {

        soundScript.LoadSounds(musics);
        soundScript.PlayRandomSound(musics);

    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
