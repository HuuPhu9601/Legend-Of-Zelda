using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPowerup : Powerup
{
    public Inventory playerInventory;//tui nhan vat
    public float magicValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Hàm xử lý va chạm
    public void OnTriggerEnter2D(Collider2D other)
    {
        //Kiểm tra nêú vật thể chạm vòa có tag la player
        if (other.gameObject.CompareTag("Player"))
        {
            playerInventory.currentMagic += magicValue;
            powerupSignal.Raise();//gửi tín hiệu
            Destroy(this.gameObject);//Xóa bình nước phép
        }      
    }
}
