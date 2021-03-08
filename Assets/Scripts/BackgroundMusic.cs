using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Music
{

    private AudioSource source;

    public string musicName;
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
    Music[] music;


    
    // Start is called before the first frame update
    void Start()
    {
        

        for (int i = 0; i < music.Length; i++)
        {
            GameObject _go = new GameObject("Music_" + i + "_" + music[i].musicName);
            _go.transform.SetParent(this.transform);
            music[i].SetSource(_go.AddComponent<AudioSource>());
            
        }

        var rand = Random.Range(0, music.Length-1);

        music[rand].Play();

    }

    public void PlaySound(string _name)
    {
        for (int i = 0; i > music.Length; i++)
        {
            if (music[i].musicName == _name)
            {
                music[i].Play();
                return;
            }
        }

    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
