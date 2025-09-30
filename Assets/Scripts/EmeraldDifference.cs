using UnityEngine;
using System.Collections;

public class EmeraldDifference : MonoBehaviour
{
    [Header("References")]
    public SpriteRenderer circleHighlight;
    public SpriteRenderer mainSprite;
    public ParticleSystem emeraldParticles;
    public Collider2D clickCollider;

    [Header("Colors")]
    public Color emeraldColor = new Color(0.18f, 1.0f, 0.44f); // #2EFF6F
    public Color lightEmerald = new Color(0.64f, 1.0f, 0.44f); // #A2FF6F

    void Start()
    {
        // Настраиваем цвет круга
        circleHighlight.color = emeraldColor;
        circleHighlight.transform.localScale = Vector3.zero;
    }

    void OnMouseDown()
    {
        if (clickCollider.enabled)
        {
            StartCoroutine(PlayFoundEffect());
        }
    }

    IEnumerator PlayFoundEffect()
    {
        // Отключаем повторные клики
        clickCollider.enabled = false;

        // Запускаем частицы
        emeraldParticles.Play();

        // Анимация круга
        float duration = 1.0f;
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float progress = timer / duration;

            // Анимация масштаба с overshoot
            float scale = CalculateScale(progress);
            circleHighlight.transform.localScale = Vector3.one * scale;

            // Анимация альфы
            float alpha = CalculateAlpha(progress);
            Color currentColor = circleHighlight.color;
            currentColor.a = alpha;
            circleHighlight.color = currentColor;

            yield return null;
        }

        // Скрываем основной спрайт
        mainSprite.enabled = false;
    }

    float CalculateScale(float progress)
    {
        // Кривая с overshoot: 0 → 1.3 → 0.9 → 1.0
        if (progress < 0.2f) return progress * 6.5f; // 0 to 1.3
        if (progress < 0.4f) return 1.3f - (progress - 0.2f) * 2.0f; // 1.3 to 0.9
        if (progress < 0.7f) return 0.9f + (progress - 0.4f) * 0.33f; // 0.9 to 1.0
        return 1.0f + (progress - 0.7f) * 0.33f; // 1.0 to 1.1
    }

    float CalculateAlpha(float progress)
    {
        // Быстро появляется, медленно исчезает
        if (progress < 0.2f) return progress * 5f; // Быстрое появление
        return 1.0f - (progress - 0.2f) * 1.25f; // Медленное исчезновение
    }
}