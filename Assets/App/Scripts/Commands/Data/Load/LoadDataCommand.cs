using System.IO;
using App.Scripts.Architecture.Command;
using App.Scripts.Commands.Data.Save;
using UnityEngine;

namespace App.Scripts.Commands.Data.Load
{
    public class LoadDataCommand<T> : ICommand where T : new()
    {
        private readonly string _dataFullPath;
        
        public T Data;

        public LoadDataCommand(string name, params string[] path)
        {
#if UNITY_EDITOR
            _dataFullPath = Path.GetFullPath(Path.Combine(Application.dataPath, Path.Combine(path), name));
#else
            _dataFullPath = Path.GetFullPath(Path.Combine(Application.persistentDataPath, name));
#endif
            
            if (!File.Exists(_dataFullPath))
            {
                File.Create(_dataFullPath).Close();
                new SaveDataCommand<T>(new T(), name, path).Execute();
            }
        }
        
        public void Execute()
        {
            FileStream fileStream = File.Open(_dataFullPath, FileMode.OpenOrCreate);
            StreamReader streamReader = new(fileStream);
            
            string json = streamReader.ReadToEnd();
            
            streamReader.Close();
            fileStream.Close();
            
            Data = JsonUtility.FromJson<T>(json) ?? new();
        }
    }
}