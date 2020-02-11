namespace Bsoft.Convertor
{
    using System.Collections.Generic;

    internal class BsoftCharMap
    {
        private Dictionary<string, string> _doubleCharMapList = new Dictionary<string, string>();
        private Dictionary<string, string> _halantaCharMapList = new Dictionary<string, string>();
        private Dictionary<string, string> _numericCharMapList = new Dictionary<string, string>();
        private Dictionary<string, string> _singleCharMapList = new Dictionary<string, string>();
        private Dictionary<string, string> _vowelCharMapList = new Dictionary<string, string>();

        public BsoftCharMap()
        {
            this.LoadCharMaps();
        }

        public bool ConvertDoubleChar(string strToMap, ref string strMapped)
        {
            return this.GetKeyValue(this._doubleCharMapList, strToMap, ref strMapped);
        }

        public bool ConvertHalantaChar(string strToMap, ref string strMapped)
        {
            return this.GetKeyValue(this._halantaCharMapList, strToMap, ref strMapped);
        }

        public bool ConvertNumber(string strToMap, ref string strMapped)
        {
            return this.GetKeyValue(this._numericCharMapList, strToMap, ref strMapped);
        }

        public bool ConvertSingleChar(string strToMap, ref string strMapped)
        {
            return (this.GetKeyValue(this._halantaCharMapList, strToMap, ref strMapped) || this.GetKeyValue(this._singleCharMapList, strToMap, ref strMapped));
        }

        private bool GetKeyValue(Dictionary<string, string> dicList, string strToMap, ref string strMapped)
        {
            strMapped = string.Empty;
            if (dicList.ContainsKey(strToMap))
            {
                strMapped = dicList[strToMap];
                return true;
            }
            return false;
        }

        public void LoadAltKeysCombinationCharMaps()
        {
            this._singleCharMapList.Add("\x00aa", "ङ");
            this._singleCharMapList.Add("\x00b4", "झ");
            this._singleCharMapList.Add("‚", ",");
            this._singleCharMapList.Add("ƒ", "\x00f7");
            this._singleCharMapList.Add("„", "ध्र");
            this._singleCharMapList.Add("…", "‘");
            this._singleCharMapList.Add("†", "[");
            this._singleCharMapList.Add("‡", "]");
            this._singleCharMapList.Add("ˆ", "फ्");
            this._singleCharMapList.Add("‰", "झ्");
            this._singleCharMapList.Add("Š", "ड");
            this._singleCharMapList.Add("‹", "ङ्घ");
            this._singleCharMapList.Add("Œ", "?");
            this._singleCharMapList.Add("’", "{");
            this._singleCharMapList.Add("“", "}");
            this._singleCharMapList.Add("”", "*");
            this._singleCharMapList.Add("•", "ड्ड");
            this._singleCharMapList.Add("–", "−");
            this._singleCharMapList.Add("—", "—");
            this._singleCharMapList.Add("›", "द्र");
            this._singleCharMapList.Add("œ", "(");
            this._singleCharMapList.Add("\x009d", ")");
            this._singleCharMapList.Add("\x009f", ":");
            this._singleCharMapList.Add("\x00a1", "ज्ञ्");
            this._singleCharMapList.Add("\x00a2", "द्ध");
            this._singleCharMapList.Add("\x00a3", "घ्");
            this._singleCharMapList.Add("\x00a4", "क्त्");
            this._singleCharMapList.Add("\x00a5", "र्");
            this._singleCharMapList.Add("\x00a6", "त्र्");
            this._singleCharMapList.Add("\x00a7", "ट्ट");
            this._singleCharMapList.Add("\x00af", "+");
            this._singleCharMapList.Add("+", "+");
            this._singleCharMapList.Add("\x00b0", "ड्ढ");
            this._singleCharMapList.Add("\x00b2", "#");
            this._singleCharMapList.Add("\x00b3", "झ");
            this._singleCharMapList.Add("\x00b5", "झ");
            this._singleCharMapList.Add("\x00b6", "ठ्ठ");
            this._singleCharMapList.Add("\x00b7", "@");
            this._singleCharMapList.Add("\x00ba", ")");
            this._singleCharMapList.Add("\x00bf", "रू");
            this._singleCharMapList.Add("\x00c2", "न्ह");
            this._singleCharMapList.Add("\x00c3", "व्ह");
            this._singleCharMapList.Add("\x00c4", "ण्ह");
            this._singleCharMapList.Add("\x00c5", "हृ");
            this._singleCharMapList.Add("\x00c6", "\"");
            this._singleCharMapList.Add("\x00cb", "ङ्ग");
            this._singleCharMapList.Add("\x00cc", "न्न");
            this._singleCharMapList.Add("\x00cd", "ङ्क");
            this._singleCharMapList.Add("\x00d2", "…");
            this._singleCharMapList.Add("\x00d7", "\x00d7");
            this._singleCharMapList.Add("\x00df", "ध्म");
            this._singleCharMapList.Add("\x00db", "!");
            this._singleCharMapList.Add("\x00dc", "%");
            this._singleCharMapList.Add("\x00dd", "ट्ठ");
            this._singleCharMapList.Add("\x00e6", "\"");
            this._singleCharMapList.Add("\x00e7", "ॐ");
            this._singleCharMapList.Add("\x00eb", "ष्य");
            this._singleCharMapList.Add("\x00ec", "ष");
            this._singleCharMapList.Add("\x00f7", "/");
            this._singleCharMapList.Add("\x00f8", "य्");
        }

        public void LoadCharMaps()
        {
            this.LoadDoubleCharMaps();
            this.LoadSingleCharMaps();
            this.LoadAltKeysCombinationCharMaps();
            this.LoadNumericCharMaps();
            this.LoadVowelsCharMaps();
            this.LoadHalantaCharMaps();
        }

        public void LoadDoubleCharMaps()
        {
            this._doubleCharMapList.Add("i^\x00ab", "ष्ट्र");
            this._doubleCharMapList.Add("if{", "र्ष");
            this._doubleCharMapList.Add(")f{", "र्ण");
            this._doubleCharMapList.Add("cf]", "ओ");
            this._doubleCharMapList.Add("cf}", "औ");
            this._doubleCharMapList.Add(@"k\m", "फ्");
            this._doubleCharMapList.Add("em", "झ");
            this._doubleCharMapList.Add(")f", "ण");
            this._doubleCharMapList.Add("km", "फ");
            this._doubleCharMapList.Add("if", "ष");
            this._doubleCharMapList.Add("If", "क्ष");
            this._doubleCharMapList.Add("cf", "आ");
            this._doubleCharMapList.Add("O{", "ई");
            this._doubleCharMapList.Add("pm", "ऊ");
            this._doubleCharMapList.Add("Qm", "क्त");
            this._doubleCharMapList.Add("qm", "क्र");
            this._doubleCharMapList.Add("i^", "ष्ट");
        }

        public void LoadHalantaCharMaps()
        {
            this._halantaCharMapList.Add("{", "र्");
            this._halantaCharMapList.Add("S", "क्");
            this._halantaCharMapList.Add("V", "ख्");
            this._halantaCharMapList.Add("U", "ग्");
            this._halantaCharMapList.Add("R", "च्");
            this._halantaCharMapList.Add("H", "ज्");
            this._halantaCharMapList.Add("~", "ञ्");
            this._halantaCharMapList.Add(")", "ण्");
            this._halantaCharMapList.Add("T", "त्");
            this._halantaCharMapList.Add("Y", "थ्");
            this._halantaCharMapList.Add("W", "ध्");
            this._halantaCharMapList.Add("G", "न्");
            this._halantaCharMapList.Add("K", "प्");
            this._halantaCharMapList.Add("A", "ब्");
            this._halantaCharMapList.Add("E", "भ्");
            this._halantaCharMapList.Add("D", "म्");
            this._halantaCharMapList.Add("N", "ल्");
            this._halantaCharMapList.Add("J", "व्");
            this._halantaCharMapList.Add(":", "स्");
            this._halantaCharMapList.Add("i", "ष्");
            this._halantaCharMapList.Add("Z", "श्");
            this._halantaCharMapList.Add("X", "ह्");
            this._halantaCharMapList.Add("I", "क्ष्");
        }

        public void LoadNumericCharMaps()
        {
            this._numericCharMapList.Add("0", "०");
            this._numericCharMapList.Add("1", "१");
            this._numericCharMapList.Add("2", "२");
            this._numericCharMapList.Add("3", "३");
            this._numericCharMapList.Add("4", "४");
            this._numericCharMapList.Add("5", "५");
            this._numericCharMapList.Add("6", "६");
            this._numericCharMapList.Add("7", "७");
            this._numericCharMapList.Add("8", "८");
            this._numericCharMapList.Add("9", "९");
        }

        public void LoadSingleCharMaps()
        {
            this._singleCharMapList.Add(" ", " ");
            this._singleCharMapList.Add("s", "क");
            this._singleCharMapList.Add("v", "ख");
            this._singleCharMapList.Add("u", "ग");
            this._singleCharMapList.Add("#", "घ");
            this._singleCharMapList.Add("r", "च");
            this._singleCharMapList.Add("%", "छ");
            this._singleCharMapList.Add("h", "ज");
            this._singleCharMapList.Add("`", "ञ");
            this._singleCharMapList.Add("^", "ट");
            this._singleCharMapList.Add("&", "ठ");
            this._singleCharMapList.Add("*", "ड");
            this._singleCharMapList.Add("(", "ढ");
            this._singleCharMapList.Add("t", "त");
            this._singleCharMapList.Add("y", "थ");
            this._singleCharMapList.Add("b", "द");
            this._singleCharMapList.Add("w", "ध");
            this._singleCharMapList.Add("g", "न");
            this._singleCharMapList.Add("k", "प");
            this._singleCharMapList.Add("a", "ब");
            this._singleCharMapList.Add("e", "भ");
            this._singleCharMapList.Add("d", "म");
            this._singleCharMapList.Add("o", "य");
            this._singleCharMapList.Add("<", "र");
            this._singleCharMapList.Add("n", "ल");
            this._singleCharMapList.Add("j", "व");
            this._singleCharMapList.Add("z", "श");
            this._singleCharMapList.Add(";", "स");
            this._singleCharMapList.Add("x", "ह");
            this._singleCharMapList.Add("q", "त्र");
            this._singleCharMapList.Add("!", "ज्ञ");
            this._singleCharMapList.Add("c", "अ");
            this._singleCharMapList.Add("O", "इ");
            this._singleCharMapList.Add("p", "उ");
            this._singleCharMapList.Add("P", "ए");
            this._singleCharMapList.Add(">", "श्र");
            this._singleCharMapList.Add("Q", "त्त");
            this._singleCharMapList.Add("\x00ab", "्र");
            this._singleCharMapList.Add("M", "।");
            this._singleCharMapList.Add("/", "/");
            this._singleCharMapList.Add(".", ".");
            this._singleCharMapList.Add(",", ",");
            this._singleCharMapList.Add("?", "रू");
            this._singleCharMapList.Add("=", ".");
            this._singleCharMapList.Add("-", "-");
            this._singleCharMapList.Add("F", "ँ");
            this._singleCharMapList.Add("_", "ं");
            this._singleCharMapList.Add("Ÿ", "ः");
            this._singleCharMapList.Add("|", "्र");
            this._singleCharMapList.Add("$", "द्ध");
            this._singleCharMapList.Add("@", "द्द");
        }

        public void LoadVowelsCharMaps()
        {
            this._singleCharMapList.Add("f", "ा");
            this._singleCharMapList.Add("l", "ि");
            this._singleCharMapList.Add("L", "ी");
            this._singleCharMapList.Add("'", "ु");
            this._singleCharMapList.Add("\"", "ू");
            this._singleCharMapList.Add("[", "ृ");
            this._singleCharMapList.Add("]", "े");
            this._singleCharMapList.Add("}", "ै");
            this._singleCharMapList.Add(@"\", "्");
            this._doubleCharMapList.Add("f]", "ो");
            this._doubleCharMapList.Add("f}", "ौ");
            this._vowelCharMapList.Add("f]", "ो");
            this._vowelCharMapList.Add("f}", "ौ");
            this._vowelCharMapList.Add("f", "ा");
            this._vowelCharMapList.Add("l", "ि");
            this._vowelCharMapList.Add("L", "ी");
            this._vowelCharMapList.Add("'", "ु");
            this._vowelCharMapList.Add("\"", "ू");
            this._vowelCharMapList.Add("[", "ृ");
            this._vowelCharMapList.Add("]", "े");
            this._vowelCharMapList.Add("}", "ै");
            this._vowelCharMapList.Add(@"\", "्");
        }

        public Dictionary<string, string> HalantaCharMapList
        {
            get
            {
                return this._halantaCharMapList;
            }
            set
            {
                this._halantaCharMapList = value;
            }
        }

        public Dictionary<string, string> VowelCharMapList
        {
            get
            {
                return this._vowelCharMapList;
            }
        }
    }
}