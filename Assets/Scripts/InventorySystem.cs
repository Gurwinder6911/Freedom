using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public List<string> items;

    [SerializeField] Text counter;
    [SerializeField] GameObject inventory;

    private int count;

    // Start is called before the first frame update
    void Start()
    {
        items = new List<string>();
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ShowItems();
        OpenInventory();
    }

    private void OpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            inventory.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;

            ++count;
        }
        
        if (Input.GetKeyDown(KeyCode.E) && count == 2)
        {
            Cursor.lockState = CursorLockMode.Locked;
            inventory.SetActive(false);

            count = 0;
        }
    }

    private void ShowItems()
    {
        counter.text = items.Count.ToString();
    }

    public void UseHealth()
    {
        items.Remove("H");
    }
}
