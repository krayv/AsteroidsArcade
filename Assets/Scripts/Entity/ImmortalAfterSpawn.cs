using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class ImmortalAfterSpawn : MonoBehaviour
{
    [SerializeField] private float immortalTime = 3f;
    [SerializeField] private float blinkDelay = 0.5f;

    private float currentImmortalTime;
    private float currentBlinkDelay;
    private Player player;
    private MeshRenderer currentRenderer;
    void Start()
    {
        currentImmortalTime = immortalTime;
        currentRenderer = GetComponent<MeshRenderer>();
        player = GetComponent<Player>();
        StartCoroutine(StartImmortal());
    }
    
    private IEnumerator StartImmortal()
    {
        player.isCanBeDestroyed = false;
        Color startColor = currentRenderer.material.color;
        while (currentImmortalTime > 0f)
        {
            currentImmortalTime -= Time.deltaTime;
            if(currentBlinkDelay <= 0f)
            {
                if(currentRenderer.material.color.a == 0f)
                {
                    currentRenderer.material.color = new Color(startColor.r, startColor.g, startColor.b, 1f);
                }
                else
                {
                    currentRenderer.material.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
                }              
                currentBlinkDelay = blinkDelay;
            }
            else
            {
                currentBlinkDelay -= Time.deltaTime;
            }
            yield return null;
        }
        currentRenderer.material.color = startColor;
        player.isCanBeDestroyed = true;
    }



}
