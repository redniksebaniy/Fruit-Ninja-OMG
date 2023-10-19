using System.IO;
using System.Text;
using App.Scripts.Architecture.Command;
using App.Scripts.UI.Commands.Data.Types.Base;
using UnityEngine;

namespace App.Scripts.UI.Commands.Data.Load
{
    public class LoadDataCommand<T> : ICommand where T : ICustomData
    {
        private readonly string _dataFullPath;
        
        public T Data;

        public LoadDataCommand(string path, string name)
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