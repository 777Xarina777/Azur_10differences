using UnityEngine;
using UnityEngine.UI;

public class DifferenceClicker : MonoBehaviour
{
    public static int score = 0;
    public Text counterText;

    void Start()
    {
        score = 0;
        UpdateCounter();
    }

    public void OnDifferenceClicked()
    {
        score++;
        UpdateCounter();
        gameObject.SetActive(false); // Объект исчезает

        // Просто покажи в консоли что работает
        Debug.Log("Найдено различий: " + score);

        if (score >= 8) // Поставь 3 вместо 10 для теста
        {
            Debug.Log("ВСЕ ОТЛИЧИЯ НАШЕЛ");
        }
    }

    void UpdateCounter()
    {
        if (counterText != null)
            counterText.text = score + "/10";
    }
}