using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Tốc độ di chuyển
    public float speed;

    private Rigidbody2D myRigidbody;

    //Biến lưu vị trí thay đổi của nhân vật
    private Vector3 change;

    //Xử lý điều khiển animon nhân vật  
    private Animator animator;
    void Start()
    {
        //khởi tạo animator
        animator = GetComponent<Animator>();
        //khoi tạo rigidbofdy
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        change = Vector2.zero;
        //Nhập dữ liệu điều khiển vào bàn phím bằng hàm Input.getAxis()
        //Thay bằng hàm GetAxisRaw sẽ tăng nhanh từ 0 leen1 chứ k từ từ như GetAxis
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();
    }
    //Hàm xử lý animation và chuyển động    
    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            //Phát chuyển động
            //Sử dụng hàm setfloat để gán giá trị cho param tạo trong animator
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
            animator.SetBool("moving", false);
    }

    void MoveCharacter()
    {
        //Dùng hàm MovePosition của rigidbody để di chuyển thay vì phải di chuyển bằng transform
        //Truyền vào vector2 hoặc vector3 nhưng thường truyền vào vector3
        //Vì để còn truyền vào vị trí của nhân vật position(Vector3)
        //công thức di chuyển vận tốc nhân vật
        //Vị trí ban đầu(transform.position) + vị trí tiếp theo nhận dữ liệu từ bàn phím(change_vector3) * tốc độ(speed) * thời gian thực (Time.deltaTime)
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
