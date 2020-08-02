using UnityEngine;
using UnityEngine.UI;

namespace GameState
{
    public class ScoreManager : MonoBehaviour
    {
        private int _score;

        [SerializeField]
        private Text scoreText;
        [SerializeField]
        private Text highScoreText;
        // Start is called before the first frame update
        void Start()
        {
            _score = 0;
            scoreText.text = _score.ToString();
            highScoreText.text = GameStateData.HighScore.ToString();
        }

        // Update is called once per frame
        void Update()
        {
            if (!GameStateData.GameOver)
            {
                _score += (int)(Time.deltaTime * 100);
                scoreText.text = _score.ToString();
                if (GameStateData.HighScore < _score)
                {
                    GameStateData.HighScore = _score;
                    highScoreText.text = GameStateData.HighScore.ToString();
                }
            }
        }
    }
}
