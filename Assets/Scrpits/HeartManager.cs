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
    //Giá trị sức khỏe hiện tại của player
    public FloatValue playerCurrentHealth;

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

    //Hàm cập nhật giá trị sức khỏe của player
    public void UpdateHearts()
    {
        //Số máu và số mạng bằng nhau
        float tempHealth = playerCurrentHealth.runtimeValue;
        //Thực hiện so sánh sức khỏe hiện tại và sức khỏe tối đa mà player có
        for (int i = 0; i < playerCurrentHealth.initialValue; i++)
        {
            if (i <= tempHealth - 1)//Đầy máu
            {
                hearts[i].sprite = fullHeart;
            }
            else if (i >= tempHealth) //Hết máu
            {
                hearts[i].sprite = emptyHeart;
            }
            else //Nửa máu
            {
                hearts[i].sprite = halfFullHeart;
            }
        }


    }
}
