using UnityEngine;

[CreateAssetMenu(fileName = "Ally", menuName = "Characters")]
public class AllyData : ScriptableObject
{
    public Ally Ally;
    public Sprite AllyBigSprite;
    public Sprite Background;
    public Sprite SuperpowerIcon;

    public int Health, Damage;

    public int Price;
}
