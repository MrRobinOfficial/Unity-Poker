using System;
using System.Collections.Generic;
using UnityEngine;
using uSaveable;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityPoker.TempSave;

namespace UnityPoker
{
    public class TempSave : MonoBehaviour, ISerializationCallbackReceiver, ISaverObject
    {
        public enum GenderType
        {
            Male,
            Female,
        }

        [System.Serializable]
        public struct UserData : ISaver
        {
            public string firstName;
            public string lastName;
            public int age;
            public GenderType gender;

            public override string ToString()
            {
                var builder = new System.Text.StringBuilder();

                builder.AppendLine("--------");
                builder.AppendLine($"{firstName} {lastName}");
                builder.AppendLine($"Age={age}");
                builder.AppendLine(gender.ToString());
                builder.AppendLine("--------");

                return builder.ToString();
            }
        }

        public string id;
        public UserData data;

        [System.Serializable]
        private struct TransformData : ISaver
        {
            public Vector3 position;
            public Vector3 rotation;
            public Vector3 scale;
        }

        private TransformData transformData;

        public Guid ID => System.Guid.Parse("6b5f588c-629f-406e-a9a3-4e4190374d02");

        public ICollection<ISaver> Savers => new HashSet<ISaver>()
        {
            data,
            transformData,
        };

        private void Start()
        {
            data = new UserData
            {
                firstName = "Robin",
                lastName = "Johannesson",
                age = 21,
                gender = GenderType.Male,
            };
        }

        //[ContextMenu(nameof(LoadData), isValidateFunction: false, 1000150)]
        //private void LoadData()
        //{
        //    if (!SaveManager.TryLoad<UserData>(id, out var saver))
        //        return;

        //    data = saver.data;
        //    Debug.Log(saver.data);
        //}

        //[ContextMenu(nameof(SaveData), isValidateFunction: false, 1000150)]
        //private void SaveData()
        //{
        //    var saver = new Saver<UserData>(id, data);
        //    SaveManager.Save(saver, overwrite: true);
        //}

        [ContextMenu(nameof(DeleteData), isValidateFunction: false, 1000550)]
        private void DeleteData() => SaveManager.Delete(id);

        public void OnBeforeSerialize()
        {
            if (!string.IsNullOrEmpty(id))
                return;

            id = System.Guid.NewGuid().ToString();
        }

        public void OnAfterDeserialize() { }

        public void LoadData(Saver<UserData> saver)
        {
            data = saver.data;
            Debug.Log(saver.data);
        }

        public Saver<UserData> SaveData() => new Saver<UserData>(id, data);
    }
}
