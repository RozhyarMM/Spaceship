using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject _scoreObj;
    public Image _livesImage;
    public Sprite[] _liveSprites;

    public GameObject _GameOver;
    public GameObject _RestartBtn;
    // Start is called before the first frame update
    void Start()
    {

        _scoreObj.GetComponent<Text>().text = "Score: " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        _scoreObj.GetComponent<Text>().text = "Score: " + Player._Score.ToString();
    }
    public void CurrentLives(int lives)
    {
        _livesImage.sprite = _liveSprites[lives];
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void GameOver()
    {
        _GameOver.SetActive(true);
    }
}
