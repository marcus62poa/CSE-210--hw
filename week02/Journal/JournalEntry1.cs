using System;

public class JournalEntry
{
    public string _date { get; set; }
    public string _prompt { get; set; }
    public string _response { get; set; }

    public JournalEntry(string prompt, string response)
    {
        _date = DateTime.Now.ToShortDateString();
        _prompt = prompt;
        _response = response;
    }

    public override string ToString()
    {
        return $"Date: {_date}\nPrompt: {_prompt}\nResponse: {_response}\n";
    }

    public string ToFileFormat()
    {
        return $"{_date}|{_prompt}|{_response}";
    }

    public static JournalEntry FromFileFormat(string line)
    {
        string[] parts = line.Split('|');
        return new JournalEntry(parts[1], parts[2]) { _date = parts[0] };
    }
}
