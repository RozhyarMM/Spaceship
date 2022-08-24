using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour
{
    private Animator _enemyAnim;
    // Start is called before the first frame update
    void Start()
    {
        _enemyAnim = GetComponent<Animator>();
        _enemyAnim.SetTrigger("isDestroyed");
        Destroy(this.gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
