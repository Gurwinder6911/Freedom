using UnityEngine;
using System.Collections;

[System.Serializable]
public class SaveData : MonoBehaviour
{
    private static SaveData _current;
    public static SaveData current
    {    get {
            if(_current==null)
            {
                _current = new SaveData();
            }
            return _current;
               }
    }

    public PlayerProfile Profile;
    public int toyCare;
    public int toyDolls;
}
