using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Kiểm tra tag của vật thể va chạm
        if (other.CompareTag("breakable"))
        {
            //Gọi hàm Smash từ lớp pot
            other.GetComponent<Pot>().Smash();
        }
    }
}
