using UnityEngine;
using UnityEngine.Events;
public class Score : MonoBehaviour
{
    private int _score;

    public UnityEvent<int> scoreValueChanged;

    public int score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            scoreValueChanged.Invoke(_score);
        }
    }
    
}
