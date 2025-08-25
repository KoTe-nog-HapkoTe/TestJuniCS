namespace TestXML
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            button2 = new Button();
            treeView1 = new TreeView();
            richTextBox1 = new RichTextBox();
            xmlLoader = new System.ComponentModel.BackgroundWorker();
            progressBar1 = new ProgressBar();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(180, 471);
            button1.Name = "button1";
            button1.Size = new Size(124, 46);
            button1.TabIndex = 0;
            button1.Text = "ОткрытьXML";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(685, 471);
            button2.Name = "button2";
            button2.Size = new Size(124, 46);
            button2.TabIndex = 1;
            button2.Text = "Сохранить выбранное";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // treeView1
            // 
            treeView1.CheckBoxes = true;
            treeView1.Location = new Point(39, 33);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(433, 416);
            treeView1.TabIndex = 3;
            treeView1.AfterCheck += treeView1_AfterCheck;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(499, 33);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(456, 416);
            richTextBox1.TabIndex = 5;
            richTextBox1.Text = "";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(39, 494);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(100, 23);
            progressBar1.TabIndex = 6;
            progressBar1.Visible = false;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(987, 25);
            toolStrip1.TabIndex = 7;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(23, 22);
            toolStripButton1.Text = "toolStripButton1";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(987, 529);
            Controls.Add(toolStrip1);
            Controls.Add(progressBar1);
            Controls.Add(richTextBox1);
            Controls.Add(treeView1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "XML";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private TreeView treeView1;
        private RichTextBox richTextBox1;
        private System.ComponentModel.BackgroundWorker xmlLoader;
        private ProgressBar progressBar1;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
    }
}
