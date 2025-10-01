using TMPro;
using UnityEngine;
using System.Collections;

public class VideoTimer : MonoBehaviour
{
    [Header("Settings")]
    public float totalTime = 30f;        // Общее время таймера
    public float blinkStartTime = 5f;    // Когда начать мигать
    public Color normalColor = Color.white;
    public Color warningColor = Color.red;

    [Header("References")]
    public TextMeshProUGUI timerText;

    private float currentTime;
    private bool isBlinking = false;

    void Start()
    {
        currentTime = totalTime;
        UpdateTimerDisplay();
        StartCoroutine(TimerCountdown());
    }

    IEnumerator TimerCountdown()
    {
        while (true) // Бесконечный цикл как в рекламе
        {
            // Обратный отсчет
            currentTime -= Time.deltaTime;

            // Проверка на мигание
            if (currentTime <= blinkStartTime && !isBlinking)
            {
                isBlinking = true;
                StartCoroutine(BlinkTimer());
            }

            // Сброс таймера
            if (currentTime <= 0)
            {
                currentTime = totalTime;
                isBlinking = false;
                timerText.color = normalColor; // Сбрасываем цвет
            }

            UpdateTimerDisplay();
            yield return null;
        }
    }

    void UpdateTimerDisplay()
    {
        // Форматирование времени: 30, 29, 28...
        timerText.text = "0:0" + Mathf.CeilToInt(currentTime).ToString();

        // Добавляем "с" в конце если нужно: "30с"
        // timerText.text = Mathf.CeilToInt(currentTime).ToString() + "с";
    }

    IEnumerator BlinkTimer()
    {
        while (currentTime <= blinkStartTime && currentTime > 0)
        {
            // Мигание между красным и белым
            timerText.color = (timerText.color == normalColor) ? warningColor : normalColor;
            yield return new WaitForSeconds(0.5f); // Скорость мигания
        }

        // Возвращаем нормальный цвет
        timerText.color = normalColor;
        isBlinking = false;
    }

    // Для ручного управления (опционально)
    public void ResetTimer()
    {
        currentTime = totalTime;
        isBlinking = false;
        timerText.color = normalColor;
    }

    public void SetTimer(float newTime)
    {
        totalTime = newTime;
        currentTime = newTime;
    }
}