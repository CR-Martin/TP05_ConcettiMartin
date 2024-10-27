using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LifePickable SO", menuName = "ScriptableObjects/LifePickable Data")]

public class LifePickableSO : ScriptableObject
{
    [Header("Bullet Settings")]
    [SerializeField] private int amountOfLife;

    public int AmountOfLife { get => amountOfLife; set => amountOfLife = value; }
}
