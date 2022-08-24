using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Class Variables
    [SerializeField]
    private float _enemySpeed = 2f;
    private GameObject _enemy;
    [SerializeField]
    private GameObject _explosion;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Move Enemy 4 M/s
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);
        if (transform.position.y < -6f)
        {
            //Instantiate(_enemy, new Vector3(Random.Range(9f, -9f), Random.Range(9f, 25f), 0), Quaternion.identity);
            transform.position = new Vector3(Random.Range(9f, -9f), Random.Range(9f, 15f), 0);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

         if (other.tag == "Player")
        {
            other.GetComponent<Player>().Damage();
            Destroy(this.gameObject);
            Instantiate(_explosion, transform.position, Quaternion.identity);
        }
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            Instantiate(_explosion, transform.position, Quaternion.identity);
            Player.AddScore(10);

        }
    }

}
