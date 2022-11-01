using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public Item currentItem;
    public List<Item> items = new List<Item>();
    public int numberOfKey;

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
