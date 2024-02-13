using UnityEngine;

namespace Source.Scripts.Data
{
    public static class DataExtensions
    {
        public static Vector3Data AsDataVector(this Vector3 vector) =>
            new Vector3Data(vector.x, vector.y, vector.z);

        public static Vector3 AsUnityVector(this Vector3Data vector3Data) =>
            new Vector3(vector3Data.X, vector3Data.Y, vector3Data.Z);

        public static QuaternionData AsDataQuaternion(this Quaternion quaternion) =>
            new QuaternionData(quaternion.x, quaternion.y, quaternion.z, quaternion.w);

        public static Quaternion AsUnityQuaternion(this QuaternionData quaternionData) =>
            new Quaternion(quaternionData.X, quaternionData.Y, quaternionData.Z, quaternionData.W);
        
        public static string ToJson(this object obj) => 
            JsonUtility.ToJson(obj);

        public static T ToDeserialized<T>(this string json) =>
            JsonUtility.FromJson<T>(json);
    }
}