using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Tốc độ đạn")]
    public float moveSpeed;
    [Header("Hướng đạn di chuyển")]
    public Vector2 directionToMove;
    [Header("Thời gian đạn tồn tại")]
    public float lifetime;
    private float lifetimeSeconds;//Thời gian đạn tồn tại tính bằng giây    
    [Header("Đối tượng vật lý 2D")]
    public Rigidbody2D myRigibody;//Lấy ra đối tượng vật lý của đạn
    private void Start()
    {
        //Khai báo đt vật lý
        myRigibody = GetComponent<Rigidbody2D>();
        //Gán thời gian tồn tại của đạn bằng thời gian truyền vào
        lifetimeSeconds = lifetime;
    }

    private void Update()
    {
        //thời gian tồn tại sẽ giảm dần theo tg
        lifetimeSeconds -= Time.deltaTime;
        if (lifetimeSeconds <= 0)
        {
            //Nếu thời gian về 0 thì sẽ hủy viên đạn và cả những thứ kế thừa nó
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Hàm thực hiện phóng đạn
    /// </summary>
    /// <param name="initialVel">Vận tốc ban đầu của đạn</param>
    public void Launch(Vector2 initialVel)
    {
        //Gán vận tốc cho đạn
        myRigibody.velocity = initialVel * moveSpeed;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //Nếu va chạm sẽ xóa đạn 
        Destroy(this.gameObject);
    }
}
