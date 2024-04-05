using UnityEngine;

public class CartridgePoint : MonoBehaviour
{
    [SerializeField] private Cartridge cartridge;
    [SerializeField] private int count;

    public Cartridge Cartridge => cartridge;
    public int Count => count;
}