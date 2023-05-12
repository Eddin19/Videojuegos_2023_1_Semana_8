using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameRepository : MonoBehaviour
{
     private string savePath;

    private void Start()
    {
        savePath = Application.persistentDataPath + "/save.dat";
    }

    public void SaveData(GameData data)
    {
        FileStream file = File.Create(savePath);

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
    }

    public GameData GetSavedData()
    {
        if (File.Exists(savePath))
        {
            FileStream file = File.OpenRead(savePath);

            BinaryFormatter bf = new BinaryFormatter();
            GameData data = (GameData)bf.Deserialize(file);
            file.Close();

            return data;
        }
        else
        {
            return new GameData();
        }
    }

    public void DeleteData()
    {
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
            Debug.Log("Se eliminó la data guardada");
        }
        else
        {
            Debug.Log("No se encontró ninguna data guardada para eliminar");
        }
    }
}
