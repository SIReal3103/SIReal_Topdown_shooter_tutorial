using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredFlash : MonoBehaviour
{
    [SerializeField] private Material flashMaterial;
    [SerializeField] private float duration;
    [SerializeField] SpriteRenderer spriteRenderer;

    private Material originalMaterial;
    private Coroutine flashRoutine;

    void Start()
    {
        originalMaterial = spriteRenderer.material;
        flashMaterial = new Material(flashMaterial);
    }

    public void Flash(Color color)
    {
        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }

        flashRoutine = StartCoroutine(FlashRoutine(color));
    }

    private IEnumerator FlashRoutine(Color color)
    {
        spriteRenderer.material = flashMaterial;

        flashMaterial.color = color;

        yield return new WaitForSeconds(duration);

        spriteRenderer.material = originalMaterial;

        flashRoutine = null;
    }
}
