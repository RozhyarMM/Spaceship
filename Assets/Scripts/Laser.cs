using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _laserSpeed = 10f;


    // Update is called once per frame
    void Update()
    {
        Vector3 laserMovement = Vector3.up;
        transform.Translate(laserMovement * _laserSpeed * Time.deltaTime);

        if (transform.position.y >= 10)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
