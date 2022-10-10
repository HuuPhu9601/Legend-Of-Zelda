using UnityEngine;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam;

    private void Start()
    {
        //Khởi tạo cam bằng hàm getcomponent
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //So sánh tag dùng hàm compareTag của collider2d
        //Nếu tag chạm vào là player thì sẽ thay đổi vị trí của máy ảnh
        if (other.CompareTag("Player"))
        {
            //thêm vị trí min và max của camera
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
            //gán lại vị trí collider other cộng thêm vị trí player thay đổi
            other.transform.position += playerChange;

        }

    }
}
