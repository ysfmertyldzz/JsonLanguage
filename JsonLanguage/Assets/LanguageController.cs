using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class LanguageController : MonoBehaviour
{
    [SerializeField] private TextAsset currentJson;

    [SerializeField] private TextAsset[] languages;

    [Header("UI")]
    [SerializeField] private Text playText;
    [SerializeField] private Text exitText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            ChangeLanguage(0);

        if (Input.GetKeyDown(KeyCode.S))
            ChangeLanguage(1);

        if (Input.GetKeyDown(KeyCode.D))
            ChangeLanguage(2);
    }

    public void ChangeLanguage(int _languageIndex)//0
    {
        currentJson = languages[_languageIndex];

        LanguageData data = new LanguageData();

        data = JsonUtility.FromJson<LanguageData>(currentJson.text);

        UpdateDisplay(data);
    }

    private void UpdateDisplay(LanguageData data)
    {
        playText.text = data.playButton;
        exitText.text = data.exitButton;
    }
}

public class LanguageData
{
    public string playButton;
    public string exitButton;
}