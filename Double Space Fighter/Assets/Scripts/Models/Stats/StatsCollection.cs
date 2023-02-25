using System.Collections.Generic;

public class StatsCollection
{
    public Health Health => (Health) _stats[nameof(Health)];

    private readonly Dictionary<string, IStat> _stats = new();

    public Dictionary<string, IStat>.ValueCollection.Enumerator GetEnumerator()
    {
        return _stats.Values.GetEnumerator();
    }

    public void Set(Health health)
    {
        _stats.Add(nameof(Health), health);
    }

    public void Set(Shield shield)
    {
        _stats.Add(nameof(Shield), shield);
    }
}