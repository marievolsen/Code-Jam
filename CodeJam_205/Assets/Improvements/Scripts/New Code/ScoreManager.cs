using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            AccelerometerController.collectibleCount = PlayerPrefs.GetInt("Score");
        }
        SetScoreText();
    }

    public void SetScoreText()
    {
        scoreText.text = $"Score: {AccelerometerController.collectibleCount}";
        PlayerPrefs.SetInt("Score",AccelerometerController.collectibleCount);
    }
}