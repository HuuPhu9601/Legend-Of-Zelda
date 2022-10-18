using UnityEngine;

public class Log : Enemy
{
    private Rigidbody2D myRigidbody;
    //Vij trí của mục tiêu cần log đuổi theo
    public Transform target;
    //Bán kính đuổi theo của log
    public float chaseRadius;
    //Bán kính trấn công của log
    public float attackRadius;
    //Vị trí nhà mà log sẽ quay lại
    public Transform homePosition;
    void Start()
    {
        //Setup trạng thái của log là đứng yên
        currentState = EnemyState.idle;
        //Khoi tao rigidbody
        myRigidbody = GetComponent<Rigidbody2D>();
        //khởi tạo vị trí target chính là vị trí nhân vật bằng cách tìm nhân vật theo tag (dùng hàm  GameObject.FindWithTag)
        target = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        CheckDistance();
    }

    //hàm kiểm tra khoảng cách
    private void CheckDistance()
    {
        //Kiểm tra khoảng cách của log và nhân vật player sử dụng hàm Vector3.Distance()
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            //Kiểm tra trạng thái enemy
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                //hàm Vector3.MoveTowards() giúp log di chuyển đến vị trí của nhân vật và cách nhân vật 1 khoảng
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                myRigidbody.MovePosition(temp);
                ChangeState(EnemyState.walk);
            }
        }
    }

    private void ChangeState(EnemyState newState)
    {
        if (currentState != newState) currentState = newState;
    }
}
