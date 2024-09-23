using UnityEngine;

public class EntityAnimator : MonoBehaviour
{
    private Animator _animator;
    public Animator AnimatorCompo => _animator;

    private void Awake()
    {
        Debug.Log(transform.parent);
        Debug.Log(gameObject);
        _animator = GetComponent<Animator>();
    }

    public void SetFloat(string AnimationName, float value)
    {
        Debug.Log($"{gameObject.transform.parent}: value");
        _animator.SetFloat(AnimationName, value);
    }
}