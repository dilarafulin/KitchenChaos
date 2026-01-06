using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipesDeliveredText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private Button playAgainButton;
    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;

        if (playAgainButton != null)
        {
            playAgainButton.onClick.AddListener(() => {
                Loader.Load(Loader.Scene.GameScene);
            });
        }

        Hide();
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsGameOver())
        {
            Show();

            // Mevcut skoru göster
            int currentScore = DeliveryManager.Instance.GetSuccesfulRecipesAmount();
            recipesDeliveredText.text = currentScore.ToString();

            // YENÝ: High score'u göster
            int highScore = GameManager.Instance.GetHighScore();
            highScoreText.text = "High Score: " + highScore.ToString();

            // YENÝ: Eðer yeni rekor kýrýldýysa özel gösterim (opsiyonel)
            if (currentScore >= highScore && currentScore > 0)
            {
                highScoreText.text = highScore.ToString();

            }
            else
            {
                highScoreText.text = highScore.ToString();
            }
        }
        else
        {
            Hide();
        }
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
}
