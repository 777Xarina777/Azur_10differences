using TMPro;
using UnityEngine;
using System.Collections;

public class VideoTimer : MonoBehaviour
{
    [Header("Settings")]
    public float totalTime = 30f;        // ����� ����� �������
    public float blinkStartTime = 5f;    // ����� ������ ������
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
        while (true) // ����������� ���� ��� � �������
        {
            // �������� ������
            currentTime -= Time.deltaTime;

            // �������� �� �������
            if (currentTime <= blinkStartTime && !isBlinking)
            {
                isBlinking = true;
                StartCoroutine(BlinkTimer());
            }

            // ����� �������
            if (currentTime <= 0)
            {
                currentTime = totalTime;
                isBlinking = false;
                timerText.color = normalColor; // ���������� ����
            }

            UpdateTimerDisplay();
            yield return null;
        }
    }

    void UpdateTimerDisplay()
    {
        // �������������� �������: 30, 29, 28...
        timerText.text = "0:0" + Mathf.CeilToInt(currentTime).ToString();

        // ��������� "�" � ����� ���� �����: "30�"
        // timerText.text = Mathf.CeilToInt(currentTime).ToString() + "�";
    }

    IEnumerator BlinkTimer()
    {
        while (currentTime <= blinkStartTime && currentTime > 0)
        {
            // ������� ����� ������� � �����
            timerText.color = (timerText.color == normalColor) ? warningColor : normalColor;
            yield return new WaitForSeconds(0.5f); // �������� �������
        }

        // ���������� ���������� ����
        timerText.color = normalColor;
        isBlinking = false;
    }

    // ��� ������� ���������� (�����������)
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