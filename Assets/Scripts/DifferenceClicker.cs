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
        gameObject.SetActive(false); // ������ ��������

        // ������ ������ � ������� ��� ��������
        Debug.Log("������� ��������: " + score);

        if (score >= 8) // ������� 3 ������ 10 ��� �����
        {
            Debug.Log("��� ������� �����");
        }
    }

    void UpdateCounter()
    {
        if (counterText != null)
            counterText.text = score + "/10";
    }
}