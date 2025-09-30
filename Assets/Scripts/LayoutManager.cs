using UnityEngine;

public class LayoutManager : MonoBehaviour
{
    public Transform leftImage;
    public Transform rightImage;
    public float verSpacing = 8f; // ���������� ����� ����������
    public float horSpacing = 2f; // ���������� ����� ����������

    void Update()
    {
        bool isPortrait = Screen.height > Screen.width;

        if (isPortrait)
        {
            // �����������: ���� ��� ������
            leftImage.localPosition = new Vector3(0, verSpacing, 0);
            rightImage.localPosition = new Vector3(0, -verSpacing, 0);
        }
        else
        {
            // �������������: �����
            leftImage.localPosition = new Vector3(-horSpacing, 0, 0);
            rightImage.localPosition = new Vector3(horSpacing, 0, 0);
        }
    }
}