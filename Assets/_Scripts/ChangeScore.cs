using UnityEngine;
using TMPro;
using UnityEngine.Localization;

public class ChangeScore : MonoBehaviour
{
    [SerializeField] private LocalizedString localStringScore;
    [SerializeField] private TextMeshProUGUI textComp;

    private int score = 0;

    private void Start()
    {
        UpdateText(localStringScore.GetLocalizedString());
    }

    private void OnEnable()
    {
        localStringScore.StringChanged += UpdateText;
    }

    private void OnDisable()
    {
        localStringScore.StringChanged -= UpdateText;
    }

    private void UpdateText(string value)
    {
        textComp.text = value;
    }

    // Call this method to update the score and text
    public void UpdateScore(int newScore)
    {
        score = newScore;
        localStringScore.Arguments = new object[] { score };
        localStringScore.RefreshString();
    }
}
