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
    public partial class Form1 : Form
    {
        string defaultFileText = @"{
            ""buttonByColumn"": 1,
            ""buttonByLine"": 1,
            ""iconSize"": 100,
            ""closeTheWindow"": 1,
            ""settingsButton"": 1,
            ""settingsShortcut"": ""1"",
            ""buttons"": {
                ""button1"": {
                    ""name"": ""test"",
                    ""type"": ""URL"",
                    ""path"": ""https://clementsongis.wordpress.com"",
                    ""shortcut"": ""e"",
                    ""iconPath"": """"
                }
            }
        }";
        public int buttonByColumn, buttonByLine, iconSize,closeTheWindow;
        public string fileText;
        public bool settingsOpen;
        public string[] names, kc, iconPaths, paths, types;
        public System.Windows.Forms.Button[] button;
        public Form2 form2;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            settingsOpen = true;
        }
        
        public Form1()
        {
            InitializeComponent();
            Start();
        }
        
        void Start()
        {
            if (!File.Exists(@"./settings.json"))
            {
                File.WriteAllText(@"./settings.json", defaultFileText);
            }
            fileText = File.ReadAllText(@"./settings.json");
            var result = JsonConvert.DeserializeObject<RootObject>(fileText);

            buttonByColumn = result.ButtonByColumn;
            buttonByLine = result.ButtonByLine;
            iconSize = result.IconSize;
            closeTheWindow = result.CloseTheWindow;
            Height = (buttonByColumn * (iconSize + 20)) + 20;
            Width = buttonByLine * (iconSize + 20);

            if (result.SettingsButton == 1)
            {
                settings.Visible = true;
            }
            else
            {
                settings.Visible = false;
            }
            Location = new Point(Screen.PrimaryScreen.Bounds.Width - Size.Width + 10, Screen.PrimaryScreen.Bounds.Height - Size.Height - 30);

            setList();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == kc[0])
            {
                settingsOpen = true;
                openSettings();
            }
            for (int i = 1; i < kc.Length; i++)
            {
                if (e.KeyChar.ToString() == kc[i])
                {
                    if (paths[i] != "")
                    {
                        System.Diagnostics.Process.Start(paths[i]);
                    }
                    if (closeTheWindow == 1)
                    {
                        Close();
                    }
                }
            }
        }

        void setList()
        {
            var result = JsonConvert.DeserializeObject<RootObject>(fileText);

            kc = new string[buttonByColumn * buttonByLine + 1];
            kc[0] = result.SettingsShortcut;
            names = new string[buttonByColumn * buttonByLine + 1];
            names[0] = "settings";
            iconPaths = new string[buttonByColumn * buttonByLine + 1];
            iconPaths[0] = "";
            paths = new string[buttonByColumn * buttonByLine + 1];
            paths[0] = "";
            types = new string[buttonByColumn * buttonByLine + 1];
            types[0] = "settings";
            button = new System.Windows.Forms.Button[buttonByColumn * buttonByLine + 1];
            button[0] = null;
            int i = 1;
            foreach (var btn in result.Buttons)
            {
                if (btn.Value.Shortcut != null)
                {
                    kc[i] = btn.Value.Shortcut;
                }
                names[i] = btn.Value.Name;
                iconPaths[i] = btn.Value.IconPath;
                paths[i] = btn.Value.Path;
                types[i] = btn.Value.Type;
                button[i] = new System.Windows.Forms.Button();
                SuspendLayout();
                if (iconPaths[i] != "")
                {
                    button[i].BackgroundImage = Image.FromFile(iconPaths[i]);
                    button[i].Text = "";
                }
                else
                {
                    button[i].Text = names[i];
                }
                button[i].Height = iconSize;
                button[i].Width = iconSize;
                double y = Math.IEEERemainder(i - 1, buttonByColumn - 1);
                double z = Math.Truncate((double)(i - 1) / (buttonByColumn - 1));
                button[i].Location = new Point((int)y * iconSize, (int)z * iconSize);
                button[i].Name = names[i];
                button[i].Click += new System.EventHandler(click);
                Controls.Add(button[i]);
                ResumeLayout(false);

                i++;
            }
        }

        void click(object sender, EventArgs e)
        {
            for (int i = 1; i < button.Length; i++)
            {
                if (sender == button[i])
                {
                    if (paths[i] != "")
                    {
                        System.Diagnostics.Process.Start(paths[i]);
                    }
                    if (closeTheWindow == 1)
                    {
                        Close();
                    }
                }
            }
        }

        void openSettings()
        {
            form2 = new Form2();
            form2.ShowDialog();
        }

        private void settings_Click(object sender, EventArgs e)
        {
            settingsOpen = true;
            openSettings();
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
