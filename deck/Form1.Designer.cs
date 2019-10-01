namespace deck
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.settings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // settings
            // 
            this.settings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("settings.BackgroundImage")));
            this.settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.settings.Location = new System.Drawing.Point(12, 12);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(32, 33);
            this.settings.TabIndex = 9;
            this.settings.UseVisualStyleBackColor = true;
            this.settings.Click += new System.EventHandler(this.settings_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 431);
            this.Controls.Add(this.settings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "deck";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button settings;
    }
}

