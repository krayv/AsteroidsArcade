using UnityEngine;

[RequireComponent(typeof(AbstractEntity))]
public class Scorable : MonoBehaviour
{
    [SerializeField] private int scoreForThis;

    private Score score;

    private void Awake()
    {
        score = GameObject.FindGameObjectWithTag(TagsAndLayers.GameControllerTag).GetComponent<Score>();
        AbstractEntity abstractEntity = GetComponent<AbstractEntity>();
        abstractEntity.onDestroy.AddListener(OnDeath);
    }

    private void OnDeath(GameObject gameObject)
    {
        score.score = score.score + scoreForThis;
    }
}
