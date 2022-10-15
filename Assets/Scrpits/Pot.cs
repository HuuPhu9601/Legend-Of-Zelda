using System.Collections;
using UnityEngine;

public class Pot : MonoBehaviour
{
    //Khai báo animator
    private Animator anim;
    void Start()
    {
        //Khởi tạo animator
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }
    //Xử lý animation pot vỡ
    public void Smash()
    {
        //set smash = true;
        anim.SetBool("smash", true);
        StartCoroutine(breakCo());
    }

    private IEnumerator breakCo()
    {
        //Nghỉ 0.3s
        yield return new WaitForSeconds(0.3f);
        this.gameObject.SetActive(false);//Set lại thành không hoạt động
    }
}
