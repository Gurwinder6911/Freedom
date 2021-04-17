using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpear : MonoBehaviour
{
    [System.Obsolete]
    public void DestroyTheSpear()
    {
        this.GetComponent<Animation>().Stop();
    }
}
