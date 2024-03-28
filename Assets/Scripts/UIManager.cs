using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _gameoverText;
    [SerializeField]
    private Sprite[] _liveSprites;
    [SerializeField]
    private Image _livesImg;

    // Start is called before the first frame update
    void Start()
    {
        _gameoverText.gameObject.SetActive(false);
        _livesImg.sprite = _liveSprites[3];
        _scoreText.text = "Score: 0";
    }

    public void UpdateScore(int score)
    {
        _scoreText.text = "Score: " + score;
    }

    public void UpdateLives(int currentLives)
    {
        _livesImg.sprite = _liveSprites[currentLives];
        if (currentLives <= 0)
        {
            _gameoverText.gameObject.SetActive(true);
            StartCoroutine(FlickerGameOverText());
        }
    }

    private IEnumerator FlickerGameOverText()
    {
        while (true)
        {
            _gameoverText.gameObject.SetActive(true);
            yield return new WaitForSeconds(.5f);
            _gameoverText.gameObject.SetActive(false);
            yield return new WaitForSeconds(.5f);
        }
    }
}
