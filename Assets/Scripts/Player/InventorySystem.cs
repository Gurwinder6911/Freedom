using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] Text counter;
    [SerializeField] Text counterShield;
    [SerializeField] GameObject inventory;
    [SerializeField] PlayerScript player;
    [SerializeField] GameObject armor;

    [SerializeField] float startTime;


    private bool isOpen;
    private bool isShieldOn;

    private float currentTime;

    void Start()
    {
        if (!isShieldOn)
        {
            currentTime = startTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isShieldOn && currentTime > 0)
        {
            currentTime -= 1 * Time.deltaTime;
        }
        else
        {
            armor.SetActive(false);
            isShieldOn = false;
            currentTime = startTime;
            PlayerData.IsSheildOn = false;
        }

        ShowItems();
        //OpenInventory();
    }

    public void OpenInventory()
    {
        if (isOpen)
        {
            Close();
        }
        else
        {
            Open();
        }
    }

    private void Open()
    {
        inventory.SetActive(true);
        //Cursor.lockState = CursorLockMode.Confined;
        isOpen = true;
    }

    private void Close()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        inventory.SetActive(false);
        isOpen = false;
    }

    private void ShowItems()
    {
        counter.text = PlayerData.Inv.Count(health => health == "H").ToString();
        counterShield.text = PlayerData.Inv.Count(shield => shield == "S").ToString();
    }

    public void UseHealth()
    {
        if (PlayerData.Health < 10 && PlayerData.Inv.Any(health => health == "H"))
        {
            PlayerData.Inv.Remove("H");
            player.UseHealth(3F); 
        }
    }

    public void UseShield()
    {
        if (!isShieldOn && PlayerData.Inv.Any(shield => shield == "S"))
        {
            isShieldOn = true;
            PlayerData.Inv.Remove("S");
            armor.SetActive(true);
            PlayerData.IsSheildOn = true;
        }
    }
}
