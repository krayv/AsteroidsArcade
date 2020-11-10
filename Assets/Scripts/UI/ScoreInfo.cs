using UnityEngine;
using UnityEngine.UI;
public class ScoreInfo : MonoBehaviour
{
    [SerializeField] private Text text;

    private Score score;

    private void Awake()
    {
        score = GameObject.FindGameObjectWithTag(TagsAndLayers.GameControllerTag).GetComponent<Score>();
        score.scoreValueChanged.AddListener(RefreshInfo);
        RefreshInfo(score.score);
    }

    private void RefreshInfo(int value)
    {
        text.text = value.ToString();
    }
}
