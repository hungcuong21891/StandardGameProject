using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BaseFramework {
    /// <summary>
    /// Player prefs x.
    /// </summary>
    public class PlayerPrefsX {
        /// <summary>
        /// The endian diff1.
        /// </summary>
        static private int endianDiff1;
        /// <summary>
        /// The endian diff2.
        /// </summary>
        static private int endianDiff2;
        /// <summary>
        /// The index.
        /// </summary>
        static private int idx;
        /// <summary>
        /// The byte block.
        /// </summary>
        static private byte[] byteBlock;
        /// <summary>
        /// Array type.
        /// </summary>
        enum ArrayType {
            Float,
            Int32,
            Bool,
            String,
            Vector2,
            Vector3,
            Quaternion,
            Color
        }
        /// <summary>
        /// Sets the bool.
        /// </summary>
        /// <returns><c>true</c>, if bool was set, <c>false</c> otherwise.</returns>
        /// <param name="name">Name.</param>
        /// <param name="value">If set to <c>true</c> value.</param>
        public static bool SetBool(String name, bool value) {
            try {
                PlayerPrefs.SetInt(name, value ? 1 : 0);
            } catch {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Gets the bool.
        /// </summary>
        /// <returns><c>true</c>, if bool was gotten, <c>false</c> otherwise.</returns>
        /// <param name="name">Name.</param>
        public static bool GetBool(String name) {
            return PlayerPrefs.GetInt(name) == 1;
        }
        /// <summary>
        /// Gets the bool.
        /// </summary>
        /// <returns><c>true</c>, if bool was gotten, <c>false</c> otherwise.</returns>
        /// <param name="name">Name.</param>
        /// <param name="defaultValue">If set to <c>true</c> default value.</param>
        public static bool GetBool(String name, bool defaultValue) {
            return (1 == PlayerPrefs.GetInt(name, defaultValue ? 1 : 0));
        }
        /// <summary>
        /// Gets the long.
        /// </summary>
        /// <returns>The long.</returns>
        /// <param name="key">Key.</param>
        /// <param name="defaultValue">Default value.</param>
        public static long GetLong(string key, long defaultValue) {
            int lowBits, highBits;
            SplitLong(defaultValue, out lowBits, out highBits);
            lowBits = PlayerPrefs.GetInt(key + "_lowBits", lowBits);
            highBits = PlayerPrefs.GetInt(key + "_highBits", highBits);

            // unsigned, to prevent loss of sign bit.
            ulong ret = (uint)highBits;
            ret = (ret << 32);
            return (long)(ret | (ulong)(uint)lowBits);
        }
        /// <summary>
        /// Gets the long.
        /// </summary>
        /// <returns>The long.</returns>
        /// <param name="key">Key.</param>
        public static long GetLong(string key) {
            int lowBits = PlayerPrefs.GetInt(key + "_lowBits");
            int highBits = PlayerPrefs.GetInt(key + "_highBits");

            // unsigned, to prevent loss of sign bit.
            ulong ret = (uint)highBits;
            ret = (ret << 32);
            return (long)(ret | (ulong)(uint)lowBits);
        }
        /// <summary>
        /// Splits the long.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <param name="lowBits">Low bits.</param>
        /// <param name="highBits">High bits.</param>
        private static void SplitLong(long input, out int lowBits, out int highBits) {
            // unsigned everything, to prevent loss of sign bit.
            lowBits = (int)(uint)(ulong)input;
            highBits = (int)(uint)(input >> 32);
        }
        /// <summary>
        /// Sets the long.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        public static void SetLong(string key, long value) {
            int lowBits, highBits;
            SplitLong(value, out lowBits, out highBits);
            PlayerPrefs.SetInt(key + "_lowBits", lowBits);
            PlayerPrefs.SetInt(key + "_highBits", highBits);
        }
        /// <summary>
        /// Sets the vector2.
        /// </summary>
        /// <returns><c>true</c>, if vector2 was set, <c>false</c> otherwise.</returns>
        /// <param name="key">Key.</param>
        /// <param name="vector">Vector.</param>
        public static bool SetVector2(String key, Vector2 vector) {
            return SetFloatArray(key, new float[] { vector.x, vector.y });
        }
        /// <summary>
        /// Gets the vector2.
        /// </summary>
        /// <returns>The vector2.</returns>
        /// <param name="key">Key.</param>
        static Vector2 GetVector2(String key) {
            var floatArray = GetFloatArray(key);
            if (floatArray.Length < 2) {
                return Vector2.zero;
            }
            return new Vector2(floatArray[0], floatArray[1]);
        }
        /// <summary>
        /// Gets the vector2.
        /// </summary>
        /// <returns>The vector2.</returns>
        /// <param name="key">Key.</param>
        /// <param name="defaultValue">Default value.</param>
        public static Vector2 GetVector2(String key, Vector2 defaultValue) {
            if (PlayerPrefs.HasKey(key)) {
                return GetVector2(key);
            }
            return defaultValue;
        }
        /// <summary>
        /// Sets the vector3.
        /// </summary>
        /// <returns><c>true</c>, if vector3 was set, <c>false</c> otherwise.</returns>
        /// <param name="key">Key.</param>
        /// <param name="vector">Vector.</param>
        public static bool SetVector3(String key, Vector3 vector) {
            return SetFloatArray(key, new float[] { vector.x, vector.y, vector.z });
        }
        /// <summary>
        /// Gets the vector3.
        /// </summary>
        /// <returns>The vector3.</returns>
        /// <param name="key">Key.</param>
        public static Vector3 GetVector3(String key) {
            var floatArray = GetFloatArray(key);
            if (floatArray.Length < 3) {
                return Vector3.zero;
            }
            return new Vector3(floatArray[0], floatArray[1], floatArray[2]);
        }
        /// <summary>
        /// Gets the vector3.
        /// </summary>
        /// <returns>The vector3.</returns>
        /// <param name="key">Key.</param>
        /// <param name="defaultValue">Default value.</param>
        public static Vector3 GetVector3(String key, Vector3 defaultValue) {
            if (PlayerPrefs.HasKey(key)) {
                return GetVector3(key);
            }
            return defaultValue;
        }
        /// <summary>
        /// Sets the quaternion.
        /// </summary>
        /// <returns><c>true</c>, if quaternion was set, <c>false</c> otherwise.</returns>
        /// <param name="key">Key.</param>
        /// <param name="vector">Vector.</param>
        public static bool SetQuaternion(String key, Quaternion vector) {
            return SetFloatArray(key, new float[] { vector.x, vector.y, vector.z, vector.w });
        }
        /// <summary>
        /// Gets the quaternion.
        /// </summary>
        /// <returns>The quaternion.</returns>
        /// <param name="key">Key.</param>
        public static Quaternion GetQuaternion(String key) {
            var floatArray = GetFloatArray(key);
            if (floatArray.Length < 4) {
                return Quaternion.identity;
            }
            return new Quaternion(floatArray[0], floatArray[1], floatArray[2], floatArray[3]);
        }
        /// <summary>
        /// Gets the quaternion.
        /// </summary>
        /// <returns>The quaternion.</returns>
        /// <param name="key">Key.</param>
        /// <param name="defaultValue">Default value.</param>
        public static Quaternion GetQuaternion(String key, Quaternion defaultValue) {
            if (PlayerPrefs.HasKey(key)) {
                return GetQuaternion(key);
            }
            return defaultValue;
        }
        /// <summary>
        /// Sets the color.
        /// </summary>
        /// <returns><c>true</c>, if color was set, <c>false</c> otherwise.</returns>
        /// <param name="key">Key.</param>
        /// <param name="color">Color.</param>
        public static bool SetColor(String key, Color color) {
            return SetFloatArray(key, new float[] { color.r, color.g, color.b, color.a });
        }
        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <returns>The color.</returns>
        /// <param name="key">Key.</param>
        public static Color GetColor(String key) {
            var floatArray = GetFloatArray(key);
            if (floatArray.Length < 4) {
                return new Color(0.0f, 0.0f, 0.0f, 0.0f);
            }
            return new Color(floatArray[0], floatArray[1], floatArray[2], floatArray[3]);
        }
        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <returns>The color.</returns>
        /// <param name="key">Key.</param>
        /// <param name="defaultValue">Default value.</param>
        public static Color GetColor(String key, Color defaultValue) {
            if (PlayerPrefs.HasKey(key)) {
                return GetColor(key);
            }
            return defaultValue;
        }
        /// <summary>
        /// Sets the bool array.
        /// </summary>
        /// <returns><c>true</c>, if bool array was set, <c>false</c> otherwise.</returns>
        /// <param name="key">Key.</param>
        /// <param name="boolArray">Bool array.</param>
        public static bool SetBoolArray(String key, bool[] boolArray) {
            // Make a byte array that's a multiple of 8 in length, plus 5 bytes to store the number of entries as an int32 (+ identifier)
            // We have to store the number of entries, since the boolArray length might not be a multiple of 8, so there could be some padded zeroes
            var bytes = new byte[(boolArray.Length + 7) / 8 + 5];
            bytes[0] = System.Convert.ToByte(ArrayType.Bool);   // Identifier
            var bits = new BitArray(boolArray);
            bits.CopyTo(bytes, 5);
            Initialize();
            ConvertInt32ToBytes(boolArray.Length, bytes); // The number of entries in the boolArray goes in the first 4 bytes

            return SaveBytes(key, bytes);
        }
        /// <summary>
        /// Gets the bool array.
        /// </summary>
        /// <returns>The bool array.</returns>
        /// <param name="key">Key.</param>
        public static bool[] GetBoolArray(String key) {
            if (PlayerPrefs.HasKey(key)) {
                var bytes = System.Convert.FromBase64String(PlayerPrefs.GetString(key));
                if (bytes.Length < 5) {
                    Debug.LogError("Corrupt preference file for " + key);
                    return new bool[0];
                }
                if ((ArrayType)bytes[0] != ArrayType.Bool) {
                    Debug.LogError(key + " is not a boolean array");
                    return new bool[0];
                }
                Initialize();

                // Make a new bytes array that doesn't include the number of entries + identifier (first 5 bytes) and turn that into a BitArray
                var bytes2 = new byte[bytes.Length - 5];
                System.Array.Copy(bytes, 5, bytes2, 0, bytes2.Length);
                var bits = new BitArray(bytes2);
                // Get the number of entries from the first 4 bytes after the identifier and resize the BitArray to that length, then convert it to a boolean array
                bits.Length = ConvertBytesToInt32(bytes);
                var boolArray = new bool[bits.Count];
                bits.CopyTo(boolArray, 0);

                return boolArray;
            }
            return new bool[0];
        }
        /// <summary>
        /// Gets the bool array.
        /// </summary>
        /// <returns>The bool array.</returns>
        /// <param name="key">Key.</param>
        /// <param name="defaultValue">If set to <c>true</c> default value.</param>
        /// <param name="defaultSize">Default size.</param>
        public static bool[] GetBoolArray(String key, bool defaultValue, int defaultSize) {
            if (PlayerPrefs.HasKey(key)) {
                return GetBoolArray(key);
            }
            var boolArray = new bool[defaultSize];
            for (int i = 0; i < defaultSize; i++) {
                boolArray[i] = defaultValue;
            }
            return boolArray;
        }
        /// <summary>
        /// Sets the string array.
        /// </summary>
        /// <returns><c>true</c>, if string array was set, <c>false</c> otherwise.</returns>
        /// <param name="key">Key.</param>
        /// <param name="stringArray">String array.</param>
        public static bool SetStringArray(String key, String[] stringArray) {
            var bytes = new byte[stringArray.Length + 1];
            bytes[0] = System.Convert.ToByte(ArrayType.String); // Identifier
            Initialize();

            // Store the length of each string that's in stringArray, so we can extract the correct strings in GetStringArray
            for (var i = 0; i < stringArray.Length; i++) {
                if (stringArray[i] == null) {
                    Debug.LogError("Can't save null entries in the string array when setting " + key);
                    return false;
                }
                if (stringArray[i].Length > 255) {
                    Debug.LogError("Strings cannot be longer than 255 characters when setting " + key);
                    return false;
                }
                bytes[idx++] = (byte)stringArray[i].Length;
            }

            try {
                PlayerPrefs.SetString(key, System.Convert.ToBase64String(bytes) + "|" + String.Join("", stringArray));
            } catch {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Gets the string array.
        /// </summary>
        /// <returns>The string array.</returns>
        /// <param name="key">Key.</param>
        public static String[] GetStringArray(String key) {
            if (PlayerPrefs.HasKey(key)) {
                var completeString = PlayerPrefs.GetString(key);
                var separatorIndex = completeString.IndexOf("|"[0]);
                if (separatorIndex < 4) {
                    Debug.LogError("Corrupt preference file for " + key);
                    return new String[0];
                }
                var bytes = System.Convert.FromBase64String(completeString.Substring(0, separatorIndex));
                if ((ArrayType)bytes[0] != ArrayType.String) {
                    Debug.LogError(key + " is not a string array");
                    return new String[0];
                }
                Initialize();

                var numberOfEntries = bytes.Length - 1;
                var stringArray = new String[numberOfEntries];
                var stringIndex = separatorIndex + 1;
                for (var i = 0; i < numberOfEntries; i++) {
                    int stringLength = bytes[idx++];
                    if (stringIndex + stringLength > completeString.Length) {
                        Debug.LogError("Corrupt preference file for " + key);
                        return new String[0];
                    }
                    stringArray[i] = completeString.Substring(stringIndex, stringLength);
                    stringIndex += stringLength;
                }

                return stringArray;
            }
            return new String[0];
        }
        /// <summary>
        /// Gets the string array.
        /// </summary>
        /// <returns>The string array.</returns>
        /// <param name="key">Key.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <param name="defaultSize">Default size.</param>
        public static String[] GetStringArray(String key, String defaultValue, int defaultSize) {
            if (PlayerPrefs.HasKey(key)) {
                return GetStringArray(key);
            }
            var stringArray = new String[defaultSize];
            for (int i = 0; i < defaultSize; i++) {
                stringArray[i] = defaultValue;
            }
            return stringArray;
        }
        /// <summary>
        /// Sets the int array.
        /// </summary>
        /// <returns><c>true</c>, if int array was set, <c>false</c> otherwise.</returns>
        /// <param name="key">Key.</param>
        /// <param name="intArray">Int array.</param>
        public static bool SetIntArray(String key, int[] intArray) {
            return SetValue(key, intArray, ArrayType.Int32, 1, ConvertFromInt);
        }
        /// <summary>
        /// Sets the float array.
        /// </summary>
        /// <returns><c>true</c>, if float array was set, <c>false</c> otherwise.</returns>
        /// <param name="key">Key.</param>
        /// <param name="floatArray">Float array.</param>
        public static bool SetFloatArray(String key, float[] floatArray) {
            return SetValue(key, floatArray, ArrayType.Float, 1, ConvertFromFloat);
        }
        /// <summary>
        /// Sets the vector2 array.
        /// </summary>
        /// <returns><c>true</c>, if vector2 array was set, <c>false</c> otherwise.</returns>
        /// <param name="key">Key.</param>
        /// <param name="vector2Array">Vector2 array.</param>
        public static bool SetVector2Array(String key, Vector2[] vector2Array) {
            return SetValue(key, vector2Array, ArrayType.Vector2, 2, ConvertFromVector2);
        }
        /// <summary>
        /// Sets the vector3 array.
        /// </summary>
        /// <returns><c>true</c>, if vector3 array was set, <c>false</c> otherwise.</returns>
        /// <param name="key">Key.</param>
        /// <param name="vector3Array">Vector3 array.</param>
        public static bool SetVector3Array(String key, Vector3[] vector3Array) {
            return SetValue(key, vector3Array, ArrayType.Vector3, 3, ConvertFromVector3);
        }
        /// <summary>
        /// Sets the quaternion array.
        /// </summary>
        /// <returns><c>true</c>, if quaternion array was set, <c>false</c> otherwise.</returns>
        /// <param name="key">Key.</param>
        /// <param name="quaternionArray">Quaternion array.</param>
        public static bool SetQuaternionArray(String key, Quaternion[] quaternionArray) {
            return SetValue(key, quaternionArray, ArrayType.Quaternion, 4, ConvertFromQuaternion);
        }
        /// <summary>
        /// Sets the color array.
        /// </summary>
        /// <returns><c>true</c>, if color array was set, <c>false</c> otherwise.</returns>
        /// <param name="key">Key.</param>
        /// <param name="colorArray">Color array.</param>
        public static bool SetColorArray(String key, Color[] colorArray) {
            return SetValue(key, colorArray, ArrayType.Color, 4, ConvertFromColor);
        }
        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <returns><c>true</c>, if value was set, <c>false</c> otherwise.</returns>
        /// <param name="key">Key.</param>
        /// <param name="array">Array.</param>
        /// <param name="arrayType">Array type.</param>
        /// <param name="vectorNumber">Vector number.</param>
        /// <param name="convert">Convert.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        private static bool SetValue<T>(String key, T array, ArrayType arrayType, int vectorNumber, Action<T, byte[], int> convert) where T : IList {
            var bytes = new byte[(4 * array.Count) * vectorNumber + 1];
            bytes[0] = System.Convert.ToByte(arrayType);    // Identifier
            Initialize();

            for (var i = 0; i < array.Count; i++) {
                convert(array, bytes, i);
            }
            return SaveBytes(key, bytes);
        }
        /// <summary>
        /// Converts from int.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <param name="bytes">Bytes.</param>
        /// <param name="i">The index.</param>
        private static void ConvertFromInt(int[] array, byte[] bytes, int i) {
            ConvertInt32ToBytes(array[i], bytes);
        }
        /// <summary>
        /// Converts from float.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <param name="bytes">Bytes.</param>
        /// <param name="i">The index.</param>
        private static void ConvertFromFloat(float[] array, byte[] bytes, int i) {
            ConvertFloatToBytes(array[i], bytes);
        }
        /// <summary>
        /// Converts from vector2.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <param name="bytes">Bytes.</param>
        /// <param name="i">The index.</param>
        private static void ConvertFromVector2(Vector2[] array, byte[] bytes, int i) {
            ConvertFloatToBytes(array[i].x, bytes);
            ConvertFloatToBytes(array[i].y, bytes);
        }
        /// <summary>
        /// Converts from vector3.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <param name="bytes">Bytes.</param>
        /// <param name="i">The index.</param>
        private static void ConvertFromVector3(Vector3[] array, byte[] bytes, int i) {
            ConvertFloatToBytes(array[i].x, bytes);
            ConvertFloatToBytes(array[i].y, bytes);
            ConvertFloatToBytes(array[i].z, bytes);
        }
        /// <summary>
        /// Converts from quaternion.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <param name="bytes">Bytes.</param>
        /// <param name="i">The index.</param>
        private static void ConvertFromQuaternion(Quaternion[] array, byte[] bytes, int i) {
            ConvertFloatToBytes(array[i].x, bytes);
            ConvertFloatToBytes(array[i].y, bytes);
            ConvertFloatToBytes(array[i].z, bytes);
            ConvertFloatToBytes(array[i].w, bytes);
        }
        /// <summary>
        /// Converts the color of the from.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <param name="bytes">Bytes.</param>
        /// <param name="i">The index.</param>
        private static void ConvertFromColor(Color[] array, byte[] bytes, int i) {
            ConvertFloatToBytes(array[i].r, bytes);
            ConvertFloatToBytes(array[i].g, bytes);
            ConvertFloatToBytes(array[i].b, bytes);
            ConvertFloatToBytes(array[i].a, bytes);
        }
        /// <summary>
        /// Gets the int array.
        /// </summary>
        /// <returns>The int array.</returns>
        /// <param name="key">Key.</param>
        public static int[] GetIntArray(String key) {
            var intList = new List<int>();
            GetValue(key, intList, ArrayType.Int32, 1, ConvertToInt);
            return intList.ToArray();
        }
        /// <summary>
        /// Gets the int array.
        /// </summary>
        /// <returns>The int array.</returns>
        /// <param name="key">Key.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <param name="defaultSize">Default size.</param>
        public static int[] GetIntArray(String key, int defaultValue, int defaultSize) {
            if (PlayerPrefs.HasKey(key)) {
                return GetIntArray(key);
            }
            var intArray = new int[defaultSize];
            for (int i = 0; i < defaultSize; i++) {
                intArray[i] = defaultValue;
            }
            return intArray;
        }
        /// <summary>
        /// Gets the float array.
        /// </summary>
        /// <returns>The float array.</returns>
        /// <param name="key">Key.</param>
        public static float[] GetFloatArray(String key) {
            var floatList = new List<float>();
            GetValue(key, floatList, ArrayType.Float, 1, ConvertToFloat);
            return floatList.ToArray();
        }
        /// <summary>
        /// Gets the float array.
        /// </summary>
        /// <returns>The float array.</returns>
        /// <param name="key">Key.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <param name="defaultSize">Default size.</param>
        public static float[] GetFloatArray(String key, float defaultValue, int defaultSize) {
            if (PlayerPrefs.HasKey(key)) {
                return GetFloatArray(key);
            }
            var floatArray = new float[defaultSize];
            for (int i = 0; i < defaultSize; i++) {
                floatArray[i] = defaultValue;
            }
            return floatArray;
        }
        /// <summary>
        /// Gets the vector2 array.
        /// </summary>
        /// <returns>The vector2 array.</returns>
        /// <param name="key">Key.</param>
        public static Vector2[] GetVector2Array(String key) {
            var vector2List = new List<Vector2>();
            GetValue(key, vector2List, ArrayType.Vector2, 2, ConvertToVector2);
            return vector2List.ToArray();
        }
        /// <summary>
        /// Gets the vector2 array.
        /// </summary>
        /// <returns>The vector2 array.</returns>
        /// <param name="key">Key.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <param name="defaultSize">Default size.</param>
        public static Vector2[] GetVector2Array(String key, Vector2 defaultValue, int defaultSize) {
            if (PlayerPrefs.HasKey(key)) {
                return GetVector2Array(key);
            }
            var vector2Array = new Vector2[defaultSize];
            for (int i = 0; i < defaultSize; i++) {
                vector2Array[i] = defaultValue;
            }
            return vector2Array;
        }
        /// <summary>
        /// Gets the vector3 array.
        /// </summary>
        /// <returns>The vector3 array.</returns>
        /// <param name="key">Key.</param>
        public static Vector3[] GetVector3Array(String key) {
            var vector3List = new List<Vector3>();
            GetValue(key, vector3List, ArrayType.Vector3, 3, ConvertToVector3);
            return vector3List.ToArray();
        }
        /// <summary>
        /// Gets the vector3 array.
        /// </summary>
        /// <returns>The vector3 array.</returns>
        /// <param name="key">Key.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <param name="defaultSize">Default size.</param>
        public static Vector3[] GetVector3Array(String key, Vector3 defaultValue, int defaultSize) {
            if (PlayerPrefs.HasKey(key)) {
                return GetVector3Array(key);
            }
            var vector3Array = new Vector3[defaultSize];
            for (int i = 0; i < defaultSize; i++) {
                vector3Array[i] = defaultValue;
            }
            return vector3Array;
        }
        /// <summary>
        /// Gets the quaternion array.
        /// </summary>
        /// <returns>The quaternion array.</returns>
        /// <param name="key">Key.</param>
        public static Quaternion[] GetQuaternionArray(String key) {
            var quaternionList = new List<Quaternion>();
            GetValue(key, quaternionList, ArrayType.Quaternion, 4, ConvertToQuaternion);
            return quaternionList.ToArray();
        }
        /// <summary>
        /// Gets the quaternion array.
        /// </summary>
        /// <returns>The quaternion array.</returns>
        /// <param name="key">Key.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <param name="defaultSize">Default size.</param>
        public static Quaternion[] GetQuaternionArray(String key, Quaternion defaultValue, int defaultSize) {
            if (PlayerPrefs.HasKey(key)) {
                return GetQuaternionArray(key);
            }
            var quaternionArray = new Quaternion[defaultSize];
            for (int i = 0; i < defaultSize; i++) {
                quaternionArray[i] = defaultValue;
            }
            return quaternionArray;
        }
        /// <summary>
        /// Gets the color array.
        /// </summary>
        /// <returns>The color array.</returns>
        /// <param name="key">Key.</param>
        public static Color[] GetColorArray(String key) {
            var colorList = new List<Color>();
            GetValue(key, colorList, ArrayType.Color, 4, ConvertToColor);
            return colorList.ToArray();
        }
        /// <summary>
        /// Gets the color array.
        /// </summary>
        /// <returns>The color array.</returns>
        /// <param name="key">Key.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <param name="defaultSize">Default size.</param>
        public static Color[] GetColorArray(String key, Color defaultValue, int defaultSize) {
            if (PlayerPrefs.HasKey(key)) {
                return GetColorArray(key);
            }
            var colorArray = new Color[defaultSize];
            for (int i = 0; i < defaultSize; i++) {
                colorArray[i] = defaultValue;
            }
            return colorArray;
        }
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="list">List.</param>
        /// <param name="arrayType">Array type.</param>
        /// <param name="vectorNumber">Vector number.</param>
        /// <param name="convert">Convert.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        private static void GetValue<T>(String key, T list, ArrayType arrayType, int vectorNumber, Action<T, byte[]> convert) where T : IList {
            if (PlayerPrefs.HasKey(key)) {
                var bytes = System.Convert.FromBase64String(PlayerPrefs.GetString(key));
                if ((bytes.Length - 1) % (vectorNumber * 4) != 0) {
                    Debug.LogError("Corrupt preference file for " + key);
                    return;
                }
                if ((ArrayType)bytes[0] != arrayType) {
                    Debug.LogError(key + " is not a " + arrayType.ToString() + " array");
                    return;
                }
                Initialize();

                var end = (bytes.Length - 1) / (vectorNumber * 4);
                for (var i = 0; i < end; i++) {
                    convert(list, bytes);
                }
            }
        }
        /// <summary>
        /// Converts to int.
        /// </summary>
        /// <param name="list">List.</param>
        /// <param name="bytes">Bytes.</param>
        private static void ConvertToInt(List<int> list, byte[] bytes) {
            list.Add(ConvertBytesToInt32(bytes));
        }
        /// <summary>
        /// Converts to float.
        /// </summary>
        /// <param name="list">List.</param>
        /// <param name="bytes">Bytes.</param>
        private static void ConvertToFloat(List<float> list, byte[] bytes) {
            list.Add(ConvertBytesToFloat(bytes));
        }
        /// <summary>
        /// Converts to vector2.
        /// </summary>
        /// <param name="list">List.</param>
        /// <param name="bytes">Bytes.</param>
        private static void ConvertToVector2(List<Vector2> list, byte[] bytes) {
            list.Add(new Vector2(ConvertBytesToFloat(bytes), ConvertBytesToFloat(bytes)));
        }
        /// <summary>
        /// Converts to vector3.
        /// </summary>
        /// <param name="list">List.</param>
        /// <param name="bytes">Bytes.</param>
        private static void ConvertToVector3(List<Vector3> list, byte[] bytes) {
            list.Add(new Vector3(ConvertBytesToFloat(bytes), ConvertBytesToFloat(bytes), ConvertBytesToFloat(bytes)));
        }
        /// <summary>
        /// Converts to quaternion.
        /// </summary>
        /// <param name="list">List.</param>
        /// <param name="bytes">Bytes.</param>
        private static void ConvertToQuaternion(List<Quaternion> list, byte[] bytes) {
            list.Add(new Quaternion(ConvertBytesToFloat(bytes), ConvertBytesToFloat(bytes), ConvertBytesToFloat(bytes), ConvertBytesToFloat(bytes)));
        }
        /// <summary>
        /// Converts the color of the to.
        /// </summary>
        /// <param name="list">List.</param>
        /// <param name="bytes">Bytes.</param>
        private static void ConvertToColor(List<Color> list, byte[] bytes) {
            list.Add(new Color(ConvertBytesToFloat(bytes), ConvertBytesToFloat(bytes), ConvertBytesToFloat(bytes), ConvertBytesToFloat(bytes)));
        }
        /// <summary>
        /// Shows the type of the array.
        /// </summary>
        /// <param name="key">Key.</param>
        public static void ShowArrayType(String key) {
            var bytes = System.Convert.FromBase64String(PlayerPrefs.GetString(key));
            if (bytes.Length > 0) {
                ArrayType arrayType = (ArrayType)bytes[0];
                Debug.Log(key + " is a " + arrayType.ToString() + " array");
            }
        }
        /// <summary>
        /// Initialize this instance.
        /// </summary>
        private static void Initialize() {
            if (System.BitConverter.IsLittleEndian) {
                endianDiff1 = 0;
                endianDiff2 = 0;
            } else {
                endianDiff1 = 3;
                endianDiff2 = 1;
            }
            if (byteBlock == null) {
                byteBlock = new byte[4];
            }
            idx = 1;
        }
        /// <summary>
        /// Saves the bytes.
        /// </summary>
        /// <returns><c>true</c>, if bytes was saved, <c>false</c> otherwise.</returns>
        /// <param name="key">Key.</param>
        /// <param name="bytes">Bytes.</param>
        private static bool SaveBytes(String key, byte[] bytes) {
            try {
                PlayerPrefs.SetString(key, System.Convert.ToBase64String(bytes));
            } catch {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Converts the float to bytes.
        /// </summary>
        /// <param name="f">F.</param>
        /// <param name="bytes">Bytes.</param>
        private static void ConvertFloatToBytes(float f, byte[] bytes) {
            byteBlock = System.BitConverter.GetBytes(f);
            ConvertTo4Bytes(bytes);
        }
        /// <summary>
        /// Converts the bytes to float.
        /// </summary>
        /// <returns>The bytes to float.</returns>
        /// <param name="bytes">Bytes.</param>
        private static float ConvertBytesToFloat(byte[] bytes) {
            ConvertFrom4Bytes(bytes);
            return System.BitConverter.ToSingle(byteBlock, 0);
        }
        /// <summary>
        /// Converts the int32 to bytes.
        /// </summary>
        /// <param name="i">The index.</param>
        /// <param name="bytes">Bytes.</param>
        private static void ConvertInt32ToBytes(int i, byte[] bytes) {
            byteBlock = System.BitConverter.GetBytes(i);
            ConvertTo4Bytes(bytes);
        }
        /// <summary>
        /// Converts the bytes to int32.
        /// </summary>
        /// <returns>The bytes to int32.</returns>
        /// <param name="bytes">Bytes.</param>
        private static int ConvertBytesToInt32(byte[] bytes) {
            ConvertFrom4Bytes(bytes);
            return System.BitConverter.ToInt32(byteBlock, 0);
        }
        /// <summary>
        /// Converts the to4 bytes.
        /// </summary>
        /// <param name="bytes">Bytes.</param>
        private static void ConvertTo4Bytes(byte[] bytes) {
            bytes[idx] = byteBlock[endianDiff1];
            bytes[idx + 1] = byteBlock[1 + endianDiff2];
            bytes[idx + 2] = byteBlock[2 - endianDiff2];
            bytes[idx + 3] = byteBlock[3 - endianDiff1];
            idx += 4;
        }
        /// <summary>
        /// Converts the from4 bytes.
        /// </summary>
        /// <param name="bytes">Bytes.</param>
        private static void ConvertFrom4Bytes(byte[] bytes) {
            byteBlock[endianDiff1] = bytes[idx];
            byteBlock[1 + endianDiff2] = bytes[idx + 1];
            byteBlock[2 - endianDiff2] = bytes[idx + 2];
            byteBlock[3 - endianDiff1] = bytes[idx + 3];
            idx += 4;
        }
    }
}