using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitializingAbstractionClass
{
    class Program
    {
        /// <summary>
        /// ジェネリックメソッドで自作クラスの規定値を設定する
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var model = new Hoge();
            model.InitializingAbstractionClass<Hoge>();
        }
    }

    /// <summary>
    /// Hogeクラス
    /// </summary>
    public class Hoge : BaseClass
    {
        public Nullable<byte> Hoge1 { get; set; }
        public Nullable<short> Hoge2 { get; set; }
        public Nullable<ushort> Hoge3 { get; set; }
        public Nullable<int> Hoge4 { get; set; }
        public Nullable<uint> Hoge5 { get; set; }
        public Nullable<long> Hoge6 { get; set; }
        public Nullable<ulong> Hoge7 { get; set; }
        public Nullable<float> Hoge8 { get; set; }
        public Nullable<double> Hoge9 { get; set; }
        public Nullable<decimal> Hoge10 { get; set; }
        public string Hoge11 { get; set; }
        public ChildHoge Hoge12 { get; set; }

    }

    /// <summary>
    /// Hogeクラスの子
    /// </summary>
    public class ChildHoge
    {
        public int Hoge1 { get; set; }
        public int Hoge2 { get; set; }
    }

    /// <summary>
    /// Baseクラス
    /// </summary>
    public class BaseClass
    {
        /// <summary>
        /// 特定の規定値で初期化を行う
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void InitializingAbstractionClass<T>()
        {
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var value = typeof(T).GetProperty(property.Name).GetValue(this, null);

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
                property.SetValue(this, value);
            }
        }
    }
}
