using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections;

public class Monster
{
    [XmlAttribute("name")]
    public string Name;
    public int Health;
}

[XmlRoot("MonsterCollection")]
public class MonsterContainer
{
    [XmlArray("Monsters")]
    [XmlArrayItem("Monster")]
    public List<Monster> Monsters = new List<Monster>();

    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(MonsterContainer));
        var stream = new FileStream(path, FileMode.Create);
        serializer.Serialize(stream, this);
        stream.Close();
    }

    public static MonsterContainer Load(string path)
    {
        var serializer = new XmlSerializer(typeof(MonsterContainer));
        var stream = new FileStream(path, FileMode.Open);
        var container = serializer.Deserialize(stream) as MonsterContainer;
        stream.Close();
        return container;
    }
}