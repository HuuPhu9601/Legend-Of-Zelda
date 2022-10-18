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

    public int health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
