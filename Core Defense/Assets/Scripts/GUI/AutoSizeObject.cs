using UnityEngine;
using TMPro;

public class AutoSizeObject : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    private void Start()
    {
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        ResizeObject();
    }

    private void Update()
    {
        ResizeObject();
    }

    private void ResizeObject()
    {
        Vector2 textSize = textMeshPro.GetPreferredValues(textMeshPro.text);
        GetComponent<RectTransform>().sizeDelta = textSize;
    }
}
