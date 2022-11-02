using UnityEngine;

public class Log : Enemy
{
    protected Rigidbody2D myRigidbody;
    //Vij trí của mục tiêu cần log đuổi theo
    public Transform target;
    //Bán kính đuổi theo của log
    public float chaseRadius;
    //Bán kính trấn công của log
    public float attackRadius;
    //Vị trí nhà mà log sẽ quay lại
    public Transform homePosition;

    //Khai báo animator
    protected Animator anim;
    void Start()
    {
        //Khai báo animator
        anim = GetComponent<Animator>();
        //Setup trạng thái của log là đứng yên
        currentState = EnemyState.idle;
        //Khoi tao rigidbody
        myRigidbody = GetComponent<Rigidbody2D>();
        //khởi tạo vị trí target chính là vị trí nhân vật bằng cách tìm nhân vật theo tag (dùng hàm  GameObject.FindWithTag)
        target = GameObject.FindWithTag("Player").transform;
        anim.SetBool("wakeUp", true);
    }

    void FixedUpdate()
    {
        CheckDistance();
    }

    //hàm kiểm tra khoảng cách
    protected virtual void CheckDistance()
    {
        //Kiểm tra khoảng cách của log và nhân vật player sử dụng hàm Vector3.Distance()
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            //Kiểm tra trạng thái enemy
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                //hàm Vector3.MoveTowards() giúp log di chuyển đến vị trí của nhân vật và cách nhân vật 1 khoảng
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                ChangeAnim(temp - transform.position);
                //Cập nhật vị trí hiện tại mà log di chuyển đến
                myRigidbody.MovePosition(temp);
                
                ChangeState(EnemyState.walk);
                //điều khiển anim đứng dậy
                anim.SetBool("wakeUp", true);
            }
        }
        else if(Vector3.Distance(target.position, transform.position) > chaseRadius) anim.SetBool("wakeUp", false);
    }

    protected void SetAnimFloat(Vector2 setVector)
    {
        anim.SetFloat("moveX", setVector.x);
        anim.SetFloat("moveY", setVector.y);
    }

    //Hàm xử lý thay đổi anim của log
    protected void ChangeAnim(Vector2 direction)
    {
        //Kiểm tra xem log di chuyển trái phải hay lên xuống
        //Vì có cả giá trị âm nên ta phải dùng trị tuyệt đối để so sánh sang trái phải hay lên xuống
        //Nếu di chuyển sang
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            //Nếu x > 0 => sang phải,  x < 0 => sang trái
            if (direction.x > 0)
            {
                SetAnimFloat(Vector2.right);
            }
            else if(direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }
        }
        //Ngược lại di chuyển lên xuống
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            //Nếu y > 0 => lên trên,  y < 0 => xuống dưới
            if (direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }

    protected void ChangeState(EnemyState newState)
    {
        if (currentState != newState) currentState = newState;
    }
}
