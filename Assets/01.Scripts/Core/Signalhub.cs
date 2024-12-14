public delegate void SkillChangingEvent(SkillInfo skillInfo);
public delegate void ReplaceSkillEvent(); // �� �� �־ ���� ������

public delegate void StageClearEvent(bool isClear);

public delegate void SpawnEnemiesEvent();

public delegate void ChangeStatValueEvent(StatType statType);

public delegate void BossRushEnterEvent(int level);

public static class Signalhub
{
    public static SkillChangingEvent OnSelectChnageSkillEvent;
    public static ReplaceSkillEvent OnReplaceSkillEvent;

    public static SpawnEnemiesEvent OnSpawnEnemiesEvent;

    public static StageClearEvent OnStageClearEvent;

    public static ChangeStatValueEvent OnChangeStatValueEvent;

    public static BossRushEnterEvent OnBossRushEnterEvent;
}
