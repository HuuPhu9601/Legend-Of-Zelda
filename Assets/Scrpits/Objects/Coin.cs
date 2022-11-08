using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Powerup
{
    //Truyền vào túi đồ của nhân vật
    public Inventory playerInventory;

    private void Start()
    {
        powerupSignal.Raise();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        //Kiểm tra nếu vật va chạm vào trái tim là player và k có isTrigger thì:
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            //túi của nhân vật nhận thêm 1 coin
            playerInventory.coins += 1;

            //Gửi tín hiệu cho giao diện kiểm tra cần bao nhiêu trái tim hiển thị
            powerupSignal.Raise();
            //Xóa trái tim đi
            Destroy(gameObject);
        }
    }
}
