using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

//创建不同物体的背包
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/New Inventory")]
public class Inventory: ScriptableObject
{
    public List<Item> itemList = new List<Item>();
}
