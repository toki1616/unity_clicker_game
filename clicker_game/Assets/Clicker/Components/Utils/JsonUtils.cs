using System;
using UnityEngine;

namespace My.ClickerGame.Utils
{
    [Serializable]
    public class JsonUtils
    {
        [Serializable]
        private class Wrapper<T>
        {
            public T[] Items;

            public Wrapper(T[] items)
            {
                Items = items;
            }
        }

        public static string GetJsonFromArray<T>(T[] array)
        {
            // Convert the array to JSON
            return JsonUtility.ToJson(new Wrapper<T>(array));
        }
    }
}
