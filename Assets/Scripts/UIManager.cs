using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _gameoverText;
    [SerializeField]
    private Text _restartText;
    [SerializeField]
    private Text _instructionsText;
    [SerializeField]
    private Sprite[] _liveSprites;
    [SerializeField]
    private Image _livesImg;

    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (!_gameManager)
        {
            Debug.LogError("GameManager is Null");
        }
        _restartText.gameObject.SetActive(false);
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
            _restartText.gameObject.SetActive(true);
            _gameManager.GameOver();
            StartCoroutine(FlickerGameOverText());
        }
    }

    public void RemoveInstructions()
    {
        _instructionsText.gameObject.SetActive(false);
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
