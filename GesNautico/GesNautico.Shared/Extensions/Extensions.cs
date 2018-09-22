using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GesNautico.Shared.Extensions
{
    public static class Extensions
    {

        ///https://stackoverflow.com/questions/1253725/convert-ienumerable-to-datatable
        public static DataTable ToDataTable<T>(this IEnumerable<T> items)
        {
            // Create the result table, and gather all properties of a T        
            DataTable table = new DataTable(typeof(T).Name);
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Add the properties as columns to the datatable
            foreach (var prop in props)
            {
                Type propType = prop.PropertyType;

                // Is it a nullable type? Get the underlying type 
                if (propType.IsGenericType && propType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                {
                    propType = new NullableConverter(propType).UnderlyingType;
                }
                table.Columns.Add(prop.Name, propType);
            }

            // Add the property values per T as rows to the datatable
            foreach (var item in items)
            {
                var values = new object[props.Length];
                for (var i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }
                table.Rows.Add(values);
            }

            return table;
        }


        public static bool IsGUID(this string testString)
        {
            if (string.IsNullOrEmpty(testString) || testString.Equals("00000000-0000-0000-0000-000000000000"))
            {
                return false;
            }
            return true;
        }

        public static bool ValidEmail(this string email)
        {
            Regex regex = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");
            bool isEmail = Regex.IsMatch(email, regex.ToString(), RegexOptions.IgnoreCase);
            return isEmail;
        }


        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> collection)
        {
            ObservableCollection<T> list = new ObservableCollection<T>();

            foreach (T item in collection)
            {
                list.Add(item);
            }

            return list;
        }

        public static T ToObject<T>(this DataRow dataRow) where T : new()
        {
            T item = new T();
            foreach (DataColumn column in dataRow.Table.Columns)
            {
                PropertyInfo property = item.GetType().GetProperty(column.ColumnName);

                if (property != null && dataRow[column] != DBNull.Value)
                {
                    object result = Convert.ChangeType(dataRow[column], property.PropertyType);
                    property.SetValue(item, result, null);
                }
            }

            return item;
        }


        static public int ToAge(this DateTime dateOfBirth)
        {
            if (DateTime.Today.Month < dateOfBirth.Month ||
            DateTime.Today.Month == dateOfBirth.Month &&
             DateTime.Today.Day < dateOfBirth.Day)
            {
                return DateTime.Today.Year - dateOfBirth.Year - 1;
            }
            else
            {
                return DateTime.Today.Year - dateOfBirth.Year;
            }
        }

        /// http://www.extensionmethod.net/1592/csharp/array/toimage
        public static Image ToImage(this byte[] bytes)
        {
            if (bytes != null)
            {
                return Image.FromStream(new MemoryStream(bytes));
            }
            else
            {
                return null;
            }            
        }

        public static byte[] ConvertToByteArray(this System.IO.Stream stream)
        {
            var streamLength = Convert.ToInt32(stream.Length);
            byte[] data = new byte[streamLength + 1];

            //convert to to a byte array
            stream.Read(data, 0, streamLength);
            stream.Close();

            return data;
        }


        public static byte[] ImageToByteArray(this Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }

        public static ImageSource ByteToImageSource(this byte[] imageData)
        {
            BitmapImage bitImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(imageData);
            bitImg.BeginInit();
            bitImg.StreamSource = ms;
            bitImg.EndInit();
            ImageSource imgSrc = bitImg as ImageSource;
            return imgSrc;
        }
    }
}
