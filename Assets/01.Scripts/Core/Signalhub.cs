public delegate void SkillChangingEvent(SkillInfo skillInfo);
public delegate void ReplaceSkillEvent(); // 꽉 차 있어서 변경 했을때

public delegate void StageClearEvent(bool isClear);

public delegate void SpawnEnemiesEvent();

public delegate void ChangeStatValueEvent(StatType statType);

public static class Signalhub
{
    public static SkillChangingEvent OnSelectChnageSkillEvent;
    public static ReplaceSkillEvent OnReplaceSkillEvent;

    public static SpawnEnemiesEvent OnSpawnEnemiesEvent;

    public static StageClearEvent OnStageClearEvent;

    public static ChangeStatValueEvent OnChangeStatValueEvent;
}
