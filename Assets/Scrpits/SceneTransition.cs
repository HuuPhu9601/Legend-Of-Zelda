using System.Collections;
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

    public GameObject fadeInpanel;
    public GameObject fadeOutpanel;
    public float fadeWait;

    //Hàm khởi tạo chạy trc hàm  start
    private void Awake()
    {
        if (fadeInpanel != null)
        {
            //Khởi tạo một đối tượng mới từ panel
            GameObject panel = Instantiate(fadeInpanel, Vector3.zero, Quaternion.identity) as GameObject;
            //Xóa panel sau 1 giây  
            Destroy(panel, 1);
        }
    }
    //Hàm xử lý khi va chạm
    public void OnTriggerEnter2D(Collider2D other)
    {
        //Kiểm tra tag của vật truyền vào là player và k phải là isTrigger
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            //Lưu vị trí người chơi
            playerStorage.runtimeValue = playerPosition;
            StartCoroutine(FadeCo());
            //Load màn chơi
            //SceneManager.LoadScene(sceneToLoad);
        }
    }

    public IEnumerator FadeCo()
    {
        //Khoi tao
        if (fadeOutpanel != null)
        {
            Instantiate(fadeOutpanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);

        //Load scene đồng bộ
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}
