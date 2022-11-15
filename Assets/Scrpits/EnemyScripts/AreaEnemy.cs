using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEnemy : Log
{
    public Collider2D boundary;//Truyền vào vùng ranh giới enemy hoạt động

    protected override void CheckDistance()
    {
        //Kiểm tra khoảng cách của log và nhân vật player sử dụng hàm Vector3.Distance() và kiểm tra vị trí nhân vật có nằm trong vùng hđ của enemy hay không?
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius &&
            boundary.bounds.Contains(target.transform.position))
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
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius ||
            boundary.bounds.Contains(target.transform.position)) anim.SetBool("wakeUp", false);
    }
}
