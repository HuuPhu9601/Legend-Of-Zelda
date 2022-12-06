using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tạo trạng thái cửa
public enum DoorType
{
    key,
    enemy,
    button,
}

public class Door : Interactable
{
    //Tao tieu de
    [Header("Door variables")]
    //khai bao
    public DoorType thisDoorType;
    public bool open = false;
    //Khai báo túi đồ của nhân vật
    public Inventory playerInvertory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;

    private void Update()
    {
        //Nếu nhấn phím cách
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Nếu player trong vùng và trạng thái của cửa là khóa
            if (playerInRange && thisDoorType == DoorType.key)
            {
                //Does the player open a key? Nếu túi đồ của player có chìa khóa
                if (playerInvertory.numberOfKey > 0)
                {
                    //Renmove a player key Xóa 1 chìa khóa
                    //playerInvertory.numberOfKey--;
                    //If so, then call the open method Nếu có gọi hàm Open()
                    Open();
                }
            }
        }
    }

    public void Open()
    {
        //Turn off the door's sprite renderer tắt hình ảnh cánh cửa
        doorSprite.enabled = false;
        //set isOpen is true
        if (!open) open = true;
        //turn off the door's box collider tắt box collider của cánh cửa
        physicsCollider.enabled = false;
    }

    public void Close()
    {
        //Turn off the door's sprite renderer tắt hình ảnh cánh cửa
        doorSprite.enabled = true;
        //set isOpen is true
        open = false;
        //turn off the door's box collider tắt box collider của cánh cửa
        physicsCollider.enabled = true;
    }
}


