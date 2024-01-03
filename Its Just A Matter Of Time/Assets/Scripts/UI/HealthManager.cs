using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public static int health = 3;

    public Image[] heart;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Awake()
    {
        health = 3;
    }

    void Update()
    {
        foreach(Image img in heart)
        {
            img.sprite = emptyHeart;
        }
        for(int i = 0; i < health; i++)
        {
            heart[i].sprite = fullHeart;
        }
    }
}
