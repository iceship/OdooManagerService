namespace OdooManager
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelControls = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panelDebug = new System.Windows.Forms.Panel();
            this.panelCMD = new System.Windows.Forms.Panel();
            this.consoleInteractive = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelLog = new System.Windows.Forms.Panel();
            this.consoleLog = new System.Windows.Forms.RichTextBox();
            this.schedulerConsoleCMD = new System.Windows.Forms.Timer(this.components);
            this.panelControls.SuspendLayout();
            this.panelDebug.SuspendLayout();
            this.panelCMD.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControls
            // 
            this.panelControls.Controls.Add(this.button1);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControls.Location = new System.Drawing.Point(0, 0);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(969, 32);
            this.panelControls.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelDebug
            // 
            this.panelDebug.Controls.Add(this.panelCMD);
            this.panelDebug.Controls.Add(this.panel1);
            this.panelDebug.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDebug.Location = new System.Drawing.Point(0, 32);
            this.panelDebug.Name = "panelDebug";
            this.panelDebug.Size = new System.Drawing.Size(969, 287);
            this.panelDebug.TabIndex = 1;
            // 
            // panelCMD
            // 
            this.panelCMD.Controls.Add(this.consoleInteractive);
            this.panelCMD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCMD.Location = new System.Drawing.Point(0, 0);
            this.panelCMD.Name = "panelCMD";
            this.panelCMD.Size = new System.Drawing.Size(969, 234);
            this.panelCMD.TabIndex = 1;
            // 
            // consoleInteractive
            // 
            this.consoleInteractive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleInteractive.Location = new System.Drawing.Point(0, 0);
            this.consoleInteractive.Name = "consoleInteractive";
            this.consoleInteractive.Size = new System.Drawing.Size(969, 234);
            this.consoleInteractive.TabIndex = 0;
            this.consoleInteractive.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 234);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(969, 53);
            this.panel1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 13);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(969, 40);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Command";
            // 
            // panelLog
            // 
            this.panelLog.Controls.Add(this.consoleLog);
            this.panelLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLog.Location = new System.Drawing.Point(0, 319);
            this.panelLog.Name = "panelLog";
            this.panelLog.Size = new System.Drawing.Size(969, 277);
            this.panelLog.TabIndex = 2;
            // 
            // consoleLog
            // 
            this.consoleLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleLog.Location = new System.Drawing.Point(0, 0);
            this.consoleLog.Name = "consoleLog";
            this.consoleLog.Size = new System.Drawing.Size(969, 277);
            this.consoleLog.TabIndex = 0;
            this.consoleLog.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(969, 596);
            this.Controls.Add(this.panelLog);
            this.Controls.Add(this.panelDebug);
            this.Controls.Add(this.panelControls);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Odoo Manager <alca259@gmail.com>";
            this.panelControls.ResumeLayout(false);
            this.panelDebug.ResumeLayout(false);
            this.panelCMD.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Panel panelDebug;
        private System.Windows.Forms.Panel panelLog;
        private System.Windows.Forms.RichTextBox consoleLog;
        private System.Windows.Forms.Panel panelCMD;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox consoleInteractive;
        private System.Windows.Forms.Timer schedulerConsoleCMD;
    }
}

