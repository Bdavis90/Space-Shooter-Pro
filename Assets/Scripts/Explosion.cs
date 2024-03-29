using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private AudioClip _explosionAudioClip;
    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        if(!_audioSource)
        {
            Debug.LogError("AudioSource is NULL");
        }

        _audioSource.clip = _explosionAudioClip;
        _audioSource.Play();
        Destroy(gameObject, 3f);
    }

}
