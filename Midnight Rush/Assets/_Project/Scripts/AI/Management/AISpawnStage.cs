using UnityEngine;

[System.Serializable]
public struct SpawnPreset
{
    public Transform position;
    public int count;
}

[System.Serializable]
public struct AISpawnStage
{
    public SpawnPreset[] presets;
    public float delayAfter;
}
