using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelleEnemy : Log
{
    //hàm kiểm tra khoảng cách
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

                ChangeState(EnemyState.walk);
            }
        }
        else if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) <= attackRadius)
        {
            if (currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                StartCoroutine(AttackCo());//goi ham
            }
        }
    }

    //Hàm xử lý hoạt ảnh và trang thái cho enemy
    public IEnumerator AttackCo()
    {
        currentState = EnemyState.attack;//set trang thai cho enemy     
        anim.SetBool("attack", true);// thực hiện anim tân công
        yield return new WaitForSeconds(1f);//ngủ 1s
        currentState = EnemyState.walk;//chyen trang thai sang di bo
        anim.SetBool("attack", false);//bo anim tan cong
    }
}
