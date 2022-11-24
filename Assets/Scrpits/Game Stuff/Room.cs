using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [Header("Danh sách enemy")]
    public Enemy[] enemies;//truyền vaod ds enemy

    [Header("Danh sach chậu")]
    public Pot[] pots;//truyền vaò ds chậu

    public virtual void OnTriggerEnter2D(Collider2D other)
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
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other)
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

    //Hàm dùng để điều kiển hoạt động của component truyền vào
    void ChangeActivation(Component component, bool activation)
    {
        component.gameObject.SetActive(activation);//Set hoạt động cho component truyền vào
    }
}
