using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    //Hình ảnh item
    public Sprite itemSprite;
    //Mô tả item
    public string itemDescription;
    //Có là chìa khóa không?
    public bool isKey;
}
