using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShowCollectible : MonoBehaviour
{
    public MakeCollectibles item;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI description;
    public Image itemImage;
    public TextMeshProUGUI type;
    public TextMeshProUGUI quantity;
    public TextMeshProUGUI value;
    public TextMeshProUGUI actionText;
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = item.itemName;
        itemImage.sprite = item.image;
        nameText.enabled = true;
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject.tag == "Player")
        {
            actionText.text = $"Collected {nameText}! \n Quantity: {quantity}, value: {value}";
            Debug.Log(actionText.text);
            nameText.enabled = false;
            actionText.enabled = true;

            Destroy(gameObject);
            StartCoroutine(DestroyText());
        }   
    }

    IEnumerator DestroyText()
    {
        yield return new WaitForSecondsRealtime(2);
        actionText.enabled = false;
    }



}
