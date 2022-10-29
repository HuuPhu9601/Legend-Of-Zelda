using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public HealthSignal context;

    //Cờ nhận biết player trong vùng trigger
    public bool playerInRange;

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        //Kiểm tra có đúng tag va chạm hay không?
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            //set true
            context.Raise();
            playerInRange = true;
        }
    }
    //Hàm để nhân biết khi nào vật thể thoát va chạm
    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            //set false
            context.Raise();
            playerInRange = false;
            //hủy hoạt động của hộp thoại
        }
    }
}
