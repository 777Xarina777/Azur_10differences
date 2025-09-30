using UnityEngine;

public class LayoutManager : MonoBehaviour
{
    public Transform leftImage;
    public Transform rightImage;
    public float verSpacing = 8f; // Расстояние между картинками
    public float horSpacing = 2f; // Расстояние между картинками

    void Update()
    {
        bool isPortrait = Screen.height > Screen.width;

        if (isPortrait)
        {
            // ВЕРТИКАЛЬНО: одна под другой
            leftImage.localPosition = new Vector3(0, verSpacing, 0);
            rightImage.localPosition = new Vector3(0, -verSpacing, 0);
        }
        else
        {
            // ГОРИЗОНТАЛЬНО: рядом
            leftImage.localPosition = new Vector3(-horSpacing, 0, 0);
            rightImage.localPosition = new Vector3(horSpacing, 0, 0);
        }
    }
}