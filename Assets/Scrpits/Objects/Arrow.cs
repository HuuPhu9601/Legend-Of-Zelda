using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [Header("Tốc độ")]
    public float speed;//tốc đôj mũi tên
    public Rigidbody2D myRigidbody;

    [Header("Phạm vi đạn")]
    public float limitProjectile;

    [Header("Hẹn giờ hủy")]
    public float lifetime;
    private float lifetimeCounter;

    public float magicCost;

    private void Start()
    {
        lifetimeCounter = lifetime;
    }

    private void Update()
    {
        //Giam dan thoi gian theo thoi gian thuc
        //lifetimeCounter -= Time.deltaTime;
        ////neu thoi gian ton tai nho hon hoac bang 0
        //if (lifetimeCounter <= 0)
        //{
        //    Destroy(this.gameObject);// xoa mui ten
        //}
    }

    public void Setup(Vector2 velocity, Vector3 direction)
    {
        myRigidbody.velocity = velocity.normalized * speed;
        //hàm Quaternion.Euler điều khiển cho vật thể xoay về hướng mong muốn 
        transform.rotation = Quaternion.Euler(direction);
    }

    //Hàm kiểm tra phạm vi đạn
    public void CheckLimit(Transform playerTransform)
    {
        if(Vector3.Distance(playerTransform.position,gameObject.transform.position) > limitProjectile)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
