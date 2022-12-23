using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerSound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    public AudioClip jump;
    public AudioClip swim;
    //public AudioClip damage;
    //public AudioClip bubble;
    //public AudioClip stageClear;
    //public AudioClip waterUp;
    //public AudioClip waterDown;

    public void PlaySE( AudioClip clip )
    {
        audioSource.PlayOneShot(clip);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
