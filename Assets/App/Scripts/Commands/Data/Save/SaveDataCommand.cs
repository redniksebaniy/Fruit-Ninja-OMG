using System.IO;
using System.Text;
using App.Scripts.Architecture.Command;
using App.Scripts.Commands.Data.Types.Base;
using UnityEngine;

namespace App.Scripts.Commands.Data.Save
{
    public class SaveDataCommand<T> : ICommand where T : ICustomData
    {
        private readonly string _dataFullPath;
        
        private readonly T _data;

        public SaveDataCommand(T data, string path, string name)
        {
            StringBuilder builder = new();
#if UNITY_EDITOR
            builder.Append(Application.dataPath);
            builder.Append(Path.DirectorySeparatorChar);
            builder.Append(path);
            builder.Append(Path.DirectorySeparatorChar);
            builder.Append(name);
#else
            builder.Append(Application.persistentDataPath);
            builder.Append(Path.DirectorySeparatorChar);
            builder.Append(name);
#endif
            _dataFullPath = builder.ToString();
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