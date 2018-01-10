using System;
using System.Collections.Generic;
using System.Linq;

namespace FlappyPosLogic {
    public static class LinqHelper {
        public static T[] CreateArray<T>(int length, Func<int, T> initializer) {
            var array = new T[length];

            for (var i = 0; i < length; i++) {
                array[i] = initializer(i);
            }

            return array;
        }

        public static T Random<T>(this IEnumerable<T> e) {
            var array = e.ToArray();
            return array[UnityEngine.Random.Range(0, array.Length)];
        }
    }
}
