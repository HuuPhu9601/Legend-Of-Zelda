﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    idle
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;

    //Tốc độ di chuyển
    public float speed;

    private Rigidbody2D myRigidbody;

    //Biến lưu vị trí thay đổi của nhân vật
    private Vector3 change;

    //Xử lý điều khiển animon nhân vật  
    private Animator animator;

    //Tạo một scriptable floatValue để tiện cấu hình
    public FloatValue currentHealth;

    public HealthSignal playerHealthSignal;

    //Lưu vị trí bắt đầu của nhân vật
    public VectorValue startingPosition;
    //Khai báo túi đựng cua nhân vật
    public Inventory playerInventory;

    //Khai báo một bộ render hình ảnh
    public SpriteRenderer receiveItemSprite;

    //Truyền vào tín hiệu thông báo player nhận sát thương
    public HealthSignal playerHit;

    void Start()
    {
        //gán currentstate bằng walk
        currentState = PlayerState.walk;
        //khởi tạo animator
        animator = GetComponent<Animator>();
        //khoi tạo rigidbofdy
        myRigidbody = GetComponent<Rigidbody2D>();
        //Gán vị trí bắt đầu
        transform.position = startingPosition.runtimeValue;
        //Kiểm tra nếu  vào trong nhà thì nhân vật sẽ quay đầu vào bên trong
        if (string.Compare(SceneManager.GetActiveScene().name, "SampleScene", true) != 0)
        {
            animator.SetFloat("moveX", 0);
            animator.SetFloat("moveY", 1);
        }
        else
        {
            //Gán cho param moveX = 0
            animator.SetFloat("moveX", 0);
            animator.SetFloat("moveY", -1);
        }
    }

    void Update()
    {
        //Is the player in an interaction (Là người chơi trong một tương tác)
        if (currentState == PlayerState.interact)
        {
            return;
        }

        change = Vector2.zero;
        //Nhập dữ liệu điều khiển vào bàn phím bằng hàm Input.getAxis()
        //Thay bằng hàm GetAxisRaw sẽ tăng nhanh từ 0 leen1 chứ k từ từ như GetAxis
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        //Kiểm tra điều khiển đầu vào có phải attack bằng hàm buttondown - - truyền vào tên phím
        if (Input.GetButtonDown("Attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            //Gọi hàm thực hiện tấn công
            StartCoroutine(AttackCo());
        }

        //Kiểm tra currentstate bằng walk thì mới cho di chuyển và anim
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }
    }

    //Hàm thực hiện tấn công và anim
    private IEnumerator AttackCo()
    {
        //Thực hiển chuyển động tấn công bằng cách bật param attack
        animator.SetBool("attacking", true);
        //Set trangk thái hiện tại là tấn công
        currentState = PlayerState.attack;
        yield return null;
        //Sau khi thực hiện tấn công và qua return trả về sẽ tắt anim tấn công
        animator.SetBool("attacking", false);
        //Sau đó lại đợi và giây
        yield return new WaitForSeconds(0.3f);
        //Sau khi đợi 0.33s thì sẽ sét trạng thái hiện tại về đi bộ
        if (currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
    }

    //Hàm xử lý nhặt item
    public void RaiseItem()
    {
        //Kiểm tra nếu túi có item
        if (playerInventory.currentItem != null)
        {

            //Nếu trạng thái hiện tại khác interact thì thực hiện hđ nhặt chìa khóa
            if (currentState != PlayerState.interact)
            {
                //Kích hoạt animation nâng chìa khóa
                animator.SetBool("receiveItem", true);
                //set trang thai hiện tại là interact
                currentState = PlayerState.interact;
                //Thêm hình ảnh item hiện tại vào bộ render hình ảnh
                receiveItemSprite.sprite = playerInventory.currentItem.itemSprite;
            }
            else //ngược lại
            {
                //Tắt kích hoạt animation nâng chìa khóa
                animator.SetBool("receiveItem", false);
                //set trang thai hiện tại là đứng yên
                currentState = PlayerState.idle;
                //Xóa hình ảnh item
                receiveItemSprite.sprite = null;
                //Xóa item ra khỏi túi nhân vật
                playerInventory.currentItem = null;
            }
        }
    }

    //Hàm xử lý animation và chuyển động    
    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            //Phát chuyển động
            //Sử dụng hàm setfloat để gán giá trị cho param tạo trong animator
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
            animator.SetBool("moving", false);
    }

    void MoveCharacter()
    {
        //Dùng hàm MovePosition của rigidbody để di chuyển thay vì phải di chuyển bằng transform
        //Truyền vào vector2 hoặc vector3 nhưng thường truyền vào vector3
        //Vì để còn truyền vào vị trí của nhân vật position(Vector3)
        //công thức di chuyển vận tốc nhân vật
        //Vị trí ban đầu(transform.position) + vị trí tiếp theo nhận dữ liệu từ bàn phím(change_vector3) * tốc độ(speed) * thời gian thực (Time.deltaTime)
        change.Normalize();//Giúp nhân vật khi di chuyển chéo k bị đi nhanh hơn mà sẽ giống nhau đi ngang dọc
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }

    public void Knock(float knockTime, float damage)
    {
        currentHealth.runtimeValue -= damage;
        playerHealthSignal.Raise();
        if (currentHealth.runtimeValue > 0)
        {
            StartCoroutine(KnockCo(knockTime));
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    //Thêm hàm để xử lý enemy tác động nên player
    private IEnumerator KnockCo(float knockTime)
    {
        //Truyền tín hiệu khi người chơi nhận sát thương
        playerHit.Raise();
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            myRigidbody.velocity = Vector2.zero;
        }

    }
}
