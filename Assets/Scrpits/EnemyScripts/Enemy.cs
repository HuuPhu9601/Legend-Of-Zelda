﻿using System.Collections;
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
    [Header("State Machine")]
    public EnemyState currentState;

    [Header("Enemy Stats")]
    //Khai báo một ScriptableObject là sức khỏe lớn nhất
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;

    [Header("Vị trí ban đầu")]
    public Vector2 homePosition;//truyền vào vị trí ban đầu của enemy

    [Header("Hiệu ứng hạ gục")]
    //Khai báo đối tượng chứa hiệu ứng chết
    public GameObject deathEffect;

    [Header("Tín hiệu bị hạ gục")]
    public HealthSignal roomSignal;

    [Header("Danh sách vp sẽ rơi")]
    public LootTable thisLoot;//Truyền vào  ds vp sẽ roi ra khi enemy chết

    private float deathEffectDelay = 1f;
    private void Awake()
    {
        health = maxHealth.initialValue;
    }

    private void OnEnable()
    {
        transform.position = homePosition;
        health = maxHealth.initialValue;
        currentState = EnemyState.idle;
    }

    //Hàm xử lý gây damage
    private void TakeDamage(float damage)
    {
        health -= damage;
        //Nếu đã hết máu thì enemy không hoạt động nữa
        if (health <= 0)
        {
            DeathEffect();//hiẹu ứng chết
            MakeLoot();//rơi đôf
            if (roomSignal != null) roomSignal.Raise();
            this.gameObject.SetActive(false);
        }
    }

    //Hàm xử lý rơi ra chiến lợi phẩm khi enemy chết
    private void MakeLoot()
    {
        if (thisLoot != null)
        {
            Powerup current = thisLoot.LootPowerup();
            if (current != null)
            {
                //Khởi tạo vật phẩm ngay tại vị trí eneemy
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
            }
        }
    }

    //Hàm xử lý khi enemy chết sẽ tạo hiệu ứng lửa
    private void DeathEffect()
    {
        //kiem tra doi tuong khong null
        if (deathEffect != null)
        {
            //tao ra doi tuong moi
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            //xao doi tuong sau 1s
            Destroy(effect, deathEffectDelay);
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
