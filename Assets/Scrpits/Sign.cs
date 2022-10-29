using TMPro;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public HealthSignal context;

    //Tạo hộp thông báo
    public GameObject dialogBox;
    //Tạo text
    public TextMeshProUGUI dialogText;
    public string dialog;
    //Cờ nhận biết player trong vùng trigger
    public bool playerInRange;

    private void FixedUpdate()
    {
        //Nhận điều khiển từ phím space truyền vào và nhân vật trong vùng va chạm
        //Input.GetKeyDown(KeyCode.Space)
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            ////Kiểm tra nếu hộp đang mở hay không??
            //if (dialogBox.activeInHierarchy)
            //{
            //    //Đóng hoạt động của hộp
            //    dialogBox.SetActive(false);
            //}
            //else
            //{
            //Mở hoạt động của hộp
            dialogBox.SetActive(true);
            //Set text bằng chuỗi truyền vào
            dialogText.text = dialog;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
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
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            //set false
            context.Raise();
            playerInRange = false;
            //hủy hoạt động của hộp thoại
            dialogBox.SetActive(false);
        }
    }
}
