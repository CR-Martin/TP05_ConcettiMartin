using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Enemy SO", menuName = "ScriptableObjects/Enemy Data")]
public class EnemySO : ScriptableObject
{
    [Header("Enemy life Settings")]
    [SerializeField] private int maxlife;

    [Header("Bullet Settings")]
    [SerializeField] private int strength;
    [SerializeField] private float velocity;

    public int Strength { get => strength; set => strength = value; }
    public float Velocity { get => velocity; set => velocity = value; }
    public int Maxlife { get => maxlife; set => maxlife = value; }
}
