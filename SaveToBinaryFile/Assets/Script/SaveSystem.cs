using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{
    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter(); //Create binary formatter for changing data to binary

        string path = Application.persistentDataPath + "/player.bin";

        FileStream stream = new FileStream(path, FileMode.Create); //create file on system.

        PlayerData data = new PlayerData(player); //runs cTor in PlayerData, saves data.

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.bin";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

           PlayerData data = (PlayerData)formatter.Deserialize(stream); //Change back from binary

           stream.Close();

           return data;
        }

        else
        {
            Debug.Log("Save file not found in path: " + path);
            return null;
        }
    }
}
