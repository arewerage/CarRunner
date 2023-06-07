using System;

namespace _Project.Scripts.Extensions
{
    public static class EnumExtensions
    {
        private static readonly Random _random = new();
            
        public static bool TryGetNextByDirection<T>(this T myEnum, int axis, out T nextValue) where T : Enum
        {
            T[] array = (T[])Enum.GetValues(myEnum.GetType());
            int index = Array.IndexOf(array, myEnum) + axis;

            if (index >= array.Length || index < 0)
            {
                nextValue = default;
                return false;
            }

            nextValue = array[index];
            return true;
        }
        
        public static T Random<T>() where T : Enum
        {
            Array array = Enum.GetValues(typeof(T));
            return (T) array.GetValue(_random.Next(array.Length));
        }
    }
}