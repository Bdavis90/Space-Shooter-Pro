using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private GameObject _explosionPrefab;
    [SerializeField]
    private SpawnManager _spawnManager;
    private UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if(!_uiManager )
        {
            Debug.LogError("UIManager is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * _speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Laser")
        {
            _uiManager.RemoveInstructions();
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            _spawnManager.StartSpawning();
            Destroy(collision.gameObject);
            Destroy(gameObject, .5f);
        }
    }
}
