using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyprefab;
    [SerializeField]
    private GameObject _EnemyContainer;

    [SerializeField]
    private GameObject[] _powerup;

    private bool _stopSpawning = false;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
        StartCoroutine(SpawnPowerup());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 _randomPosition = new Vector3(Random.Range(9f, -9f), Random.Range(9f, 25f), 0);
            GameObject _newEnemy = Instantiate(_enemyprefab, _randomPosition, Quaternion.identity);
            _newEnemy.transform.parent = _EnemyContainer.transform;
            yield return new WaitForSeconds(2f);
        }

    }

    IEnumerator SpawnPowerup()
    {
        while (_stopSpawning == false)
        {
            yield return new WaitForSeconds(5f);
            int _randomPowerup = Random.Range(0,3);
            Instantiate(_powerup[_randomPowerup], new Vector3(Random.Range(9f, -9f), Random.Range(6f, 12f), 0), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(5f, 10f));
        }
    }

    public void onPlayerDeath()
    {
        _stopSpawning = true;
    }

}
