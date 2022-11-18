using UnityEngine;

public class TurretEnemy : Log
{
    [Header("Viên đạn")]
    public GameObject projectile;//Truyền viên đạn

    [Header("Độ trễ đạn")]
    public float fireDelay;
    private float fireDelaySeconds;

    [Header("Có thể bắn")]
    public bool canFire = true;

    public void Update()
    {
        fireDelaySeconds -= Time.deltaTime;
        if (fireDelaySeconds <= 0)
        {
            canFire = true;
            fireDelaySeconds = fireDelay;
        }
    }

    //Ghi đè lại hàm kiểm tra khoảng cách của Log
    protected override void CheckDistance()
    {
        //Kiểm tra khoảng cách của log và nhân vật player sử dụng hàm Vector3.Distance()
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            //Kiểm tra trạng thái enemy
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                if (canFire)
                {
                    //đo khoảng cách từ enemy đến nhân vật 
                    Vector3 tempVector = target.transform.position - transform.position;
                    //Taoj ra viên đạn từ vị trí hiện tại của enemy
                    GameObject current = Instantiate(projectile, transform.position, Quaternion.identity);

                    //Khởi tạo lớp Projectile để sử dụng hàm bắn đạn truyền vào khoảng cách của enemy đến player
                    current.GetComponent<Projectile>().Launch(tempVector);
                    canFire = false;
                    ChangeState(EnemyState.walk);
                    //điều khiển anim đứng dậy
                    anim.SetBool("wakeUp", true);
                }

            }
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius) anim.SetBool("wakeUp", false);
    }
}
