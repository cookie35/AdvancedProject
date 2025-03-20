using UnityEngine;

// 각 UI의 상태를 한 번에 업데이트

public class UICondition : MonoBehaviour
{
    public Condition health;
    public Condition stamina;

    void Start()
    {
        PlayerManager.Instance.Player.condition.uiCondition = this;    
    }

}
