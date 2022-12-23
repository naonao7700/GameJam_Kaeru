using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SEID
{
    GameClear,
    GameOver,
    Bubble,
    Damage,
}

public class PlayerSound : MonoBehaviour
{
    private static PlayerSound playerSound;

    [SerializeField] private AudioSource audioSource;
    public AudioClip jump;
    public AudioClip swim;
    public AudioClip damage;
    public AudioClip bubble;
    public AudioClip gameClear;
    public AudioClip gameOver;
    //public AudioClip waterUp;
    //public AudioClip waterDown;

    public void PlaySE( int id )
	{
        if (id == 0) PlaySE(jump);
        if (id == 1) PlaySE(swim);
	}

    public void PlaySE( AudioClip clip )
    {
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetAudioClip( SEID id )
	{
        switch( id )
		{
            case SEID.GameClear:  return gameClear;
            case SEID.GameOver: return gameOver;
            case SEID.Bubble: return bubble;
            case SEID.Damage: return damage;
        }
        return null;
	}

    public static void PlaySE( SEID id )
	{
        playerSound.PlaySE(playerSound.GetAudioClip(id));
	}

    // Start is called before the first frame update
    void Start()
    {
        if (playerSound == null) playerSound = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
