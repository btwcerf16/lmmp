using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class BuffUIHandler : MonoBehaviour
{
    public Transform buffPanel;
    public GameObject buffIconPrefab;

public Dictionary<Buff, List<GameObject>> activeIcons = new();


    public void ShowBuff(Buff buff)
    {
        StartCoroutine(BuffRoutine(buff));
        
    }

    public void HideBuff(Buff buff)
    {

        if (activeIcons.TryGetValue(buff, out List<GameObject> iconList))
        {
            foreach (GameObject icon in iconList)
            {
                if (icon != null)
                    Destroy(icon);
            }

        }
        activeIcons.Remove(buff);
    }
    private IEnumerator BuffRoutine(Buff buff)
    {
        GameObject icon = Instantiate(buffIconPrefab, buffPanel);
        icon.GetComponent<BuffIconUI>().SetBuffSprite(buff.Icon);

        if (!activeIcons.ContainsKey(buff))
        {
            activeIcons[buff] = new List<GameObject>();
        }


        activeIcons[buff].Add(icon);
        float timeRemaining = buff.Duration;
        while (timeRemaining > 0f)
        {
            if(icon != null) {

                icon.GetComponent<BuffIconUI>().UpdateTimer(timeRemaining);
                
                timeRemaining -= 0.1f;
            }
            yield return new WaitForSeconds(0.1f);

        }

    }

}
