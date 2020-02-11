namespace Bsoft.Convertor
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TrueTypeToUnicode
    {
        private BsoftCharMap _charMap = new BsoftCharMap();
        private int _length = 0;
        private StringBuilder _strToConvert = new StringBuilder();
        private Dictionary<string, string> _unmappedStrList = new Dictionary<string, string>();

        private void AddUnMappedString(string unMappedStr)
        {
            if (!this._unmappedStrList.ContainsKey(unMappedStr))
            {
                this._unmappedStrList[unMappedStr] = unMappedStr;
            }
        }

        private bool ConvertHalantaChar(int position, ref string strToMap, ref string mapped)
        {
            if (!this.GetSubString(this._strToConvert, position, 1, ref strToMap))
            {
                return false;
            }
            return this._charMap.ConvertHalantaChar(strToMap, ref mapped);
        }

        private int ConvertMulitChars(int position, ref string strToMap, ref string mapped)
        {
            int length = 3;
            bool flag = false;
            while (length > 1)
            {
                if ((this._length - position) >= length)
                {
                    flag = this.ConvertMulitChars(position, length, ref strToMap, ref mapped);
                }
                if (flag)
                {
                    return length;
                }
                length--;
            }
            return 0;
        }

        private bool ConvertMulitChars(int position, int length, ref string strToMap, ref string mapped)
        {
            return (this.GetSubString(this._strToConvert, position, length, ref strToMap) && this._charMap.ConvertDoubleChar(strToMap, ref mapped));
        }

        private bool ConvertSingleChar(int position, ref string strToMap, ref string mapped)
        {
            return (this.GetSubString(this._strToConvert, position, 1, ref strToMap) && this._charMap.ConvertSingleChar(strToMap, ref mapped));
        }

        private StringBuilder ConvertToUnicode()
        {
            this._unmappedStrList.Clear();
            StringBuilder builder = new StringBuilder();
            try
            {
                this._strToConvert = this._strToConvert.Replace("{]", "]{").Replace("{}", "}{");
                this._length = this._strToConvert.Length;
                bool flag = false;
                string output = string.Empty;
                if (this._length <= 0)
                {
                    return builder;
                }
                int startIndex = 0;
                string str2 = string.Empty;
                string strMapped = string.Empty;
                int length = 0;
                int num3 = 0;
                int num4 = 0;
                char ch = '\0';
                int num5 = 0;
            Label_008C:
                flag = false;
                str2 = string.Empty;
                strMapped = string.Empty;
                length = 1;
                if (!this.GetSubString(this._strToConvert, startIndex, length, ref output))
                {
                    return builder;
                }
                ch = Convert.ToChar(output);
                if (ch < '\x0015')
                {
                    strMapped = ch.ToString();
                    flag = true;
                }
                else if ((ch >= '0') && (ch <= '9'))
                {
                    flag = this._charMap.ConvertNumber(ch.ToString(), ref strMapped);
                }
                else
                {
                    string str4;
                    if (ch == 'l')
                    {
                        output = string.Empty;
                        length = 1;
                        if (!this.GetSubString(this._strToConvert, startIndex + 1, length, ref str2))
                        {
                            return builder;
                        }
                        flag = this._charMap.ConvertHalantaChar(str2, ref strMapped);
                        if (flag && ((str2 == "i") || (str2 == ")")))
                        {
                            str4 = string.Empty;
                            if (!this.GetSubString(this._strToConvert, startIndex + 2, length, ref str4))
                            {
                                return builder;
                            }
                            if (str4 == "f")
                            {
                                flag = true;
                            }
                            strMapped = string.Empty;
                        }
                        if (flag)
                        {
                            if (this.GetSubString(this._strToConvert, startIndex + 1, 3, ref str2) && (str2 == "i^\x00ab"))
                            {
                                flag = this._charMap.ConvertDoubleChar(str2, ref strMapped);
                                length++;
                            }
                            else
                            {
                                builder.Append(strMapped);
                                strMapped = string.Empty;
                                flag = false;
                            }
                            startIndex++;
                        }
                        else
                        {
                            for (num3 = 2; num3 <= 2; num3++)
                            {
                                if (this.GetSubString(this._strToConvert, startIndex + num3, length, ref str2))
                                {
                                    if ((str2 != "{") && this._charMap.HalantaCharMapList.ContainsKey(str2))
                                    {
                                        break;
                                    }
                                    if (this._charMap.ConvertHalantaChar(str2, ref strMapped))
                                    {
                                        length += num3 - 1;
                                        break;
                                    }
                                }
                            }
                            flag = false;
                        }
                        if (!flag)
                        {
                            output = strMapped;
                            int num6 = this.ConvertMulitChars(startIndex, ref str2, ref strMapped);
                            length += (num6 > 0) ? (num6 - 2) : 0;
                            flag = num6 > 0;
                            if (!flag)
                            {
                                flag = this.ConvertSingleChar(startIndex + 1, ref str2, ref strMapped);
                            }
                            strMapped = output + strMapped;
                        }
                        if (flag)
                        {
                            output = strMapped;
                            flag = this._charMap.ConvertSingleChar(ch.ToString(), ref strMapped);
                            strMapped = output + strMapped;
                            length++;
                        }
                        else
                        {
                            strMapped = string.Empty;
                        }
                    }
                    else
                    {
                        switch (ch)
                        {
                            case 'F':
                            case '_':
                                str4 = string.Empty;
                                if (this.GetSubString(this._strToConvert, startIndex + 1, 1, ref str4) && this._charMap.VowelCharMapList.ContainsKey(str4))
                                {
                                    this._strToConvert.Replace(ch.ToString() + str4, str4 + ch.ToString(), startIndex, 2);
                                    ch = Convert.ToChar(str4);
                                }
                                break;

                            case '{':
                                {
                                    num4 = startIndex;
                                    num5 = 1;
                                    bool flag2 = false;
                                    do
                                    {
                                        flag2 = false;
                                        foreach (KeyValuePair<string, string> pair in this._charMap.VowelCharMapList)
                                        {
                                            output = string.Empty;
                                            if (this.GetSubString(this._strToConvert, num4 - pair.Key.Length, pair.Key.Length, ref output) && pair.Key.Equals(output))
                                            {
                                                flag2 = true;
                                                num5 += pair.Value.Length;
                                                num4 -= pair.Key.Length;
                                                break;
                                            }
                                        }
                                    }
                                    while (flag2);
                                    length = 1;
                                    flag = this._charMap.ConvertSingleChar(ch.ToString(), ref strMapped);
                                    output = builder.ToString().Insert(builder.Length - num5, strMapped);
                                    builder.Insert(builder.Length - num5, strMapped);
                                    strMapped = string.Empty;
                                    goto Label_0537;
                                }
                        }
                    }
                }
            Label_0537:
                if (!flag)
                {
                    output = string.Empty;
                    length = this.ConvertMulitChars(startIndex, ref str2, ref strMapped);
                    if (length > 0)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                }
                if (!flag)
                {
                    length = 1;
                    flag = this.ConvertSingleChar(startIndex, ref str2, ref strMapped);
                }
                if (flag)
                {
                    builder.Append(strMapped);
                }
                else
                {
                    this.AddUnMappedString(str2);
                }
                startIndex += length;
                if (startIndex < this._length)
                {
                    goto Label_008C;
                }
            }
            catch
            {
            }
            finally
            {
            }
            return builder;
        }

        public string ConvertToUnicode(string strToConvert)
        {
            return this.ConvertToUnicode(new StringBuilder(strToConvert)).ToString();
        }

        public StringBuilder ConvertToUnicode(StringBuilder strToConvert)
        {
            this._strToConvert = strToConvert;
            return this.ConvertToUnicode();
        }

        private bool GetSubString(StringBuilder sb, int startIndex, int length, ref string output)
        {
            if ((startIndex + length) <= sb.Length)
            {
                output = sb.ToString(startIndex, length);
                return true;
            }
            return false;
        }
    }
}