using UnityEngine;

public class Knockback : MonoBehaviour
{
    [Header("Lực đẩy")]
    public float thrust;
    
    [Header("Thời gian cú đánh")]
    public float knockTime;
    //lượng đam
    [Header("Lượng đam")]
    public float damage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Kiểm tra tag của vật thể va chạm để phá vỡ chiếc bình và chỉ đòn đánh player mới đước đánh vỡ chiếc bình
        if (other.gameObject.CompareTag("breakable") && this.gameObject.CompareTag("Player"))
        {
            //Gọi hàm Smash từ lớp pot
            other.GetComponent<Pot>().Smash();
        }

        //Kiểm tra nếu va chạm phải nhân vật có tag là enemy hoặc là đòn đánh của player (áp dụng cho enemy đánh player)
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
                if (other.gameObject.CompareTag("enemy") && other.isTrigger)
                {
                    //Gán trạng thái của enemy bằng loạng choạng
                    hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    other.GetComponent<Enemy>().Knock(hit, knockTime,damage);
                }
                //Kiểm tra nếu là đòn đánh của player
                if (other.gameObject.CompareTag("Player"))
                {
                    if (other.GetComponent<PlayerMovement>().currentState != PlayerState.stagger)
                    {
                        hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                        other.GetComponent<PlayerMovement>().Knock(knockTime, damage);
                    }
                }
            }
        }
    }
}
