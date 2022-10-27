using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    //tên sceen cần mở
    public string sceneToLoad;
    //Ví trí nhân vật xuất hiện ở scene load
    public Vector2 playerPosition;
    //Lưu vị trí cấu hình của nhân vật
    public VectorValue playerStorage;

    //Hàm xử lý khi va chạm
    public void OnTriggerEnter2D(Collider2D other)
    {
        //Kiểm tra tag của vật truyền vào là player và k phải là isTrigger
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            //Lưu vị trí người chơi
            playerStorage.runtimeValue = playerPosition;
            //Load màn chơi
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
