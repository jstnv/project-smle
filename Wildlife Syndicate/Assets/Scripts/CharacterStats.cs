using UnityEngine;

[System.Serializable]
public class CharacterStats
{
    public string characterName;

    // Current stats
    public int energy = 100;
    public int endurance = 10;
    public int strength = 10;
    public int movementSpeed = 5;
    public int excavating = 10;
    public int intelligence = 10;

    // Potential stats (max values)
    public int maxEnergy = 120;
    public int maxEndurance = 20;
    public int maxStrength = 20;
    public int maxMovementSpeed = 10;
    public int maxExcavating = 15;
    public int maxIntelligence = 25;

    // XP and levels
    public int energyXP = 0, energyLevel = 1;
    public int enduranceXP = 0, enduranceLevel = 1;
    public int strengthXP = 0, strengthLevel = 1;
    public int movementSpeedXP = 0, movementSpeedLevel = 1;
    public int excavatingXP = 0, excavatingLevel = 1;
    public int intelligenceXP = 0, intelligenceLevel = 1;

    // Leveling logic
    private const int baseXP = 100; // Base XP needed to level up

    // Add XP to a stat
    public void AddXP(string stat, int xp)
    {
        switch (stat.ToLower())
        {
            case "energy": ProcessLevelUp(ref energyXP, ref energyLevel, ref energy, maxEnergy, xp); break;
            case "endurance": ProcessLevelUp(ref enduranceXP, ref enduranceLevel, ref endurance, maxEndurance, xp); break;
            case "strength": ProcessLevelUp(ref strengthXP, ref strengthLevel, ref strength, maxStrength, xp); break;
            case "movementspeed": ProcessLevelUp(ref movementSpeedXP, ref movementSpeedLevel, ref movementSpeed, maxMovementSpeed, xp); break;
            case "excavating": ProcessLevelUp(ref excavatingXP, ref excavatingLevel, ref excavating, maxExcavating, xp); break;
            case "intelligence": ProcessLevelUp(ref intelligenceXP, ref intelligenceLevel, ref intelligence, maxIntelligence, xp); break;
            default: Debug.LogWarning("Invalid stat name!"); break;
        }
    }

    // Handle leveling logic
    private void ProcessLevelUp(ref int currentXP, ref int level, ref int statValue, int maxStat, int xpGained)
    {
        // Check if stat has reached its potential
        if (statValue >= maxStat)
        {
            Debug.Log($"{statValue} has reached the potential of {maxStat}. No more XP can be gained.");
            currentXP = 0; // Reset XP if stat is already at max
            return;
        }

        currentXP += xpGained;

        while (currentXP >= GetXPToLevel(level) && statValue < maxStat)
        {
            if (statValue < maxStat)
            {
                currentXP -= GetXPToLevel(level);
                level++;
                statValue++; // Increase stat with level
            }
            else
            {
                currentXP = 0; // Reset XP if stat is maxed
                break;
            }
        }
    }

    // Calculate XP needed for the next level
    private int GetXPToLevel(int level)
    {
        return Mathf.FloorToInt(baseXP * Mathf.Pow(1.25f, level - 1)); // XP requirement increases by 25% per level.
    }
}
