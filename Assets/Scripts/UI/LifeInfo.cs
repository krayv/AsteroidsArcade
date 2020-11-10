using UnityEngine;
using UnityEngine.UI;

public class LifeInfo : MonoBehaviour
{
    [SerializeField] private Text text;

    private PlayerSpawner playerSpawner;

    private void Awake()
    {
        playerSpawner = GameObject.FindGameObjectWithTag(TagsAndLayers.GameControllerTag).GetComponent<PlayerSpawner>();
        playerSpawner.lifeValueChanged.AddListener(RefreshInfo);
        RefreshInfo(playerSpawner.LifeCount);
    }

    private void RefreshInfo(int count)
    {
        text.text = "";
        while(count > 0)
        {
            text.text += "❤";
            count--;
        }
    }
}
