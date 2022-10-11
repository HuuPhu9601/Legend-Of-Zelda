using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    //truyền vào vector2 vị trí cam thay đổi
    public Vector2 cameraChange;
    //truyền vào vị trí player thay đổi
    public Vector3 playerChange;
    private CameraMovement cam;
    public bool needText;
    //chuỗi chuyền vào tên phòng
    public string placeName;
    //Truyền vào thẻ Text
    public GameObject text;

    public TextMeshProUGUI placeText;
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
            //Gán tên phòng
            if (needText)
            {
                StartCoroutine(PlaceNameCo());
            }
        }

    }

    private IEnumerator PlaceNameCo()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(4f);// chờ 4s
        text.SetActive(false);
    }
}
