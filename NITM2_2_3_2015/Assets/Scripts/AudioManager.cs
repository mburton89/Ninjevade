using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioSource _enemyHitAudio;
    [SerializeField] private AudioSource _enemyThrowAudio;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayEnemyHitSound()
    {
        _enemyHitAudio.Play();
    }

    public void PlayEnemyThrowSound()
    {
        _enemyThrowAudio.Play();
    }
}
