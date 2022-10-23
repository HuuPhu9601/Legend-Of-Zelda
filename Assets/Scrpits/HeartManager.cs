using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    //Một mảng hình ảnh
    public Image[] hearts;
    //Khai báo các ảnh trái tim
    public Sprite fullHeart;
    public Sprite halfFullHeart;
    public Sprite emptyHeart;

    //Khái báo số lượng hộp chứa trái tim
    public FloatValue heartContainers;

    void Start()
    {
        InitHeart();
    }

    //Hàm khởi tạo hình trái tim
    public void InitHeart()
    {
        for (int i = 0; i < heartContainers.initialValue; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHeart;
        }
    }
}
