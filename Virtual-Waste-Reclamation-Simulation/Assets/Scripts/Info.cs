using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    public TextMeshProUGUI info;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        info.text = "";
        image = GetComponentInChildren<Image>();
    }

    public void changeInfo(string info)
    {
        this.info.text = info;
    }

    public void changeInfo(string info, Color c)
    {
        this.info.faceColor = c;
        this.info.text = info;
    }

    public void changeSprite(Sprite sprite)
    {
        image.sprite = sprite;
    }
}
