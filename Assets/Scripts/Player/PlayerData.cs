using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData
{
    private static List<string> inv = new List<string>();
    private static float health = 10F;

    public static List<string> Inv { get { return inv; } set { inv = value; } }

    public static float Health { get { return health; } set { health = value; } }
}
