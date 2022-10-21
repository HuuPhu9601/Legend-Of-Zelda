using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Kiểm tra tag của vật thể va chạm để phá vỡ chiếc bình và chỉ player mới đước đánh vỡ chiếc bình
        if (other.gameObject.CompareTag("breakable") && this.gameObject.CompareTag("Player"))
        {
            //Gọi hàm Smash từ lớp pot
            other.GetComponent<Pot>().Smash();
        }

        //Kiểm tra nếu va chạm phải nhân vật có tag là enemy hoặc là player (áp dụng cho enemy đánh player)
        if (other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("Player"))
        {
            //khởi tạo một rigidbody2d
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if (hit != null)
            {
                Vector2 defference = hit.transform.position - transform.position;
                defference = defference.normalized * thrust;
                //Hàm AddForce() là hàm thêm lực
                hit.AddForce(defference, ForceMode2D.Impulse);
                //Kiểm tra nếu đối tượng là enemy
                if (other.gameObject.CompareTag("enemy"))
                {
                    //Gán trạng thái của enemy bằng loạng choạng
                    hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    other.GetComponent<Enemy>().Knock(hit, knockTime);
                }
                //Kiểm tra nếu là player
                if (other.gameObject.CompareTag("Player"))
                {
                    hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                    other.GetComponent<PlayerMovement>().Knock(knockTime);
                }
            }
        }
    }
}
