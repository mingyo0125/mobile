using UnityEngine;

public class SkillManager : MonoSingleTon<SkillManager>
{
    [SerializeField]
    private SkillListSO _skillListSO;

    private void Awake()
    {
        // ���÷������� SkillInfo �־��ּ�
    }
}
