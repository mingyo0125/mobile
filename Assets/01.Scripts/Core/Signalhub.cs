public delegate void SkillChangingEvent(SkillInfo skillInfo);
public delegate void ReplaceSkillEvent(); // �� �� �־ ���� ������

public delegate void SpawnEnemiesEvent();

public static class Signalhub
{
    public static SkillChangingEvent OnSelectChnageSkillEvent;
    public static ReplaceSkillEvent OnReplaceSkillEvent;

    public static SpawnEnemiesEvent OnSpawnEnemiesEvent;
}
