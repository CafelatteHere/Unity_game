using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="New Collectible Item", menuName ="Collectible Item")]
public class MakeCollectibles : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public string type;
    public int value;
    public int quantity;
    public Sprite image;

    public void Print ()
    {
        Debug.Log(itemName);
    }

}

