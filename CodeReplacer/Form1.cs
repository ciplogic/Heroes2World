using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CodeReplacer
{
    public partial class Form1 : Form
    {
        private readonly List<ReplaceRule> _replaceRules = new List<ReplaceRule>
        {
            new ReplaceRule("->", "."),
            new ReplaceRule("struct", "class"),
            new ReplaceRule("uint32_t", "UInt32"),
            new ReplaceRule("u16", "UInt16"),
            new ReplaceRule("u8", "byte"),
            new ReplaceRule("&", ""),
            new ReplaceRule("const ", ""),
            new ReplaceRule("std::string", "string"),
            new ReplaceRule("vector<", "List<"),
            new ReplaceRule("push_back", "Add"),
            new ReplaceRule("null_ptr ", "null "),
            new ReplaceRule(" null_ptr", " null"),
            new ReplaceRule("auto ", "var "),
            new ReplaceRule("::", ".")
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = Clipboard.GetText().Trim();
        }


        private static string ReplaceText(string text, List<ReplaceRule> convertPairs)
        {
            foreach (var convertPair in convertPairs) text = text.Replace(convertPair.From, convertPair.To);

            return text;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var originalText = textBox1.Text;
            var transformed = ReplaceText(originalText, _replaceRules);
            textBox1.Text = transformed;
            Clipboard.SetText(transformed);
        }
    }
}