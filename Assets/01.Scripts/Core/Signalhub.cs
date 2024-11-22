public delegate void SkillChangingEvent(SkillInfo skillInfo);

public static class Signalhub
{
    public static SkillChangingEvent OnSkillChangingEvent;
}
