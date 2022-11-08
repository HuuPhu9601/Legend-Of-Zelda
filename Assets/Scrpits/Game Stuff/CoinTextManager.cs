using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinTextManager : MonoBehaviour
{
    //Truyền vào túi của nhân vật
    public Inventory playerInventory;
    //Truyền vào text hiển thị số lượng tiền trên giao diện
    public TextMeshProUGUI coinDisplay;

    //Hàm xử lý cập nhật số lượng tiền
    public void UpdateCoinCount()
    {
        coinDisplay.text = "" + playerInventory.coins;
    }
}
