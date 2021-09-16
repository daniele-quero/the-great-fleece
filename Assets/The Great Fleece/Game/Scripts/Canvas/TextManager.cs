using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    [SerializeField]
    private Text _tooFar;

    private IEnumerator TextFade(Text text)
    {
        Color textColor = text.color = new Color(1, 1, 1, 1);
        for (float a = 1; a >= 0; a -= 0.015f)
        {
            Color newColor = new Color(textColor.r, textColor.g, textColor.b, a);
            text.color = newColor;
            yield return new WaitForSeconds(0.025f);
        }
    }

    public void CoinTooFarAlert()
    {
        StartCoroutine("TextFade", _tooFar);
    }
}
