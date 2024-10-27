using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Player SO", menuName = "ScriptableObjects/Player Data")]
public class PlayerSO : ScriptableObject
{
    [Header("Player life Settings")]
    [SerializeField] private int maxlife;
    [SerializeField] private float inmunityTime;

    [Header("Player Movement Settings")]
    [SerializeField] private float movementSpeed;

    [SerializeField] private float jumpForce;

    public int Maxlife { get => maxlife; set => maxlife = value; }
    public float InmunityTime { get => inmunityTime; set => inmunityTime = value; }

    public float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
    public float JumpForce { get => jumpForce; set => jumpForce = value; }
}
