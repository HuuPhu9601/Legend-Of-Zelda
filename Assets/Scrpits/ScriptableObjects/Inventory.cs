using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    //Truyền vào đối tượng muốn đựng
    public Item currentItem;
    //Truyền vào danh sách các item muốn đựng trong túi
    public List<Item> items = new List<Item>();
    //Số chìa khóa mà túi có
    public int numberOfKey;

    //Số tiền mà nhân vật có
    public int coins;

    [Header("Magic lớn nhất")]
    public float maxMagic = 10;

    [Header("Magic hiện tại")]
    public float currentMagic;

    //Hàm thêm item vào danh sách
    public void AddItem(Item itemToAdd)
    {
        //Is the item a key? nếu là chìa khóa thì sẽ cộng số chìa khóa thêm 1
        if (itemToAdd.isKey)
        {
            numberOfKey++;
        }
        else //Ngược lại thì sẽ thêm item vào danh sách
        {
            if (!items.Contains(itemToAdd))
            {
                items.Add(itemToAdd);
            }
        }
    }
}
