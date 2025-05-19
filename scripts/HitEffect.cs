using UnityEngine;
using System.Collections;
public class HitEffect : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float flickerDuration = 0.1f;
    public int flickerCount = 3;

    public void TriggerHitEffect()
    {
        StartCoroutine(HitFlash());
    }

    private IEnumerator HitFlash()
    {
        for (int i = 0; i < flickerCount; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(flickerDuration);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(flickerDuration);
        }
    }
}
