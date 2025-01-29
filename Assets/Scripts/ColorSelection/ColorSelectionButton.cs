using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelectionButton : MonoBehaviour
{
    public Image paddleReference;

    public bool isColorPlayer = false;

    private Button _uiButton;
    public void OnButtonClick()
    {
        _uiButton = GetComponent<Button>();

        paddleReference.color = _uiButton.colors.normalColor;

        if (isColorPlayer)
        {
            SaveController.Instance.colorPlayer = paddleReference.color;
        }
        else
        {
            SaveController.Instance.colorEnemy = paddleReference.color;
        }
    }
}
