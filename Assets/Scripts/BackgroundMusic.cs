using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class Sound to be shared among all objects that play any sound

[System.Serializable]
public class Sound
{

    private AudioSource source;

    public string soundName;
    public AudioClip clip;

    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
    }

    public void Play()
    {
        source.Play();
    }

}


public class BackgroundMusic : MonoBehaviour
{
    [SerializeField]
    Sound[] musics;


    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < musics.Length; i++)
        {
            GameObject _go = new GameObject("Music_" + i + "_" + musics[i].soundName);
            _go.transform.SetParent(this.transform);
            musics[i].SetSource(_go.AddComponent<AudioSource>());
            
        }

        var rand = Random.Range(0, musics.Length-1);
        musics[rand].Play();

    }



    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
