using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Kiểm tra nếu va chạm phải nhân vật có tag là enemy
        if (other.gameObject.CompareTag("enemy"))
        {
            //khởi tạo một rigidbody2d
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
                //Gán trạng thái của enemy bằng loạng choạng
                enemy.GetComponent<Enemy>().currentState = EnemyState.stagger;
                Vector2 defference = enemy.transform.position - transform.position;
                defference = defference.normalized * thrust;
                //Hàm AddForce() là hàm thêm lực
                enemy.AddForce(defference, ForceMode2D.Impulse);
                StartCoroutine(KnockCo(enemy));
            }
        }
    }

    private IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if (enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            enemy.GetComponent<Enemy>().currentState = EnemyState.idle;
        }

    }
}
