using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Text.RegularExpressions;

namespace BeautifulGirl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _keyWord = GetSetting("Key");
            if (!string.IsNullOrEmpty(_keyWord))
            {
                _listKeyWord = _keyWord.Split(new string[] { " " }, StringSplitOptions.None).ToList();
                _listKeyWord.ForEach(x => x.ToUpper());
            }
        }
        private static string _textBefore = string.Empty;
        private static string _keyWord = string.Empty;
        private List<string> _listKeyWord = new List<string>();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Get string from App.config
        /// </summary>
        /// <param name="key">key of node XML</param>
        /// <returns></returns>
        private static string GetSetting(string key)
        {
            string tempStr = ConfigurationManager.AppSettings[key].Trim();
            string result = Regex.Replace(tempStr, @"\r\n?|\n|\t|\s", " ");
            return result;
        }

        
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_textBefore))
            {
                
                // Split string to List
                List<string> temp = _textBefore.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();

                for (int i = 0; i < temp.Count; i++)
                {
                    if (string.IsNullOrEmpty(temp[i])) 
                    { 
                        temp.RemoveAt(i);
                        continue;
                    }
                    if (temp[i].IndexOf("sql.AppendLine(\"") == -1)
                    {
                        temp[i] = string.Format("sql.AppendLine(\"") + temp[i].ToString().Trim();
                    }
                    if (temp[i].LastIndexOf("\");") == -1)
                    {
                        temp[i] = temp[i].ToString() + string.Format("\");");
                    }
                    temp[i] = temp[i].ToString().Trim();
                }  
                
                ConvertKeyWord(temp);
                int maxLength = 0;
                for (int i = 0; i < temp.Count; i++)
                {
                    temp[i] = temp[i].Trim();
                    int idexBegin = temp[i].IndexOf("sql.AppendLine(\"") + string.Format("sql.AppendLine(\"").Length;
                    int idexEnd = temp[i].IndexOf("\");");
                    //int idexEnd = temp[i].LastIndexOf("\");") - string.Format("\");").Length;
                    string textBefore = temp[i].Substring(idexBegin, idexEnd - idexBegin);
                    // Replace all double space to single space char
                    string textAfter = Regex.Replace(textBefore, @"\s+", " ");
                    textAfter = temp[i].Substring(idexBegin, idexEnd - idexBegin).Trim();
                    
                    // Find a first word
                    var tempWordFirst = Regex.Match(textAfter, @"^(\@?\w+)(?=\s|\W)");
                    // Check whether first word is to belong any keyword
                    if (!_listKeyWord.Contains(tempWordFirst.ToString().ToUpper()))
                    {
                        textAfter = textAfter.Insert(0, "     ");
                    }
                    textAfter = textAfter.Insert(0, "  ");
                    temp[i] = temp[i].Replace(textBefore, textAfter);
                    var tempMaxLength = temp[i].Length;
                    if (temp[maxLength].Length < tempMaxLength) maxLength = i;
                }

                int tempLength = temp[maxLength].Length;
                for (int i = 0; i < temp.Count; i++)
                {
                    //if (i == maxLength) continue;
                    int reduction = tempLength - temp[i].Length;
                    // Set space char last the sentence
                    reduction += 2;
                    // Define a string builder
                    StringBuilder tempSpaceChar = new StringBuilder(string.Empty);
                    for (int x = 0; x < reduction; x++)
                    {
                        tempSpaceChar.Append(" ");
                    }

                    int idexBegin = temp[i].IndexOf("sql.AppendLine(\"") + string.Format("sql.AppendLine(\"").Length;
                    int idexEnd = temp[i].IndexOf("\");");
                    string textBefore = temp[i].Substring(idexBegin, idexEnd - idexBegin);
                    string textAfter = temp[i].Substring(idexBegin, idexEnd - idexBegin) + tempSpaceChar.ToString();
                    temp[i] = temp[i].Replace(textBefore, textAfter);
                    temp[i] += "\r\n";
                }

                // Define stringBuilder output
                StringBuilder outputString = new StringBuilder(string.Empty);
                int countOfList = temp.Count;
                for (int i = 0; i < countOfList; i++)
                {
                    outputString.Append(temp[i]);
                }

                this.textBoxAfter.Text = outputString.ToString();
            }
        }

        /// <summary>
        /// Convert key word of T-SQL to UpperCase
        /// </summary>
        /// <param name="listKeyWord"></param>
        private void ConvertKeyWord(List<string> listKeyWord)
        {
            int lengthResource = _listKeyWord.Count;
            int lengthTurned = listKeyWord.Count;

            for (int i = 0; i < lengthResource; i++)
            {
                for (int j = 0; j < lengthTurned; j++)
                {
                    // Use regex problem solving
                    string pattern = string.Format($@"(?<=\s|\{(char)34})(?i)({_listKeyWord[i].Trim().ToUpper()})(?=\s|\W)");
                    Regex regex = new Regex(pattern);
                    if (regex.IsMatch(listKeyWord[j]))
                        listKeyWord[j] = regex.Replace(listKeyWord[j], $"{_listKeyWord[i].Trim().ToUpper()}");

                }
            }
        }
        private void textBoxBefore_TextChanged(object sender, EventArgs e)
        {
            TextBox objBefore = (TextBox)sender;
            _textBefore = objBefore.Text;
        }

        private void textBoxAfter_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
