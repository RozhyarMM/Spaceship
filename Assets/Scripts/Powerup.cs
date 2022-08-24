using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private int _powerupID;
    /*
     * 0 Equals TripleShot
     * 1 Equals SpeedBoost
     * 2 Equals ShieldPowerup
     */

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * 3f * Time.deltaTime);
        if (transform.position.y < -4.5)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (_powerupID == 0) 
            {
                other.transform.GetComponent<Player>().TripleShotActive();
                Destroy(this.gameObject);
            }
            if (_powerupID == 1)
            {
                other.transform.GetComponent<Player>().SpeedBoostActive();
                Destroy(this.gameObject);
            }
            if (_powerupID == 2)
            {
                other.transform.GetComponent<Player>().ShieldActive();
                Destroy(this.gameObject);
            }
        }
    }
}
