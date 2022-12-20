using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartContainer : Powerup
{
    [Header("floatvalue hộp chứa trái tim")]
    public FloatValue heartContainers;

    [Header("float value sức khỏe nhân vật")]
    public FloatValue playerHealth;

    //Ham xu ly va cham
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))//Kiem tra vat va cham co tag laf player hay khong?
        {
            heartContainers.runtimeValue += 1;//hop chua trai tim dc cong them 1
            playerHealth.runtimeValue = heartContainers.runtimeValue;//suc khoe nhan vat bang voi gia tri cua thung chua trai tim
            powerupSignal.Raise();//gui tin hieu den heartmanager biet trai tim nao se hd
            Destroy(this.gameObject);//xoa item trai tim 
        }
    }
}
