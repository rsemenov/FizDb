namespace ProjectsManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.действиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.динамікаЗмінToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пошукToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.адмініструванняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зробитиАрхівБазиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.відкритиАрхівToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.відкритиПоточнийСтанToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.довідкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.одержатиДовідкуПроУчастьУЗмаганняхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lstReqs = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.описаниеЗапорсаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lstTables = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.действиеToolStripMenuItem,
            this.адмініструванняToolStripMenuItem,
            this.довідкаToolStripMenuItem,
            this.помощьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(779, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // действиеToolStripMenuItem
            // 
            this.действиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.динамікаЗмінToolStripMenuItem,
            this.пошукToolStripMenuItem});
            this.действиеToolStripMenuItem.Name = "действиеToolStripMenuItem";
            this.действиеToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.действиеToolStripMenuItem.Text = "Дія";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.сохранитьToolStripMenuItem.Text = "Зберегти";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // динамікаЗмінToolStripMenuItem
            // 
            this.динамікаЗмінToolStripMenuItem.Name = "динамікаЗмінToolStripMenuItem";
            this.динамікаЗмінToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.динамікаЗмінToolStripMenuItem.Text = "Динаміка змін";
            this.динамікаЗмінToolStripMenuItem.Click += new System.EventHandler(this.динамікаЗмінToolStripMenuItem_Click);
            // 
            // пошукToolStripMenuItem
            // 
            this.пошукToolStripMenuItem.Name = "пошукToolStripMenuItem";
            this.пошукToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.пошукToolStripMenuItem.Text = "Пошук";
            this.пошукToolStripMenuItem.Click += new System.EventHandler(this.пошукToolStripMenuItem_Click);
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.помощьToolStripMenuItem.Text = "Допомога";
            this.помощьToolStripMenuItem.Click += new System.EventHandler(this.помощьToolStripMenuItem_Click);
            // 
            // адмініструванняToolStripMenuItem
            // 
            this.адмініструванняToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.зробитиАрхівБазиToolStripMenuItem,
            this.відкритиАрхівToolStripMenuItem,
            this.відкритиПоточнийСтанToolStripMenuItem});
            this.адмініструванняToolStripMenuItem.Name = "адмініструванняToolStripMenuItem";
            this.адмініструванняToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.адмініструванняToolStripMenuItem.Text = "Адміністрування";
            this.адмініструванняToolStripMenuItem.Visible = false;
            // 
            // зробитиАрхівБазиToolStripMenuItem
            // 
            this.зробитиАрхівБазиToolStripMenuItem.Name = "зробитиАрхівБазиToolStripMenuItem";
            this.зробитиАрхівБазиToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.зробитиАрхівБазиToolStripMenuItem.Text = "Зробити архів бази";
            this.зробитиАрхівБазиToolStripMenuItem.Click += new System.EventHandler(this.зробитиАрхівБазиToolStripMenuItem_Click);
            // 
            // відкритиАрхівToolStripMenuItem
            // 
            this.відкритиАрхівToolStripMenuItem.Name = "відкритиАрхівToolStripMenuItem";
            this.відкритиАрхівToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.відкритиАрхівToolStripMenuItem.Text = "Відкрити архів";
            this.відкритиАрхівToolStripMenuItem.Click += new System.EventHandler(this.відкритиАрхівToolStripMenuItem_Click);
            // 
            // відкритиПоточнийСтанToolStripMenuItem
            // 
            this.відкритиПоточнийСтанToolStripMenuItem.Name = "відкритиПоточнийСтанToolStripMenuItem";
            this.відкритиПоточнийСтанToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.відкритиПоточнийСтанToolStripMenuItem.Text = "Відкрити поточний стан";
            this.відкритиПоточнийСтанToolStripMenuItem.Click += new System.EventHandler(this.відкритиПоточнийСтанToolStripMenuItem_Click);
            // 
            // довідкаToolStripMenuItem
            // 
            this.довідкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.одержатиДовідкуПроУчастьУЗмаганняхToolStripMenuItem});
            this.довідкаToolStripMenuItem.Name = "довідкаToolStripMenuItem";
            this.довідкаToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.довідкаToolStripMenuItem.Text = "Довідка";
            // 
            // одержатиДовідкуПроУчастьУЗмаганняхToolStripMenuItem
            // 
            this.одержатиДовідкуПроУчастьУЗмаганняхToolStripMenuItem.Name = "одержатиДовідкуПроУчастьУЗмаганняхToolStripMenuItem";
            this.одержатиДовідкуПроУчастьУЗмаганняхToolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            this.одержатиДовідкуПроУчастьУЗмаганняхToolStripMenuItem.Text = "Одержати довідку про участь у змаганнях";
            this.одержатиДовідкуПроУчастьУЗмаганняхToolStripMenuItem.Click += new System.EventHandler(this.одержатиДовідкуПроУчастьУЗмаганняхToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 459);
            this.panel1.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lstReqs);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 230);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(245, 229);
            this.panel4.TabIndex = 4;
            // 
            // lstReqs
            // 
            this.lstReqs.ContextMenuStrip = this.contextMenuStrip1;
            this.lstReqs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstReqs.FormattingEnabled = true;
            this.lstReqs.Location = new System.Drawing.Point(0, 24);
            this.lstReqs.Name = "lstReqs";
            this.lstReqs.Size = new System.Drawing.Size(243, 203);
            this.lstReqs.TabIndex = 3;
            this.lstReqs.DoubleClick += new System.EventHandler(this.lstReqs_DoubleClick);
            this.lstReqs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstReqs_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.описаниеЗапорсаToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(184, 26);
            // 
            // описаниеЗапорсаToolStripMenuItem
            // 
            this.описаниеЗапорсаToolStripMenuItem.Name = "описаниеЗапорсаToolStripMenuItem";
            this.описаниеЗапорсаToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.описаниеЗапорсаToolStripMenuItem.Text = "Інформація про запит";
            this.описаниеЗапорсаToolStripMenuItem.Click += new System.EventHandler(this.описаниеЗапорсаToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Динамічні запити";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lstTables);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(245, 230);
            this.panel3.TabIndex = 3;
            // 
            // lstTables
            // 
            this.lstTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTables.FormattingEnabled = true;
            this.lstTables.Location = new System.Drawing.Point(0, 24);
            this.lstTables.Name = "lstTables";
            this.lstTables.Size = new System.Drawing.Size(243, 204);
            this.lstTables.TabIndex = 3;
            this.lstTables.DoubleClick += new System.EventHandler(this.lstTables_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Таблиці";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(245, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(534, 459);
            this.panel2.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(534, 459);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 483);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Автоматизована Інформаційна Система - Спорт на факультеті";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListBox lstTables;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ListBox lstReqs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem действиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem описаниеЗапорсаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem динамікаЗмінToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пошукToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem адмініструванняToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зробитиАрхівБазиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem відкритиАрхівToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem відкритиПоточнийСтанToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem довідкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem одержатиДовідкуПроУчастьУЗмаганняхToolStripMenuItem;

    }
}

