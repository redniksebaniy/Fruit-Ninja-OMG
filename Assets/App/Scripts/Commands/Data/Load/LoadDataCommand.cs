using System.IO;
using App.Scripts.Architecture.Command;
using App.Scripts.Commands.Data.Types.Base;
using UnityEngine;

namespace App.Scripts.Commands.Data.Load
{
    public class LoadDataCommand<T> : ICommand where T : ICustomData
    {
        private readonly string _dataFullPath;
        
        public T Data;

        public LoadDataCommand(string name, params string[] path)
        {
#if UNITY_EDITOR
            _dataFullPath = Path.Combine(Application.dataPath, Path.Combine(path), name);
#else
            _dataFullPath = Path.Combine(Application.persistentDataPath, name);
#endif
        }
        
        public void Execute()
        {
            StreamReader streamReader = new StreamReader(_dataFullPath);
            string json = streamReader.ReadToEnd();
            streamReader.Close();
            
            Data = JsonUtility.FromJson<T>(json);
        }
    }
}