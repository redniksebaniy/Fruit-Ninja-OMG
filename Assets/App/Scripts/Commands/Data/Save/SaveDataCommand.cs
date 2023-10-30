using System.IO;
using App.Scripts.Architecture.Command;
using UnityEngine;

namespace App.Scripts.Commands.Data.Save
{
    public class SaveDataCommand<T> : ICommand where T : new()
    {
        private readonly string _dataFullPath;
        
        private readonly T _data;

        public SaveDataCommand(T data, string name, params string[] path)
        {
#if UNITY_EDITOR
            _dataFullPath = Path.GetFullPath(Path.Combine(Application.dataPath, Path.Combine(path), name));
#else
            _dataFullPath = Path.GetFullPath(Path.Combine(Application.persistentDataPath, name));
#endif
            _data = data;
        }
        
        public void Execute()
        {
            FileStream fileStream = File.Open(_dataFullPath, FileMode.OpenOrCreate);
            StreamWriter streamWriter = new(fileStream);
            
            string json = JsonUtility.ToJson(_data);
            streamWriter.Write(json);
            
            streamWriter.Close();
            fileStream.Close();
        }
    }
}