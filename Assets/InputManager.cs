using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputManager : MonoBehaviour
{
    [SerializeField] TMP_Text textField;
    string storedText = "";

    public void AddText(string text)
    {
        storedText += text;
        UpdateDisplay();
    }
    public void RemoveText()
    {
        if (storedText.Length > 0) storedText = storedText.Remove(storedText.Length -1);
        UpdateDisplay();
    }
    private void UpdateDisplay()
    {
        textField.text = $"Name: {storedText}";
    }
}
