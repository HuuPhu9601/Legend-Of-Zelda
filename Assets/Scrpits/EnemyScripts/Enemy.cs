using System.Collections;
using UnityEngine;

//Tạo ra một enum để quản lý trạng thái của enemy
public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}

public class Enemy : MonoBehaviour
{
    //Khai báo enum
    public EnemyState currentState;
    //Khai báo một ScriptableObject là sức khỏe lớn nhất
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;

    private void Awake()
    {
        health = maxHealth.initialValue;
    }

    //Hàm xử lý gây damage
    private void TakeDamage(float damage)
    {
        health -= damage;
        //Nếu đã hết máu thì enemy không hoạt động nữa
        if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage)//them dame
    {
        StartCoroutine(KnockCo(myRigidbody, knockTime));
        TakeDamage(damage);
    }
    private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myRigidbody.velocity = Vector2.zero;
        }

    }
}
