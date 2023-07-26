using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class FileManager : MonoBehaviour
{
    public static void createEmpty(string file_path)
    {
        File.Create(file_path).Dispose();
    }


    
    public static void WriteBinary(string data, string file_path)
    {

        using (var stream = File.Open(file_path, FileMode.OpenOrCreate))
        {
            using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
            {
                writer.Write(data);
            }
        }

    }

}
