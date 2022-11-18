using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    //Trạng thái hoạt động của nút
    public bool active;
    //Trạng thái đc lưu lại trc đó trong game
    public BoolValue storedValue;

    //Truyền và hình ảnh nuts đang hđ
    public Sprite activeSprite;

    private SpriteRenderer mySprite;

    //Truyền vào class xử lý cánh cửa
    public Door thisDoor;
    private void Start()
    {
        //Sét trạng thái bằng trạng thái đã được lưu lại trc đó
        active = storedValue.runtimeValue;
        //Khởi tạo component
        mySprite = GetComponent<SpriteRenderer>();
        //Nếu hđ sẽ tự động mở cửa
        if (active)
        {
            ActivateSwitch();
        }
    }

    public void ActivateSwitch()
    {
        //Set hđ
        active = true;
        //gán lại trạng thái hđ cho bộ nhớ game
        storedValue.runtimeValue = active;
        //Mở cửa
        thisDoor.Open();
        //Gán hình ảnh nút hđ vào
        mySprite.sprite = activeSprite;
    }

    //Sử dụng hàm OnTrigger để bắt va chạm khi nv nhấn vào nuts
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Kiểm tra xem có phải nv không??
        if (other.CompareTag("Player"))
        {
            ActivateSwitch();
        }
    }
}
