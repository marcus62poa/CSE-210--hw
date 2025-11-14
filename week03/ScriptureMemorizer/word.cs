using System;
using System.Text;

public class Word
{
    
    private string _text;
    private bool _isHidden;

    // Constructor
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

   
    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    
    public string GetDisplayText()
    {
        if (!_isHidden)
        {
            return _text;
        }

        
        StringBuilder sb = new StringBuilder();
        foreach (char c in _text)
        {
            if (char.IsLetter(c))
            {
                sb.Append('_');
            }
            else
            {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }

    public int GetLetterCount()
    {
        int count = 0;
        foreach (char c in _text)
        {
            if (char.IsLetter(c)) count++;
        }
        return count;
    }
}
