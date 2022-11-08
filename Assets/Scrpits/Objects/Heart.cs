using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Powerup
{
    //Truyền vào giá trị để tăng thêm máu cho nhân vật khi nhặt được máu
    public FloatValue playerHeart;
    
    //Truyền vào túi chứa trái tim
    public FloatValue HeartContainer;

    //Khai báo số lượng sức khỏe muốn tăng cho nhân vật
    public float amountToIncrease;

    public void OnTriggerEnter2D(Collider2D other)
    {
        //Kiểm tra nếu vật va chạm vào trái tim là player và k có isTrigger thì:
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            //Tăng số lượng sức khỏe lên
            playerHeart.runtimeValue += amountToIncrease;

            //Nếu số lượng máu của nhân vật lớn hơn túi chứa thì:
            if (playerHeart.initialValue > HeartContainer.runtimeValue)
            {
                //Máu của nhân vật bằng túi chứa
                playerHeart.initialValue = HeartContainer.runtimeValue;
            }

            //Gửi tín hiệu cho giao diện kiểm tra cần bao nhiêu trái tim hiển thị
            powerupSignal.Raise();
            //Xóa trái tim đi
            Destroy(gameObject);
        }
    }
}
