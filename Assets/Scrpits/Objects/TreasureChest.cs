using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable
{
    [Header("Contains")]
    public Item contents;//Truyền vào một item
    public Inventory playerInventory;//Truyền vào túi đựng item của nhân vật
    public bool isOpen;//Điều khiển có mở rương hay không
    public BoolValue storedOpen;//Truyền vào giá trị bool để biết xem rương đã đc mở hay chưa??

    [Header("Signals And Dialogs")]
    public HealthSignal raiseItem;//Truyền vào 1 tín hiệu item
    public GameObject dialogBox;//truyền vào một dialog thông baos mô tả vật phẩm nhặt đc
    //Tạo text
    public TextMeshProUGUI dialogText;//Truyền vào UI text để hiển thị mô tả vật phẩm

    [Header("Animator")]
    private Animator anim;//Khai báo animator của rương báu

    private void Start()
    {
        //Khởi tạo animator
        anim = GetComponent<Animator>();
        //Gán cờ mở bằng cờ đã mở để xem rương đã mở chưa
        isOpen = storedOpen.runtimeValue;
        if (isOpen)
        {
            //Thực hiện anim mở rương
            anim.SetBool("opened", true);
        }
    }

    private void Update()
    {
        //Nhận điều khiển từ phím space truyền vào và nhân vật trong vùng va chạm
        //Input.GetKeyDown(KeyCode.Space)
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (!isOpen)//Khi rương đóng sẽ mở rương
            {
                //Open the chest
                OpenChest();
            }
            else //Khi rương mở sẽ chuẩn bị mở rương
            {
                //Chest is ready open
                ChestReadyOpen();
            }
        }
    }


    //Hàm xử lý rương mở
    public void OpenChest()
    {
        //Dialog window on (set hoạt động cho dialog thông báo nhặt đc vật phẩm)
        dialogBox.SetActive(true);
        //dialog text = contents text (gán text hiển thị là mô tả vật phẩm
        dialogText.text = contents.itemDescription;
        //add contents to be inventory (thêm item vào túi của player)
        playerInventory.AddItem(contents);
        //Gán item vào túi của nhân vật Lấy item làm vật phẩm hiện tại trong túi của player
        playerInventory.currentItem = contents;
        //raise the signal to the player to animate
        raiseItem.Raise(); //Gửi tín hiệu
        //raise context clue
        context.Raise();
        //set the chest to opened //Set open thành đã mở
        isOpen = true;
        //Thực hiện anim mở rương
        anim.SetBool("opened", true);
        //Gán thành đã mở rương
        storedOpen.runtimeValue = isOpen;
    }

    //Hàm xử lý chuẩn bị mở rương
    public void ChestReadyOpen()
    {
        //Dialog off (tắt dialog thông báo)
        dialogBox.SetActive(false);
        //raise the signal to the player to stop animating (gửi tín hiệu)
        raiseItem.Raise();
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        //Kiểm tra có đúng tag va chạm hay không?
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            //set true
            context.Raise();
            playerInRange = true;
        }
    }
    //Hàm để nhân biết khi nào vật thể thoát va chạm
    protected override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            //set false
            context.Raise();
            playerInRange = false;
            //hủy hoạt động của hộp thoại
        }
    }
}
