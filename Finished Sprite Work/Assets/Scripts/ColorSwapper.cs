using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColorSwapper : MonoBehaviour{ 

    Texture2D replacedTexture;
    Color[] originalColors;
    SpriteRenderer mSpriteRenderer;



    void Awake()
    {
        mSpriteRenderer = GetComponent<SpriteRenderer>();


        Texture2D tempTexture = new Texture2D(6, 1, TextureFormat.RGBA32, false, false);
        tempTexture.filterMode = FilterMode.Point;

        int counter = 0;
        for (int i = 0; i < tempTexture.width; ++i)
        {
            //tempTexture.SetPixel(i, 0, new Color(0.0f, 0.0f, 0.0f, 0.0f));
            tempTexture.SetPixel(i, 0, new Color((float)Random.Range(0, 255) / 255.0f, (float)Random.Range(0, 255) / 255.0f, (float)Random.Range(0, 255) / 255.0f));
            counter += 1;
        }

        tempTexture.SetPixel(0, 0, new Color((float)0 / 255.0f, (float)0 / 255.0f, (float)0 / 255.0f));

        if (this.gameObject.name.Contains("Cardboard"))
        {
            tempTexture.SetPixel(5, 0, new Color((float)249 / 255.0f, (float)173 / 255.0f, (float)129 / 255.0f));
            tempTexture.SetPixel(4, 0, new Color((float)Random.Range(100, 255) / 255.0f, (float)Random.Range(100, 255) / 255.0f, (float)Random.Range(150, 255) / 255.0f));
        } else if (this.gameObject.name.Contains("Soda"))
        {
            tempTexture.SetPixel(1, 0, new Color((float)200/ 255.0f, (float)200 / 255.0f, (float)200 / 255.0f));
        } else if (this.gameObject.name.Contains("Jug"))
        {
            tempTexture.SetPixel(4, 0, new Color((float)255 / 255.0f, (float)255 / 255.0f, (float)255 / 255.0f));
        } else if (this.gameObject.name.Contains("Yard Waste"))
        {
            tempTexture.SetPixel(1, 0, new Color((float)0 / 255.0f, (float)166 / 255.0f, (float)81 / 255.0f));
        } else if (this.gameObject.name.Contains("Wrappers"))
        {
            tempTexture.SetPixel(2, 0, new Color((float)200 / 255.0f, (float)200 / 255.0f, (float)200 / 255.0f));
        } else if (this.gameObject.name.Contains("Food Waste"))
        {
            tempTexture.SetPixel(1, 0, new Color((float)Random.Range(50, 150) / 255.0f, (float)Random.Range(50, 150) / 255.0f, (float)Random.Range(50, 150) / 255.0f));
        } else if (this.gameObject.name.Contains("FoodBoard"))
        {
            tempTexture.SetPixel(2, 0, new Color((float)Random.Range(50, 255) / 255.0f, (float)Random.Range(50, 255) / 255.0f, (float)Random.Range(50, 255) / 255.0f));
            tempTexture.SetPixel(3, 0, new Color((float)Random.Range(50, 150) / 255.0f, (float)Random.Range(50, 150) / 255.0f, (float)Random.Range(50, 150) / 255.0f));
            tempTexture.SetPixel(4, 0, new Color((float)Random.Range(100, 200) / 255.0f, (float)Random.Range(100, 200) / 255.0f, (float)Random.Range(100, 200) / 255.0f));
            tempTexture.SetPixel(5, 0, new Color((float)Random.Range(150, 255) / 255.0f, (float)Random.Range(150, 255) / 255.0f, (float)Random.Range(150, 255) / 255.0f));
        }






        tempTexture.Apply();
        mSpriteRenderer.material.SetTexture("_SwapTex", tempTexture);
        originalColors = new Color[tempTexture.width];
        replacedTexture = tempTexture;

        replacedTexture.Apply();


    }

    void Update()
    {
        //float step = 0.5f * Time.deltaTime;
        ///Vector2 tempSpot = new Vector2(4.5f, 4.5f);
        //this.transform.position = Vector2.MoveTowards(this.transform.position, tempSpot, step);


    }


   
}
