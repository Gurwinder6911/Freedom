using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] Text counter;
    [SerializeField] GameObject inventory;
    [SerializeField] PlayerScript player;
    [SerializeField] Button openInven;
    [SerializeField] Button closeInven;



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
        counter.text = PlayerData.Inv.Count.ToString();
    }

    public void UseHealth()
    {
        if (PlayerData.Health < 10 && PlayerData.Inv.Count > 0)
        {
            PlayerData.Inv.Remove("H");
            player.UseHealth(3F); 
        }
    }
}
