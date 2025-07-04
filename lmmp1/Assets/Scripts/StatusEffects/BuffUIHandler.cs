using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffUIHandler : MonoBehaviour
{
    public Transform buffPanel;
    public GameObject buffIconPrefab;

    public Dictionary<Sprite, GameObject> activeIcons = new();

    public void ShowBuff(Sprite buffSprite)
    {
        GameObject icon = Instantiate(buffIconPrefab, buffPanel);
        icon.GetComponent<BuffIconUI>().SetBuffSprite(buffSprite);
        activeIcons[buffSprite] = icon;
    }

    public void HideBuff(Sprite buffSprite)
    {
        if (activeIcons.TryGetValue(buffSprite, out GameObject icon))
        {
            Destroy(icon);
            activeIcons.Remove(buffSprite);
        }
    }
}
