using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public List<CharacterStats> characters = new List<CharacterStats>();
    private CharacterStats activeCharacter;

    public void SetActiveCharacter(string name)
    {
        activeCharacter = characters.Find(c => c.characterName.ToLower() == name.ToLower());
        if (activeCharacter == null)
        {
            Debug.LogWarning("Character not found!");
        }
    }

    public void IncreaseStat(string stat, int amount)
    {
        if (activeCharacter == null) return;

        switch (stat.ToLower())
        {
            case "energy": activeCharacter.energy += amount; break;
            case "endurance": activeCharacter.endurance += amount; break;
            case "strength": activeCharacter.strength += amount; break;
            case "movementspeed": activeCharacter.movementSpeed += amount; break;
            case "excavating": activeCharacter.excavating += amount; break;
            case "intelligence": activeCharacter.intelligence += amount; break;
            default: Debug.LogWarning("Invalid stat name!"); break;
        }
    }

    public int GetStat(string stat)
    {
        if (activeCharacter == null) return -1;

        switch (stat.ToLower())
        {
            case "energy": return activeCharacter.energy;
            case "endurance": return activeCharacter.endurance;
            case "strength": return activeCharacter.strength;
            case "movementspeed": return activeCharacter.movementSpeed;
            case "excavating": return activeCharacter.excavating;
            case "intelligence": return activeCharacter.intelligence;
            default:
                Debug.LogWarning("Invalid stat name!");
                return -1;
        }
    }
}
