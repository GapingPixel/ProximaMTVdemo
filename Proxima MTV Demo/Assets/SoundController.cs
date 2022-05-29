using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    static AudioSource audioSrc;
    static AudioClip playerHitSound, playerDeathSound, bossHitSound, takePickUpSound, playerShootSound, enemyDieSound;

    public AudioClip test;
    // Start is called before the first frame update
    void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
        playerHitSound = Resources.Load<AudioClip>("Sounds/GradiusSounds/PlayerHit");
        playerDeathSound = Resources.Load<AudioClip>("Sounds/GradiusSounds/PlayerDeath");
        bossHitSound = Resources.Load<AudioClip>("Sounds/GradiusSounds/TakeDMG");
        takePickUpSound = Resources.Load<AudioClip>("Sounds/GradiusSounds/TakePickUp");
        bossHitSound = Resources.Load<AudioClip>("Sounds/GradiusSounds/TakeDMG");
        playerShootSound = Resources.Load<AudioClip>("Sounds/GradiusSounds/PlayerShoot");
        enemyDieSound = Resources.Load<AudioClip>("Sounds/GradiusSounds/EnemyDie");
        
    }
    
    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "PlayerDeath":
                audioSrc.PlayOneShot(playerDeathSound);
                break;
            
            case "PlayerHit":
                audioSrc.PlayOneShot(playerHitSound);
                break;
            
            case "PlayerShoot":
                audioSrc.PlayOneShot(playerShootSound);
                break;
            
            case "takeDMG":
                audioSrc.PlayOneShot(bossHitSound);
                break;
            
            case "EnemyDie":
                audioSrc.PlayOneShot(enemyDieSound);
                break;
            
            case "PickUp":
                audioSrc.PlayOneShot(takePickUpSound);
                break;
        }
    }
}
