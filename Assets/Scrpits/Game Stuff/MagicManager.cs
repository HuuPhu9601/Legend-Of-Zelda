using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicManager : MonoBehaviour
{
    [Header("Thanh magic UI")]
    public Slider magicSlider;//thanh magic o UI

    [Header("Player Inventory")]
    public Inventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        magicSlider.maxValue = playerInventory.maxMagic;
        magicSlider.value = playerInventory.maxMagic;
        playerInventory.currentMagic = playerInventory.maxMagic;
    }

    //Hàm xử lý thêm magic trên UI
    public void AddMagic()
    {
        magicSlider.value ++;//Tăng giá trị slider lên 1 đơn vị
        playerInventory.currentMagic++;
        //neu gia tri hien tai lon hon gia tri max
        if (magicSlider.value > magicSlider.maxValue)
        {
            magicSlider.value = magicSlider.maxValue;//Gan lai g/tri bang g/tri lon nhat
            playerInventory.currentMagic = playerInventory.maxMagic;

        }
    }

    //Hàm giảm magic
    public void DecreaseMagic() 
    {
        magicSlider.value--;
        playerInventory.currentMagic--;
        if (magicSlider.value < 0)
        {
            magicSlider.value = 0;
            playerInventory.currentMagic = 0;
        }
    }
}
