using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public List<string> items;

    [SerializeField] Text counter;
    [SerializeField] GameObject inventory;
    [SerializeField] PlayerScript player;
    [SerializeField] Button openInven;
    [SerializeField] Button closeInven;


    // Start is called before the first frame update
    void Start()
    {
        items = PlayerData.Inv;
    }

    // Update is called once per frame
    void Update()
    {
        ShowItems();
        //OpenInventory();
    }

    public void OpenInventory()
    {
        inventory.SetActive(true);
        //Cursor.lockState = CursorLockMode.Confined;
        openInven.gameObject.SetActive(false);
        closeInven.gameObject.SetActive(true);
    }

    public void CloseInventory()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        inventory.SetActive(false);
        openInven.gameObject.SetActive(true);
        closeInven.gameObject.SetActive(false);
    }

    private void ShowItems()
    {
        counter.text = items.Count.ToString();
    }

    public void UseHealth()
    {
        if (PlayerData.Health < 10)
        {
            items.Remove("H");
            player.UseHealth(3F); 
        }
    }
}
