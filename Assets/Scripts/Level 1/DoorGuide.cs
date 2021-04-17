using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorGuide : MonoBehaviour
{
    [SerializeField] Text guide;

    private void OnTriggerEnter(Collider other)
    {
        guide.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        guide.gameObject.SetActive(false);
    }
}
