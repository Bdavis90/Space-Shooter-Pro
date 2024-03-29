using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    private float _maxX = 8f;
    private float _minX = -8f;

    private Player _player;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        if(!_animator )
        {
            Debug.LogError("Animator is NULL");
        }
        _player = GameObject.Find("Player").GetComponent<Player>();

        if (!_player)
        {
            Debug.LogError("Player is NULL");
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

            _speed = 0;
            _animator.SetTrigger("OnEnemyDeath");
            Destroy(gameObject, 2.8f);
        }
        else if (other.tag == "Laser")
        {
            
            if(_player)
            {
                _player.AddToScore();
            }
            _speed = 0;
            Destroy(other.gameObject);
            _animator.SetTrigger("OnEnemyDeath");
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject, 2.8f);
        }
    }
}
