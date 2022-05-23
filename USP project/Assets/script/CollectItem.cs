using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using TMPro;

public class CollectItem : MonoBehaviour
{
    [SerializeField] private Text appleText;
    private int items = 0;
    // Start is called before the first frame update
    // appleText = GetComponent<TMP_Text>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("apple"))
        {
            Destroy(collision.gameObject);
            items++;
            // Debug.Log("Apples: " + items);
            appleText.text = "Apple: " + items;
        }
    }
}
