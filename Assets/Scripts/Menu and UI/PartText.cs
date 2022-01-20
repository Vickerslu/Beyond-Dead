using UnityEngine;
using UnityEngine.UI;

public class PartText : MonoBehaviour
{
    public static int parts;
    public Text partsText;

    // Update is called once per frame
    void Update()
    {
        partsText.text = "Parts: " + parts.ToString();
    }
}