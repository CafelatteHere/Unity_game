using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShowCollectible : MonoBehaviour
{
    [SerializeField] MakeCollectibles item;

    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] Image itemImage;
    [SerializeField] TextMeshProUGUI type;
    [SerializeField] TextMeshProUGUI quantity;
    [SerializeField] TextMeshProUGUI value;
    [SerializeField] TextMeshProUGUI actionText;

    void Start()
    {
        nameText.text = item.itemName;
        quantity.text = item.quantity.ToString();
        value.text = item.value.ToString();
        itemImage.sprite = item.image;
        nameText.enabled = true;
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject.tag == "Player")
        {
            actionText.text = $"Collected {nameText.text.ToString()}! \n Quantity: {quantity.text}, value: {value.text.ToString()}";
            Debug.Log(actionText.text);
            itemImage.gameObject.SetActive(false);
            nameText.gameObject.SetActive(false);
            actionText.gameObject.SetActive(true);
            StartCoroutine(WaitBeforeDestroy());
            nameText.enabled = false;
            

            
        }   
    }

    IEnumerator WaitBeforeDestroy()
    {
        yield return new WaitForSecondsRealtime(1);
        Destroy(gameObject);
    }



}
