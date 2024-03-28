using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    private float _maxX = 8f;
    private float _minX = -8f;
    private Player _player;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
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

            Destroy(gameObject);
        }
        else if (other.tag == "Laser")
        {
            
            if(_player)
            {
                _player.AddToScore();
            }
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
