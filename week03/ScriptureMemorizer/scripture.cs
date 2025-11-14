using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class Scripture
{
   
    private Reference _reference;
    private List<Word> _words;
    private static Random _random = new Random();

    
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = ParseTextToWords(text);
    }

    
    private List<Word> ParseTextToWords(string text)
    {
        var list = new List<Word>();

        
        string[] tokens = text.Split(' ');
        foreach (string token in tokens)
        {
            if (!string.IsNullOrWhiteSpace(token))
            {
                list.Add(new Word(token));
            }
        }
        return list;
    }

   
    public void HideRandomWords(int numberToHide)
    {
        List<int> visibleIndexes = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden() && _words[i].GetLetterCount() > 0)
            {
                visibleIndexes.Add(i);
            }
        }

        if (visibleIndexes.Count == 0)
        {
            
            return;
        }

        
        int toHide = Math.Min(numberToHide, visibleIndexes.Count);

        
        for (int i = 0; i < toHide; i++)
        {
            int pickListIndex = _random.Next(visibleIndexes.Count);
            int wordIndex = visibleIndexes[pickListIndex];
            _words[wordIndex].Hide();
            
            visibleIndexes.RemoveAt(pickListIndex);
            if (visibleIndexes.Count == 0) break;
        }
    }

   
    public string GetDisplayText()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(_reference.GetDisplayText());
        sb.AppendLine();

        for (int i = 0; i < _words.Count; i++)
        {
            sb.Append(_words[i].GetDisplayText());
            if (i < _words.Count - 1)
            {
                sb.Append(" ");
            }
        }

        return sb.ToString();
    }

   
    public bool IsCompletelyHidden()
    {
        foreach (var w in _words)
        {
            if (w.GetLetterCount() > 0 && !w.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}
