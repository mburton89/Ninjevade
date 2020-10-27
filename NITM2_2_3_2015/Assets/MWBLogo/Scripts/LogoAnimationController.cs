﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LogoAnimationController : MonoBehaviour {

    private Image[] _allImages;
    [SerializeField] private Color _colorDim;
    [SerializeField] private Color _colorLit;
    [SerializeField] private float _secondsToWaitBeforeLit;
    [SerializeField] private AudioClip _spinClip;
    [SerializeField] private AudioClip _powerUpClip;
    [SerializeField] private AudioSource _audioSource;

    void Start ()
    {
        _allImages = FindObjectsOfType<Image>();
        foreach (Image image in _allImages)
        {
            if (image.color != Color.black)
            {
                image.color = _colorDim;
            }
        }
        StartCoroutine(LightEmUp());
        StartCoroutine(PlaySounds());
    }

    private IEnumerator LightEmUp()
    {
        yield return new WaitForSeconds(_secondsToWaitBeforeLit);
        LightUpColors();
    }

    public void LightUpColors()
    {
        foreach (Image image in _allImages)
        {
            if (image.color != Color.black)
            {
                image.DOColor(_colorLit, .5f);
            }
        }
    }

    private IEnumerator PlaySounds()
    {
        _audioSource.clip = _spinClip;
        _audioSource.Play();
        yield return new WaitForSeconds(_spinClip.length);
        _audioSource.clip = _powerUpClip;
        _audioSource.Play();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
}
