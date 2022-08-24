using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour


{
    [SerializeField]
    private GameObject _Shield;
    [SerializeField] // to make all private variables available in unity editor without making them public
    private float _speed = 4.0f;
    [SerializeField]
    private float _speedboostMultiplier = 2.5f;
    [SerializeField]
    private GameObject _laserprefab;
    [SerializeField]
    private float _fireCooldown = 0.15f;
    private float _fireReady = 0f;

    private bool isTripleShot = false;
    private bool isShieldActive = false;
   [SerializeField]
    private GameObject _tripleShot;

    [SerializeField]
    private int _lives = 3;


    public static int _Score;

    public UIManager _UIManager;

    private SpawnManager _spawnManager;




    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        if (_spawnManager == null)
        {
            Debug.Log("Spawn Mangaer is Null");
        }
        _UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();

    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > _fireReady)
            {
                Fire();
            }
        }
    }

    void CalculateMovement()
    {

        float _HorizontalInput = Input.GetAxis("Horizontal"); //hooks left and right movement to A,D and left & right Arrow keys
        float _VerticalInput = Input.GetAxis("Vertical"); //hooks up and down movement to W,S and up & down Arrow keys

        //Moves the player based on the input variables above and speed variable in the class
        Vector3 _direction = new Vector3(_HorizontalInput, _VerticalInput, 0);
        transform.Translate(_direction * _speed * Time.deltaTime); // deltaTime converts frame times to realtime

        //Limit player to not be able to move outside the window

        if (transform.position.y < -3.8)
        {
            transform.position = new Vector3(transform.position.x, -3.8f, 0);
        }
        else if (transform.position.y > 5.8)
        {
            transform.position = new Vector3(transform.position.x, 5.8f, 0);
        }

        if (transform.position.x < -9)
        {
            transform.position = new Vector3(9f, transform.position.y, 0);
        }
        else if (transform.position.x > 9)
        {
            transform.position = new Vector3(-9f, transform.position.y, 0);
        }
    }

    void Fire()
    {
        //if space key is pressed shoot
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > _fireReady && isTripleShot)
            {
                _fireReady = Time.time + _fireCooldown;
                Vector3 _laserPosition = new Vector3(transform.position.x, transform.position.y + 0.8f, 0);
                Instantiate(_tripleShot, _laserPosition, Quaternion.identity);
            }
             else if (Time.time > _fireReady)
            {
                _fireReady = Time.time + _fireCooldown;
                Vector3 _laserPosition = new Vector3(transform.position.x, transform.position.y + 0.8f, 0);
                Instantiate(_laserprefab, _laserPosition, Quaternion.identity);
            }
        }
    }

    public void Damage()
    {
        if (isShieldActive)
        {
            isShieldActive = false;
            _Shield.SetActive(false);
            return;
        }
        _lives--;
        _UIManager.CurrentLives(_lives);
        if (_lives == 0)
        {
            _spawnManager.onPlayerDeath();
            Destroy(this.gameObject);
            _UIManager.GameOver();
        }
    }

    public void TripleShotActive()
    {
        isTripleShot = true;
        StartCoroutine(TripleshotDeactive());
    }
    public void ShieldActive()
    {
        isShieldActive = true;
        _Shield.SetActive(true);
        StartCoroutine(ShieldDeactive());
    }
    public void SpeedBoostActive()
    {
        _speed *= _speedboostMultiplier;
        StartCoroutine(SpeedBoostDeactive());
    }

    IEnumerator TripleshotDeactive()
    {
        yield return new WaitForSeconds(5f);
        isTripleShot = false;
    }
    IEnumerator ShieldDeactive()
    {
        yield return new WaitForSeconds(10f);
        _Shield.SetActive(false);
        isShieldActive = false;
    }

    IEnumerator SpeedBoostDeactive()
    {
        yield return new WaitForSeconds(5f);
        _speed /= _speedboostMultiplier;
    }


    public static void AddScore(int _points) 
    {
        _Score += _points;    
    }



} //Class close bracket

