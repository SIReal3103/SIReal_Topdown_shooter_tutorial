using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "All Character", menuName = "Character/CharactersData")]
public class AllPlayerData_SO : ScriptableObject
{
    public List<PlayerData_SO> characters;
}
