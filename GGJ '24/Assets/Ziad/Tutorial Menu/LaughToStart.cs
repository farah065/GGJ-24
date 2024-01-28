using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Windows.Speech;
using Debug = UnityEngine.Debug;

public class LaughToStart : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, Action> keywordActions = new();

    public bool isLaughing;
    public int LaughCount;

    void Start()
    {
        keywordActions.Add("A", Laugh);
        keywordActions.Add("H", Laugh);
        keywordActions.Add("HA", Laugh);
        keywordActions.Add("HAHA", Laugh);
        keywordActions.Add("HAHAHA", Laugh);
        keywordActions.Add("HAHAHAHA", Laugh);
        keywordActions.Add("HU", Laugh);
        keywordActions.Add("HUHU", Laugh);
        keywordActions.Add("HUHUHU", Laugh);
        keywordActions.Add("HUHUHUHU", Laugh);
        keywordActions.Add("HO", Laugh);
        keywordActions.Add("HOHO", Laugh);
        keywordActions.Add("HOHOHO", Laugh);
        keywordActions.Add("HOHOHOHO", Laugh);
        keywordActions.Add("HEE", Laugh);
        keywordActions.Add("HEEHEE", Laugh);
        keywordActions.Add("HEEHEEHEE", Laugh);
        keywordActions.Add("HEEHEEHEEHEE", Laugh);

        keywordRecognizer = new KeywordRecognizer(keywordActions.Keys.ToArray(), ConfidenceLevel.Low);
        keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognized;
        keywordRecognizer.Start();
    }

    void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Keyword: " + args.text);
        keywordActions[args.text].Invoke();
    }

    void Laugh()
    {
        LaughCount++;
    }
}
