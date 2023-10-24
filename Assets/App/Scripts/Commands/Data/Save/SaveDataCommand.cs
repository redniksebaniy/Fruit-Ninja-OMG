using System.IO;
using App.Scripts.Architecture.Command;
using App.Scripts.Commands.Data.Types.Base;
using UnityEngine;

namespace App.Scripts.Commands.Data.Save
{
    public class SaveDataCommand<T> : ICommand where T : ICustomData
    {
        private readonly string _dataFullPath;
        
        private readonly T _data;

        public SaveDataCommand(T data, string name, params string[] path)
        {
#if UNITY_EDITOR
            _dataFullPath = Path.Combine(Application.dataPath, Path.Combine(path), name);
#else
            _dataFullPath = Path.Combine(Application.persistentDataPath, name);
#endif
            _data = data;
        }
        
        public void Execute()
        {
            StreamWriter streamReader = new StreamWriter(_dataFullPath);
            string json = JsonUtility.ToJson(_data);
            streamReader.Write(json);
            streamReader.Close();
        }
    }
}