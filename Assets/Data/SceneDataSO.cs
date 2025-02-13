using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SceneData", menuName = "Data/SceneData")]
public class SceneDataSO : ScriptableObject
{
    [Header("Player Data")]
    public Vector3 playerPosition;
    public Quaternion playerRotation;
    public float playerHealth;
    public List<string> playerInventory;
}
