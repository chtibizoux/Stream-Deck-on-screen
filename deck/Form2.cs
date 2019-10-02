using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace deck
{
    public partial class Form2 : Form
    {
        public int buttonByColumn, buttonByLine, iconSize, closeTheWindow, settingsButton;
        public string fileText, settingsShortcut;
        public bool settingsClose;
        public ComboBox[] kc;
        public Label[] iconPaths, paths,ID;
        public OpenFileDialog[] fileDialog;
        public ComboBox[] types;
        public TextBox[] names;
        public System.Windows.Forms.Button[] buttonsPath, buttonsIconPath;
        public Form3 form3;

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            settingsClose = true;
        }

        public Form2()
        {
            InitializeComponent();
            Start();
        }

        void Start()
        {
            fileText = File.ReadAllText(@"./settings.json");
            var result = JsonConvert.DeserializeObject<RootObject>(fileText);

            Location = new Point(0,0);

            buttonByColumn = result.ButtonByColumn;
            buttonByLine = result.ButtonByLine;
            iconSize = result.IconSize;
            closeTheWindow = result.CloseTheWindow;
            settingsButton = result.SettingsButton;
            settingsShortcut = result.SettingsShortcut;

            setList();

            numericUpDown3.Value = buttonByColumn;
            numericUpDown2.Value = buttonByLine;
            numericUpDown1.Value = iconSize;
            textBox1.Text = settingsShortcut;
            if (settingsButton == 1)
            {
                settings.Checked = true;
            }
            else
            {
                settings.Checked = false;
            }
            if (closeTheWindow == 1)
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
        }
        private void kc_TextChanged(object sender, EventArgs e)
        {
            for (int i = 1; i < kc.Length; i++)
            {
                if (sender == kc[i])
                {

                }
            }
        }

        private void names_TextChanged(object sender, EventArgs e)
        {
            for (int i = 1; i < names.Length; i++)
            {
                if (sender == names[i])
                {

                }
            }
        }

        private void types_TextChanged(object sender, EventArgs e)
        {
            for (int i = 1; i < types.Length; i++)
            {
                if (sender == types[i])
                {

                }
            }
        }

        private void fileDialog_FileOk(object sender, EventArgs e)
        {
            for (int i = 1; i < fileDialog.Length; i++)
            {
                if (sender == fileDialog[i])
                {

                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            fileText = fileText.Replace(@"""iconSize"": " + iconSize, @"""iconSize"": " + numericUpDown1.Value);
            File.WriteAllText(@"./settings.json", fileText);
            iconSize = (int)numericUpDown1.Value;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            fileText = fileText.Replace(@"""buttonByColumn"": " + buttonByColumn, @"""buttonByColumn"": " + numericUpDown3.Value);
            buttonByColumn = (int)numericUpDown3.Value;
            for (int i = ID.Length - 1; i < buttonByLine * buttonByColumn; i++)
            {
                fileText = fileText.Insert(fileText.IndexOf(@"""buttons"": {") + 12, @"""button" + (i + 1) + @""": {
                    ""name"": """",
                    ""type"": ""URL"",
                    ""path"": """",
                    ""shortcut"": """",
                    ""iconPath"": """"
                },");
            }
            for (int i = ID.Length - 1; i > buttonByLine * buttonByColumn; i--)
            {
                int index1 = fileText.IndexOf(@"""button" + i + @""": {");
                int index2 = fileText.IndexOf(@"""button" + (i - 1) + @""": {");
                int length = index2 - index1;
                fileText = fileText.Remove(index1, length);
            }
            File.WriteAllText(@"./settings.json", fileText);
            for (int i = 1; i < ID.Length; i++)
            {
                kc[i].Dispose();
                names[i].Dispose();
                iconPaths[i].Dispose();
                paths[i].Dispose();
                types[i].Dispose();
                fileDialog[i].Dispose();
                ID[i].Dispose();
                buttonsPath[i].Dispose();
                buttonsIconPath[i].Dispose();
            }
            setList();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            fileText = fileText.Replace(@"""buttonByLine"": " + buttonByLine, @"""buttonByline"": " + numericUpDown2.Value);
            buttonByLine = (int)numericUpDown2.Value;
            for (int i = ID.Length - 1; i < buttonByLine * buttonByColumn; i++)
            {
                fileText = fileText.Insert(fileText.IndexOf(@"""buttons"": {") + 12, @"""button" + (i + 1) + @""": {
                    ""name"": """",
                    ""type"": ""URL"",
                    ""path"": """",
                    ""shortcut"": """",
                    ""iconPath"": """"
                },");
            }
            for (int i = ID.Length - 1; i > buttonByLine * buttonByColumn; i--)
            {
                int index1 = fileText.IndexOf(@"""button" + i + @""": {");
                int index2 = fileText.IndexOf(@"""button" + (i - 1) + @""": {");
                int length = index2 - index1;
                fileText = fileText.Remove(index1, length);
            }
            File.WriteAllText(@"./settings.json", fileText);
            for (int i = 1; i < ID.Length; i++)
            {
                kc[i].Dispose();
                names[i].Dispose();
                iconPaths[i].Dispose();
                paths[i].Dispose();
                types[i].Dispose();
                fileDialog[i].Dispose();
                ID[i].Dispose();
                buttonsPath[i].Dispose();
                buttonsIconPath[i].Dispose();
            }
            setList();
        }

        private void settings_CheckedChanged(object sender, EventArgs e)
        {
            if (settings.Checked)
            {
                fileText = fileText.Replace(@"""settingsButton"": " + settingsButton, @"""settingsButton"": " + 1);
                settingsButton = 1;
            }
            else
            {
                fileText = fileText.Replace(@"""settingsButton"": " + settingsButton, @"""settingsButton"": " + 0);
                settingsButton = 0;
            }
            File.WriteAllText(@"./settings.json", fileText);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            fileText = fileText.Replace(@"""settingsShortcut"": """ + settingsShortcut + @" "" ", @"""settingsShortcut"": """ + textBox1.Text + @" "" ");
            File.WriteAllText(@"./settings.json", fileText);
            settingsShortcut = textBox1.Text;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (settings.Checked)
            {
                fileText = fileText.Replace(@"""closeTheWindow"": " + closeTheWindow, @"""closeTheWindow"": " + 1); File.WriteAllText(@"./settings.json", fileText);
                closeTheWindow = 1;
            }
            else
            {
                fileText = fileText.Replace(@"""closeTheWindow"": " + closeTheWindow, @"""closeTheWindow"": " + 0);
                closeTheWindow = 0;
            }
            File.WriteAllText(@"./settings.json", fileText);
        }

        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {
            var result = JsonConvert.DeserializeObject<RootObject>(fileText);
            if (e.KeyChar.ToString() == result.SettingsShortcut)
            {
                settingsClose = true;
                closeSettings();
            }
        }

        void setList()
        {
            var result = JsonConvert.DeserializeObject<RootObject>(fileText);

            kc = new ComboBox[buttonByColumn * buttonByLine + 1];
            names = new TextBox[buttonByColumn * buttonByLine + 1];
            iconPaths = new Label[buttonByColumn * buttonByLine + 1];
            paths = new Label[buttonByColumn * buttonByLine + 1];
            types = new ComboBox[buttonByColumn * buttonByLine + 1];
            fileDialog = new OpenFileDialog[buttonByColumn * buttonByLine + 1];
            ID = new Label[buttonByColumn * buttonByLine + 1];
            buttonsPath = new System.Windows.Forms.Button[buttonByColumn * buttonByLine + 1];
            buttonsIconPath = new System.Windows.Forms.Button[buttonByColumn * buttonByLine + 1];
            int i = 1;
            foreach (var btn in result.Buttons)
            {
                kc[i] = new ComboBox();
                names[i] = new TextBox();
                iconPaths[i] = new Label();
                paths[i] = new Label();
                types[i] = new ComboBox();
                fileDialog[i] = new OpenFileDialog();
                ID[i] = new Label();
                buttonsPath[i] = new System.Windows.Forms.Button();
                buttonsIconPath[i] = new System.Windows.Forms.Button();

                SuspendLayout();

                ID[i].Location = new Point(228, 15 + (24 * i));
                names[i].Location = new Point(250, 15 + (24 * i));
                kc[i].Location = new Point(355, 15 + (24 * i));
                types[i].Location = new Point(450, 15 + (24 * i));
                paths[i].Location = new Point(577, 15 + (24 * i));
                buttonsPath[i].Location = new Point(642, 15 + (24 * i));
                iconPaths[i].Location = new Point(676, 15 + (24 * i));
                buttonsIconPath[i].Location = new Point(741, 15 + (24 * i));

                ID[i].AutoSize = false;
                names[i].AutoSize = false;
                kc[i].AutoSize = false;
                types[i].AutoSize = false;
                paths[i].AutoSize = false;
                buttonsPath[i].AutoSize = false;
                iconPaths[i].AutoSize = false;
                buttonsIconPath[i].AutoSize = false;

                ID[i].Size = new Size(16, 16);
                names[i].Size = new Size(100, 22);
                kc[i].Size = new Size(89, 24);
                types[i].Size = new Size(121, 24);
                paths[i].Size = new Size(59, 23);
                buttonsPath[i].Size = new Size(28, 23);
                iconPaths[i].Size = new Size(59, 23);
                buttonsIconPath[i].Size = new Size(28, 23);

                ID[i].Text = i.ToString();
                names[i].Text = btn.Value.Name;
                kc[i].Text = btn.Value.Shortcut;
                kc[i].Items.Add("a");
                kc[i].Items.Add("b");
                kc[i].Items.Add("c");
                kc[i].Items.Add("d");
                kc[i].Items.Add("e");
                kc[i].Items.Add("f");
                kc[i].Items.Add("g");
                kc[i].Items.Add("h");
                kc[i].Items.Add("i");
                kc[i].Items.Add("j");
                kc[i].Items.Add("k");
                kc[i].Items.Add("l");
                kc[i].Items.Add("m");
                kc[i].Items.Add("n");
                kc[i].Items.Add("o");
                kc[i].Items.Add("p");
                kc[i].Items.Add("q");
                kc[i].Items.Add("r");
                kc[i].Items.Add("s");
                kc[i].Items.Add("t");
                kc[i].Items.Add("u");
                kc[i].Items.Add("v");
                kc[i].Items.Add("w");
                kc[i].Items.Add("x");
                kc[i].Items.Add("y");
                kc[i].Items.Add("z");
                kc[i].Items.Add("0");
                kc[i].Items.Add("1");
                kc[i].Items.Add("2");
                kc[i].Items.Add("3");
                kc[i].Items.Add("4");
                kc[i].Items.Add("5");
                kc[i].Items.Add("6");
                kc[i].Items.Add("7");
                kc[i].Items.Add("8");
                kc[i].Items.Add("9");
                types[i].Text = btn.Value.Type;
                types[i].Items.Add("Application");
                types[i].Items.Add("File");
                types[i].Items.Add("URL");
                paths[i].Text = btn.Value.Path;
                buttonsPath[i].Text = "...";
                iconPaths[i].Text = btn.Value.IconPath;
                buttonsIconPath[i].Text = "...";
                
                buttonsPath[i].Click += new System.EventHandler(pathClick);
                buttonsIconPath[i].Click += new System.EventHandler(pathClick);
                fileDialog[i].FileOk += new System.ComponentModel.CancelEventHandler(fileDialog_FileOk);
                kc[i].TextChanged += new System.EventHandler(kc_TextChanged);
                names[i].TextChanged += new System.EventHandler(names_TextChanged);
                types[i].TextChanged += new System.EventHandler(types_TextChanged);

                fileDialog[i].Multiselect = false;

                Controls.Add(buttonsIconPath[i]);
                Controls.Add(buttonsPath[i]);
                Controls.Add(kc[i]);
                Controls.Add(names[i]);
                Controls.Add(iconPaths[i]);
                Controls.Add(paths[i]);
                Controls.Add(types[i]);
                Controls.Add(ID[i]);

                ResumeLayout(false);
                i++;
            }
        }
        void pathClick(object sender, EventArgs e)
        {
            for (int i = 1; i < buttonsPath.Length; i++)
            {
                if (sender == buttonsPath[i])
                {
                    if (types[i].Text == "URL")
                    {
                        form3 = new Form3();
                        form3.ShowDialog();
                    }
                    else
                    {
                        fileDialog[i].FileName = paths[i].Text;
                        fileDialog[i].ShowDialog();
                    }
                }
            }
            for (int i = 1; i < buttonsIconPath.Length; i++)
            {
                if (sender == buttonsIconPath[i])
                {
                    fileDialog[i].FileName = iconPaths[i].Text;
                    fileDialog[i].ShowDialog();
                }
            }
        }
        void closeSettings()
        {
            Close();
        }

        public class Button
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("path")]
            public string Path { get; set; }

            [JsonProperty("shortcut")]
            public string Shortcut { get; set; }

            [JsonProperty("iconPath")]
            public string IconPath { get; set; }
        }
        public class RootObject
        {
            [JsonProperty("buttonByColumn")]
            public int ButtonByColumn { get; set; }


            [JsonProperty("buttonByLine")]
            public int ButtonByLine { get; set; }


            [JsonProperty("iconSize")]
            public int IconSize { get; set; }


            [JsonProperty("closeTheWindow")]
            public int CloseTheWindow { get; set; }


            [JsonProperty("settingsButton")]
            public int SettingsButton { get; set; }


            [JsonProperty("settingsShortcut")]
            public string SettingsShortcut { get; set; }


            [JsonProperty("buttons")]
            public Dictionary<string, Button> Buttons { get; set; }
        }
    }
}
