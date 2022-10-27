using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    //Tạo ra điểm max của camera
    public Vector2 maxPosition;
    //Tạo ra điểm min của camera
    public Vector2 minPosition;

    private void Start()
    {
        //gán vị trí cam bằng vị trí nhân vật
        //Tạo vector mới để cam trỏ thằng trục z của chính nó, nếu k sẽ k nhìn thấy gì kể cả bản đồ
        transform.position = new Vector3(target.position.x,target.position.y,transform.position.z);
    }

    private void LateUpdate()
    {
        //Nếu vị trí cam khác với vị trí target(player)
        if(transform.position != target.position)
        {
            //Tạo ra vector 3 để truyền vào tranform.position.z để cam có thể nhìn thấy nhân vật, nếu để z của nhân vật thì cam sẽ bằng nhân vật sẽ k nhìn thấy gì
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            
            //Hàm clamp() trong mathf hỗ trợ giới hạn giá trị trong khoảng min max
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
            //Hàm Lerp giúp di chuyển mềm mại hơn
            //param: 1. Vị trí hiện tại - 2. Vị trí muốn di chuyển đến - 3. làm mịn giữa 1 và 2
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
