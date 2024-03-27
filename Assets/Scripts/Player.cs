using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _nextFire = 0f;
    [SerializeField ]
    private int _lives = 3;
    private SpawnManager _spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        transform.position = new Vector3(0, 0, 0);

        if(!_spawnManager)
        {
            Debug.LogError("The SpawnManager is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        FireLaser();

    }

    private void FireLaser()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
        {
            _nextFire = Time.time + _fireRate;
            Instantiate(_laserPrefab, new Vector3(transform.position.x, transform.position.y + .8f, 0), Quaternion.identity);
        }
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * _speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.5f, 0), 0);

        if (transform.position.x >= 12f)
        {
            transform.position = new Vector3(-12f, transform.position.y, 0);
        }
        else if (transform.position.x <= -12f)
        {
            transform.position = new Vector3(12f, transform.position.y, 0);
        }
    }

    public void Damage()
    {
        _lives--;

        if (_lives <= 0)
        {
            _spawnManager.OnPLayerDeath();
            Destroy(gameObject);
        }
    }

}
