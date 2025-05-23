using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public string GetInteractPrompt();
    public void OnInteract();
}
public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData data;

    public string GetInteractPrompt()
    {
        string str = $"{data.displayName}\n{data.description}";
        return str;
    }

    public void OnInteract()
    {
        if (data.type == ItemType.UnItem)  //아이템이 아니라면 상호작용 x
            return;

        if (data.type == ItemType.Consumable || data.type == ItemType.Equipable)
        {
            if (gameObject.tag == "DestroyConsumable")  //파괴 가능한 오브젝트만 파괴
            {
                Destroy(gameObject);
            }
        }
        
        CharacterManager.Instance.Player.itemData = data;
        CharacterManager.Instance.Player.addItem?.Invoke();
    }
}
