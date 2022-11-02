using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolLog : Log
{
    //Đường dẫn
    public Transform[] path;
    public int currentPoint;//Điểm hiện tại
    public Transform currentGoal;//Mục tiêu hiện tại
    public float roundingDistance;
    protected override void CheckDistance()
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

                //ChangeState(EnemyState.walk);
                //điều khiển anim đứng dậy
                anim.SetBool("wakeUp", true);
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            //So sánh vị trí
            if (Vector3.Distance(transform.position, path[currentPoint].position) > roundingDistance)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, path[currentPoint].position, moveSpeed * Time.deltaTime);
                ChangeAnim(temp - transform.position);
                //Cập nhật vị trí hiện tại mà log di chuyển đến
                myRigidbody.MovePosition(temp);
            }
            else
            {
                ChangeGoal();
            }
        }
    }

    //Hàm điều khiển thay đổi mục tiêu
    private void ChangeGoal()
    {
        if (currentPoint == path.Length - 1)
        {
            currentPoint = 0;
            currentGoal = path[0];
        }
        else
        {
            currentPoint++;
            currentGoal = path[currentPoint];
        }
    }
}
