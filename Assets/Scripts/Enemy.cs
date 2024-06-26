﻿using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    private float _maxX = 8f;
    private float _minX = -8f;

    private Player _player;

    private Animator _animator;
    private BoxCollider2D _boxCollider;

    [SerializeField]
    private AudioClip _explosionAudioClip;
    private AudioSource _audioSource;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        if(!_animator )
        {
            Debug.LogError("Animator is NULL");
        }

        _boxCollider = GetComponent<BoxCollider2D>();

        if (!_boxCollider)
        {
            Debug.LogError("BoxCollider is NULL");
        }

        _player = GameObject.Find("Player").GetComponent<Player>();

        if (!_player)
        {
            Debug.LogError("Player is NULL");
        }

        _audioSource = GetComponent<AudioSource>();

        if(!_audioSource)
        {
            Debug.LogError("AudioSource is NULL");
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        if (transform.position.y <= -6f)
        {
            float randX = Random.Range(_minX, _maxX);
            transform.position = new Vector3(randX, 8f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            
            if(_player)
            {
                _player.Damage();
            }

            _audioSource.clip = _explosionAudioClip;
            _audioSource.Play();
            _speed = 0;
            _animator.SetTrigger("OnEnemyDeath");
            _boxCollider.enabled = false;
            Destroy(gameObject, 2.8f);
        }
        else if (other.tag == "Laser")
        {
            
            if(_player)
            {
                _player.AddToScore();
            }
            _audioSource.clip = _explosionAudioClip;
            _audioSource.Play();
            _speed = 0;
            Destroy(other.gameObject);
            _animator.SetTrigger("OnEnemyDeath");
            _boxCollider.enabled = false;
            Destroy(gameObject, 2.8f);
        }
    }
}
