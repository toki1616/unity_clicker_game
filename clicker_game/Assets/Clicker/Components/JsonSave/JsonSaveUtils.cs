using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace My.Save.Json
{
    // List 保存用のラッパークラス
    [Serializable]
    public class ListWrapper<T>
    {
        public List<T> list;

        public ListWrapper() { }

        public ListWrapper(List<T> list)
        {
            this.list = list;
        }
    }

    public static class JsonSaveUtils
    {
        /// <summary>
        /// 保存フォルダの取得 (PC : exeと同階層、スマホ : 安全な領域)
        /// </summary>
        /// <returns></returns>
        private static string GetSaveFolder()
        {
#if UNITY_STANDALONE
            //PC : 実行ファイルと同じ階層
            string root = Directory.GetParent(Application.dataPath).FullName;
            string folder = Path.Combine(root, "SaveData");
#else
            //iOS / Android / その他
            string folder = Path.Combine(Application.persistentDataPath, "SaveData");
#endif

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            return folder;
        }

        /// <summary>
        /// フルパス生成
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static string GetPath(string fileName)
        {
            return Path.Combine(GetSaveFolder(), fileName + ".json");
        }

        /// <summary>
        /// json形式で保存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <param name="data"></param>
        public static void Save<T>(string fileName, T data)
        {
            //Debug.Log($"JsonSaveUtils : Save");

            // List の場合は自動で ListWrapper に包む
            if (data is System.Collections.IList)
            {
                Type elementType = typeof(T).IsGenericType
                    ? typeof(T).GetGenericArguments()[0]
                    : typeof(object);

                Type wrapperType = typeof(ListWrapper<>).MakeGenericType(elementType);
                var wrapper = Activator.CreateInstance(wrapperType, data);

                string jsonList = JsonUtility.ToJson(wrapper, true);
                File.WriteAllText(GetPath(fileName), jsonList);
                return;
            }

            // 通常保存
            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(GetPath(fileName), json);
        }

        /// <summary>
        /// 保存したものをLoad
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static T Load<T>(string fileName) where T : new()
        {
            //Debug.Log($"JsonSaveUtils : Load");

            string path = GetPath(fileName);

            if (!File.Exists(path))
            {
                return new T(); //データが無い場合はデフォルト生成
            }

            string json = File.ReadAllText(path);

            // List<TElement> の場合は ListWrapper<TElement> として読み込む
            if (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(List<>))
            {
                Type elementType = typeof(T).GetGenericArguments()[0];
                Type wrapperType = typeof(ListWrapper<>).MakeGenericType(elementType);

                // wrapperType にデシリアライズ
                var wrapperObj = JsonUtility.FromJson(json, wrapperType);

                // wrapper.list を取り出す
                var listField = wrapperType.GetField("list");
                var listObj = listField.GetValue(wrapperObj);

                return (T)listObj;
            }

            // 通常の読み込み
            return JsonUtility.FromJson<T>(json);
        }
    }
}
