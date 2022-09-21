namespace SpGenerator
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDb = new System.Windows.Forms.Label();
            this.comboDb = new System.Windows.Forms.ComboBox();
            this.comboTable = new System.Windows.Forms.ComboBox();
            this.lblTable = new System.Windows.Forms.Label();
            this.pictureTable = new System.Windows.Forms.PictureBox();
            this.pictureDb = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnForSelectedTable = new System.Windows.Forms.Button();
            this.btnForSelectedDatabase = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBoxSelectSearch = new System.Windows.Forms.TextBox();
            this.tabSelectId = new System.Windows.Forms.TabPage();
            this.textBoxSelectId = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBoxDelete = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.textBoxUpdate = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBoxInsert = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.textBoxExecuteSp = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDb)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabSelectId.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDb);
            this.groupBox2.Controls.Add(this.comboDb);
            this.groupBox2.Controls.Add(this.comboTable);
            this.groupBox2.Controls.Add(this.lblTable);
            this.groupBox2.Controls.Add(this.pictureTable);
            this.groupBox2.Controls.Add(this.pictureDb);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(321, 165);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Database and table selection area";
            // 
            // lblDb
            // 
            this.lblDb.AutoSize = true;
            this.lblDb.Location = new System.Drawing.Point(16, 32);
            this.lblDb.Name = "lblDb";
            this.lblDb.Size = new System.Drawing.Size(55, 15);
            this.lblDb.TabIndex = 3;
            this.lblDb.Text = "Database";
            // 
            // comboDb
            // 
            this.comboDb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboDb.FormattingEnabled = true;
            this.comboDb.Location = new System.Drawing.Point(16, 50);
            this.comboDb.Name = "comboDb";
            this.comboDb.Size = new System.Drawing.Size(234, 23);
            this.comboDb.TabIndex = 7;
            this.comboDb.SelectedIndexChanged += new System.EventHandler(this.comboDb_SelectedIndexChanged);
            // 
            // comboTable
            // 
            this.comboTable.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboTable.FormattingEnabled = true;
            this.comboTable.Location = new System.Drawing.Point(16, 111);
            this.comboTable.Name = "comboTable";
            this.comboTable.Size = new System.Drawing.Size(234, 23);
            this.comboTable.TabIndex = 8;
            this.comboTable.SelectedIndexChanged += new System.EventHandler(this.comboTable_SelectedIndexChanged);
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Location = new System.Drawing.Point(16, 93);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(34, 15);
            this.lblTable.TabIndex = 4;
            this.lblTable.Text = "Table";
            // 
            // pictureTable
            // 
            this.pictureTable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureTable.Image = ((System.Drawing.Image)(resources.GetObject("pictureTable.Image")));
            this.pictureTable.Location = new System.Drawing.Point(256, 109);
            this.pictureTable.Name = "pictureTable";
            this.pictureTable.Size = new System.Drawing.Size(26, 25);
            this.pictureTable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureTable.TabIndex = 12;
            this.pictureTable.TabStop = false;
            this.pictureTable.Visible = false;
            // 
            // pictureDb
            // 
            this.pictureDb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureDb.Image = ((System.Drawing.Image)(resources.GetObject("pictureDb.Image")));
            this.pictureDb.Location = new System.Drawing.Point(256, 48);
            this.pictureDb.Name = "pictureDb";
            this.pictureDb.Size = new System.Drawing.Size(26, 25);
            this.pictureDb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureDb.TabIndex = 11;
            this.pictureDb.TabStop = false;
            this.pictureDb.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnForSelectedTable);
            this.groupBox1.Controls.Add(this.btnForSelectedDatabase);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(382, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 165);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Write the file on desktop";
            // 
            // btnForSelectedTable
            // 
            this.btnForSelectedTable.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnForSelectedTable.Location = new System.Drawing.Point(6, 22);
            this.btnForSelectedTable.Name = "btnForSelectedTable";
            this.btnForSelectedTable.Size = new System.Drawing.Size(247, 66);
            this.btnForSelectedTable.TabIndex = 9;
            this.btnForSelectedTable.Text = "Selected Table";
            this.btnForSelectedTable.UseVisualStyleBackColor = true;
            this.btnForSelectedTable.Click += new System.EventHandler(this.btnForSelectedTable_Click);
            // 
            // btnForSelectedDatabase
            // 
            this.btnForSelectedDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnForSelectedDatabase.Location = new System.Drawing.Point(6, 94);
            this.btnForSelectedDatabase.Name = "btnForSelectedDatabase";
            this.btnForSelectedDatabase.Size = new System.Drawing.Size(247, 66);
            this.btnForSelectedDatabase.TabIndex = 10;
            this.btnForSelectedDatabase.Text = "All table for selected database";
            this.btnForSelectedDatabase.UseVisualStyleBackColor = true;
            this.btnForSelectedDatabase.Click += new System.EventHandler(this.btnForSelectedDatabase_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tabControl1);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox3.Location = new System.Drawing.Point(12, 201);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(629, 370);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "If you have created model file use this screen.";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabSelectId);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(4, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(623, 341);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBoxSelectSearch);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(615, 313);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Select \'\'";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBoxSelectSearch
            // 
            this.textBoxSelectSearch.Location = new System.Drawing.Point(-4, 0);
            this.textBoxSelectSearch.Multiline = true;
            this.textBoxSelectSearch.Name = "textBoxSelectSearch";
            this.textBoxSelectSearch.Size = new System.Drawing.Size(623, 317);
            this.textBoxSelectSearch.TabIndex = 7;
            // 
            // tabSelectId
            // 
            this.tabSelectId.Controls.Add(this.textBoxSelectId);
            this.tabSelectId.Location = new System.Drawing.Point(4, 24);
            this.tabSelectId.Name = "tabSelectId";
            this.tabSelectId.Padding = new System.Windows.Forms.Padding(3);
            this.tabSelectId.Size = new System.Drawing.Size(615, 313);
            this.tabSelectId.TabIndex = 1;
            this.tabSelectId.Text = "Select_Id";
            this.tabSelectId.UseVisualStyleBackColor = true;
            // 
            // textBoxSelectId
            // 
            this.textBoxSelectId.Location = new System.Drawing.Point(-4, 0);
            this.textBoxSelectId.Multiline = true;
            this.textBoxSelectId.Name = "textBoxSelectId";
            this.textBoxSelectId.Size = new System.Drawing.Size(623, 315);
            this.textBoxSelectId.TabIndex = 8;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.textBoxDelete);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(615, 313);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Delete";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBoxDelete
            // 
            this.textBoxDelete.Location = new System.Drawing.Point(-4, 0);
            this.textBoxDelete.Multiline = true;
            this.textBoxDelete.Name = "textBoxDelete";
            this.textBoxDelete.Size = new System.Drawing.Size(623, 314);
            this.textBoxDelete.TabIndex = 9;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.textBoxUpdate);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(615, 313);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Update";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // textBoxUpdate
            // 
            this.textBoxUpdate.Location = new System.Drawing.Point(-4, 0);
            this.textBoxUpdate.Multiline = true;
            this.textBoxUpdate.Name = "textBoxUpdate";
            this.textBoxUpdate.Size = new System.Drawing.Size(623, 313);
            this.textBoxUpdate.TabIndex = 10;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBoxInsert);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(615, 313);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "Insert";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBoxInsert
            // 
            this.textBoxInsert.Location = new System.Drawing.Point(-4, 0);
            this.textBoxInsert.Multiline = true;
            this.textBoxInsert.Name = "textBoxInsert";
            this.textBoxInsert.Size = new System.Drawing.Size(623, 313);
            this.textBoxInsert.TabIndex = 11;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.textBoxExecuteSp);
            this.tabPage5.Location = new System.Drawing.Point(4, 24);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(615, 313);
            this.tabPage5.TabIndex = 5;
            this.tabPage5.Text = "Execute Sp";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // textBoxExecuteSp
            // 
            this.textBoxExecuteSp.Location = new System.Drawing.Point(-4, 0);
            this.textBoxExecuteSp.Multiline = true;
            this.textBoxExecuteSp.Name = "textBoxExecuteSp";
            this.textBoxExecuteSp.Size = new System.Drawing.Size(623, 313);
            this.textBoxExecuteSp.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 582);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "Stored Procedure Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDb)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabSelectId.ResumeLayout(false);
            this.tabSelectId.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox2;
        private Label lblDb;
        private ComboBox comboDb;
        private ComboBox comboTable;
        private Label lblTable;
        private PictureBox pictureTable;
        private PictureBox pictureDb;
        private GroupBox groupBox1;
        private Button btnForSelectedTable;
        private GroupBox groupBox3;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TextBox textBoxSelectSearch;
        private TabPage tabSelectId;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage2;
        private TextBox textBoxSelectId;
        private TextBox textBoxDelete;
        private TextBox textBoxUpdate;
        private TextBox textBoxInsert;
        private Button btnForSelectedDatabase;
        private TabPage tabPage5;
        private TextBox textBoxExecuteSp;
    }
}