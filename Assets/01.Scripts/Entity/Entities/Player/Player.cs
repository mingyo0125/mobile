using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Player : Entity<PlayerStateType, Player>
{
    [Space]
    [SerializeField]
    private PlayerStatSO _playerStatSO; 

    public PlayerSkillHolder SkillHolder { get; private set; }

    private Coroutine _hpRegenCoroutine;
    private WaitForSeconds _regenTime = new WaitForSeconds(1f);

    protected override void Awake()
    {
        base.Awake();

        SkillHolder = transform.Find("SkillHolder").GetComponent<PlayerSkillHolder>();

        Signalhub.OnChangeStatValueEvent += SetMaxHp;

        OnDieEvent += _ => WaveManager.Instance.EndStage(false);
        OnDieEvent += _ => Signalhub.OnStageClearEvent?.Invoke(false);
    }

    private void Start()
    {
        base.Initialize();
    }

    public override void Initialize()
    {
        base.Initialize();

        _hpRegenCoroutine = null;
    }

    private void SetMaxHp(StatType statType)
    {
        if(statType != StatType.MaxHp) { return; }

        float maxHp = EntityStatController.GetStatValue(StatType.MaxHp);
        float increaseValue = maxHp - MaxHP;

        _entityHpBar.UpdateMaxHp(MaxHP);

        MaxHP = maxHp;

        SetHp(increaseValue, new Color(0,0,0,0));
    }

    public override void TakedDamage(TakeDamageInfo takeDamageInfo)
    {
        base.TakedDamage(takeDamageInfo);

        StateMachine.ChangeState(PlayerStateType.Idle);

        if (!IsDead && _hpRegenCoroutine == null)
        {
            _hpRegenCoroutine = StartCoroutine(RegenerationCorou());
        }
    }

    private void Defeat()
    {
        GameManager.Instance.SetLastPlayerPos(transform.position);
        UIManager.Instance.CreateUI("DefeatedUI", Vector2.zero, null, UIGenerateType.STACKING, UIGenerateSortType.TOP, UIGenerateTweenType.Up, 0.3f);
    }

    protected override void FadeOut()
    {
        _spriteRenderer.DOFade(0f, 0.2f)
            .OnComplete(() =>
            {
                Defeat();
                gameObject.SetActive(false);
            });
    }

    public void GetItem(Item item)
    {
        // Dosomething
    }

    protected override void CreateStateMachine()
    {
        StateMachine = new PlayerStateMachine(this);
    }

    protected override void SetStat()
    {
        PlayerStat playerStat = new PlayerStat(_playerStatSO.PlayerStat);
        EntityStatController.Initialize(playerStat);
    }

    protected sealed override BaseStat GetStatSO()
    {
        if(_playerStatSO.PlayerStat != null)
        {
            return _playerStatSO.PlayerStat;
        }
        return null;
    }

    protected override string GetHudTextValue(float value)
    {
        return value.ToString();
    }

    // Àç»ý
    private IEnumerator RegenerationCorou()
    {
        while (HP < MaxHP)
        {
            float regenPercent = EntityStatController.GetStatValue(StatType.HPRegeneration);
            SetHp(Utils.CalculatePercent(MaxHP, regenPercent), Color.green);

            yield return _regenTime;
        }

        _hpRegenCoroutine = null;
    }
}
