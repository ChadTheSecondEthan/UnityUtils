using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public static class SavedData
{
    public static void PutWithJson(string key, object value)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + $"/{key}.bin";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, JsonUtility.ToJson(value));
        stream.Close();
    }

    public static void Put(string key, object value)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + $"/{key}.bin";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, value);
        stream.Close();
    }

    public static void Delete(string key)
    {
        File.Delete(Application.persistentDataPath + $"/{key}.bin");
    }

    public static T GetFromJson<T>(string key, T defaultValue) 
    {
        string path = Application.persistentDataPath + $"/{key}.bin";

        if (!File.Exists(path))
            return defaultValue;

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);

        object value = formatter.Deserialize(stream);
        stream.Close();
        return JsonUtility.FromJson<T>((string) value);
    }

    public static T Get<T>(string key, T defaultValue)
    {
        string path = Application.persistentDataPath + $"/{key}.bin";

        if (!File.Exists(path))
            return defaultValue;

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);

        object value = formatter.Deserialize(stream);
        stream.Close();
        return (T)value;
    }
}