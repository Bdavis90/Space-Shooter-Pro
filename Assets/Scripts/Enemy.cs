using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    private float _maxX = 8f;
    private float _minX = -8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        if(transform.position.y <= -6f)
        {
            float randX = Random.Range(_minX, _maxX);
            transform.position = new Vector3(randX, 8f, 0f);
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit: " + other.tag);

        if(other.tag == "Player")
        {
            Debug.Log("Damged player");
            Destroy(gameObject);
        } else if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
