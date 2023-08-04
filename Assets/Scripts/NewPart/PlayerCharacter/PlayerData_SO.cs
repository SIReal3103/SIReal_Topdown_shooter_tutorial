using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character/CharacterData")]
public class PlayerData_SO : ScriptableObject
{
    public int id;
    public string playerName;
    public int damage;
    public int currentHealth;
    public int maxHealth;

    public PlayerData GetDataInstance()
    {
        return new PlayerData()
        {
            id = this.id,
            playerName = this.playerName,
            damage = this.damage,
            maxHealth = this.maxHealth,
            currentHealth = this.currentHealth,
        };
    }
}
