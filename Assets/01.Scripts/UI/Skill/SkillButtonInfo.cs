
public class SkillButtonInfo
{
    public string Name { get; private set; }
    public string Description { get; private set; }

    public float CoolTime { get; private set; }

    public SkillButtonInfo(string name, string description, float coolTime)
    {
        this.Name = name;
        this.Description = description;
        this.CoolTime = coolTime;
    }
}
