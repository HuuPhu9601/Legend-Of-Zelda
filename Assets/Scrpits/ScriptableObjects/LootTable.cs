using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//Nén lại
public class Loot
{
    public Powerup thisLoot;
    public int LootChange;
}

[CreateAssetMenu]
public class LootTable : ScriptableObject
{
    [Header("Vật phẩm nhận được")]
    public Loot[] loots;//Truyền vào ds vp muốn rơi ra

    //Hàm xử lý trả về vật phẩm
    public Powerup LootPowerup()
    {
        int cumProb = 0;//Khai bao bien tinh xac suat
        int curentProb = Random.Range(0, 100);//Lấy ra ngẫu nhiên sác xuất hiện tại

        for (int i = 0; i < loots.Length; i++)
        {
            cumProb += loots[i].LootChange;//Gan xac suat cua tung vat pham
            if (curentProb <= cumProb)// neu xac xuat hien tai nho hon hoac bang tong xac xuat cua cac vp
            {
                return loots[i].thisLoot;//tra ra vp hien tai
            }
        }
        return null;
    }
}
