using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Color_Test : MonoBehaviour
{
    Texture2D replacedTexture;
    Color[] originalColors;
    SpriteRenderer mSpriteRenderer;
    //private Sprite blankSprite;
    // Start is called before the first frame update
    void Awake()
    {
        mSpriteRenderer = GetComponent<SpriteRenderer>();
        //blankSprite = gameObject.GetComponent<Sprite>();
        //blankSprite.color = Color.red;
        //var replaceTexture = new Texture2D((int)blankSprite.rect.width, (int)blankSprite.rect.height);
        Texture2D tempTexture = new Texture2D(6, 1, TextureFormat.RGBA32, false, false);
        tempTexture.filterMode = FilterMode.Point;
        
        int counter = 0;
        for (int i = 0; i < tempTexture.height; ++i)
        {
            for (int j = 0; j < tempTexture.width; ++j)
            {
                tempTexture.SetPixel(counter, 0, new Color(0.0f, 0.0f, 0.0f, 0.0f));
                counter += 1;
            }
        }
        tempTexture.Apply();
        mSpriteRenderer.material.SetTexture("_SwapTex", tempTexture);
        originalColors = new Color[tempTexture.width];
        replacedTexture = tempTexture;



        //originalColors[(int)index] = color;
        //Color Black = new Color((float)0 / 255.0f, (float)0 / 255.0f, (float)0 / 255.0f);
        //replacedTexture.SetPixel((int)0, 0, new Color((float)Random.Range(0, 255) / 255.0f, (float)Random.Range(0, 255) / 255.0f, (float)Random.Range(0, 255) / 255.0f));
        //Color Red = new Color((float)130 / 255.0f, (float)8 / 255.0f, (float)8 / 255.0f);
        replacedTexture.SetPixel((int)1, 0, new Color((float)Random.Range(0, 255) / 255.0f, (float)Random.Range(0, 255) / 255.0f, (float)Random.Range(0, 255) / 255.0f));
        //Color Green = new Color((float)68 / 255.0f, (float)172 / 255.0f, (float)73 / 255.0f);
        replacedTexture.SetPixel((int)2, 0, new Color((float)Random.Range(0, 255) / 255.0f, (float)Random.Range(0, 255) / 255.0f, (float)Random.Range(0, 255) / 255.0f));
        //Color Purple = new Color((float)172 / 255.0f, (float)33 / 255.0f, (float)132 / 255.0f);
        replacedTexture.SetPixel((int)3, 0, new Color((float)Random.Range(0, 255) / 255.0f, (float)Random.Range(0, 255) / 255.0f, (float)Random.Range(0, 255) / 255.0f));
        //Color Blue = new Color((float)118 / 255.0f, (float)172 / 255.0f, (float)222 / 255.0f);
        replacedTexture.SetPixel((int)4, 0, new Color((float)Random.Range(0, 255) / 255.0f, (float)Random.Range(0, 255) / 255.0f, (float)Random.Range(0, 255) / 255.0f));
        //Color Oragne = new Color((float)224 / 255.0f, (float)126 / 255.0f, (float)38 / 255.0f);
        replacedTexture.SetPixel((int)5, 0, new Color((float)Random.Range(0, 255) / 255.0f, (float)Random.Range(0, 255) / 255.0f, (float)Random.Range(0, 255) / 255.0f));
        replacedTexture.Apply();

    }



}
