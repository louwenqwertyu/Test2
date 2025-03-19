using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

//������ͬ����ı���
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/New Inventory")]
public class Inventory: ScriptableObject
{
    public List<Item> itemList = new List<Item>();
}
