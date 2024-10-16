using UnityEngine;

public interface IGUI
{
    void GenerateUI(Transform parent, UIGenerateType generateType);
    void RemoveUI();
    void UpdateUI();
}
