using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsServiceApi.BL.Types
{
    public class EnumValue
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }

    public static class EnumExtention
    {
        public static List<EnumValue> GetValues<T>()
        {
            List <EnumValue> value = new List<EnumValue>();
            foreach (var itemType in Enum.GetValues(typeof(T)))
            {
                value.Add(new EnumValue
                {
                    Name = Enum.GetName(typeof(T), itemType),
                    Value = (int)itemType
                });
            }
            return value;
        }
    }
}
