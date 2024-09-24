using UnityEngine;

public class EntityAnimator : MonoBehaviour
{
    private Animator _animator;
    public Animator AnimatorCompo => _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetFloat(string AnimationName, float value)
    {
        _animator.SetFloat(AnimationName, value);
    }
}