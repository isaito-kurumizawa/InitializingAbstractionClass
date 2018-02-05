using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitializingAbstractionClass
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = new Hoge();
            InitializingAbstractionClass<Hoge>(model);
        }

        /// <summary>
        /// 抽象化クラスの初期化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        static void InitializingAbstractionClass<T>(T obj)
        {
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var value = typeof(T).GetProperty(property.Name).GetValue(obj, null);

                // 値がない場合に初期化
                if (value == null)
                {
                    var returnType = property.GetMethod.ReturnType;

                    // string型は既定値を空白にする
                    if (returnType == typeof(string))
                        value = string.Empty;
                    // Nullable型は既定値を0にする
                    else if (returnType == typeof(Nullable<byte>))
                        value = (byte)0;
                    else if (returnType == typeof(Nullable<short>))
                        value = (short)0;
                    else if (returnType == typeof(Nullable<ushort>))
                        value = (ushort)0;
                    else if (returnType == typeof(Nullable<int>))
                        value = (int)0;
                    else if (returnType == typeof(Nullable<uint>))
                        value = (uint)0;
                    else if (returnType == typeof(Nullable<long>))
                        value = (long)0;
                    else if (returnType == typeof(Nullable<ulong>))
                        value = (ulong)0;
                    else if (returnType == typeof(Nullable<float>))
                        value = (float)0;
                    else if (returnType == typeof(Nullable<double>))
                        value = (double)0;
                    else if (returnType == typeof(Nullable<decimal>))
                        value = (decimal)0;
                    // その他、自前クラス等を初期化する
                    else
                    {
                        var currentType = Type.GetType(typeof(T).GetProperty(property.Name).PropertyType.FullName);
                        value = Activator.CreateInstance(currentType, null);
                    }
                }
                property.SetValue(obj, value);
            }
        }
    }

    public class Hoge
    {
        public Nullable<byte> hoge1 { get; set; }
        public Nullable<short> hoge2 { get; set; }
        public Nullable<ushort> hoge3 { get; set; }
        public Nullable<int> hoge4 { get; set; }
        public Nullable<uint> hoge5 { get; set; }
        public Nullable<long> hoge6 { get; set; }
        public Nullable<ulong> hoge7 { get; set; }
        public Nullable<float> hoge8 { get; set; }
        public Nullable<double> hoge9 { get; set; }
        public Nullable<decimal> hoge10 { get; set; }
        public string hoge11 { get; set; }
        public ChildHoge hoge12 { get; set; }
    }
    public class ChildHoge
    {
        public int hoge1 { get; set; }
        public int hoge2 { get; set; }
    }
}
