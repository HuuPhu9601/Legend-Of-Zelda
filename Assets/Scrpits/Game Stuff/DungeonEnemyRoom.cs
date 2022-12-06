using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonEnemyRoom : DungeonRoom
{
    [Header("Danh sách cánh cửa")]
    public Door[] doors;//truyền vào ds cách cửa


    //Hàm kiểm tra enemy tồn tại trong phòng
    public void CheckEnemies()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].gameObject.activeInHierarchy && i < enemies.Length - 1)//Kiểm tra enemy đang hoạt đông hay không?
            {
                return;
            }
        }
        //Nếu không còn enemy nào hđ thì sẽ mở cửa
        OpenDoor();
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        //kiểm tra other(thứ chạm vào collider) là player và đối tượng istrigger = false
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            //active all enemies and pots
            for (int i = 0; i < enemies.Length; i++)
            {
                ChangeActivation(enemies[i], true);
            }
            for (int i = 0; i < pots.Length; i++)
            {
                ChangeActivation(pots[i], true);
            }
            //Đong cửa
            CloseDoor();
        }
        
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        //kiểm tra other(thứ chạm vào collider) là player và đối tượng istrigger = false
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            //Deactive all enemies and pots
            for (int i = 0; i < enemies.Length; i++)
            {
                ChangeActivation(enemies[i], false);
            }
            for (int i = 0; i < pots.Length; i++)
            {
                ChangeActivation(pots[i], false);
            }
        }
    }

    //Hàm thực hiện đóng cửa
    public void CloseDoor()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].Close();
        }
    }

    //Hàm thực hiện mở cửa  
    public void OpenDoor()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].Open();
        }
    }
}
