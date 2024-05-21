using System.Windows.Forms;

namespace lab10
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.txtSearchModel = new System.Windows.Forms.TextBox();
            this.btnSearchModel = new System.Windows.Forms.Button();
            this.txtSearchYear = new System.Windows.Forms.TextBox();
            this.btnSearchYear = new System.Windows.Forms.Button();
            this.btnSortModel = new System.Windows.Forms.Button();
            this.btnSortYear = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripComboBox2 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            var colModel = new DataGridViewTextBoxColumn() { DataPropertyName = "Model", HeaderText = "Model" };
            var colYear = new DataGridViewTextBoxColumn() { DataPropertyName = "Year", HeaderText = "Year" };
            var colEngineModel = new DataGridViewTextBoxColumn() { DataPropertyName = "EngineModel", HeaderText = "Engine Model" };
            var colEngineDisplacement = new DataGridViewTextBoxColumn() { DataPropertyName = "EngineDisplacement", HeaderText = "Engine Displacement" };
            var colEngineHorsePower = new DataGridViewTextBoxColumn() { DataPropertyName = "EnginePower", HeaderText = "Engine HorsePower" };

            this.dataGridView1.Columns.AddRange(new DataGridViewColumn[] {
        colModel,
        colYear,
        colEngineModel,
        colEngineDisplacement,
        colEngineHorsePower
    });

            this.dataGridView1.Location = new System.Drawing.Point(12, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 346);
            this.dataGridView1.TabIndex = 0;
            
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 387);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(93, 387);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(713, 385);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(557, 387);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(150, 20);
            this.txtSearch.TabIndex = 4;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 416);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(776, 96);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // txtSearchModel
            // 
            this.txtSearchModel.Location = new System.Drawing.Point(12, 518);
            this.txtSearchModel.Name = "txtSearchModel";
            this.txtSearchModel.Size = new System.Drawing.Size(100, 20);
            this.txtSearchModel.TabIndex = 6;
            // 
            // btnSearchModel
            // 
            this.btnSearchModel.Location = new System.Drawing.Point(118, 515);
            this.btnSearchModel.Name = "btnSearchModel";
            this.btnSearchModel.Size = new System.Drawing.Size(75, 23);
            this.btnSearchModel.TabIndex = 7;
            this.btnSearchModel.Text = "Search Model";
            this.btnSearchModel.UseVisualStyleBackColor = true;
            this.btnSearchModel.Click += new System.EventHandler(this.btnSearchModel_Click);
            // 
            // txtSearchYear
            // 
            this.txtSearchYear.Location = new System.Drawing.Point(199, 515);
            this.txtSearchYear.Name = "txtSearchYear";
            this.txtSearchYear.Size = new System.Drawing.Size(100, 20);
            this.txtSearchYear.TabIndex = 8;
            // 
            // btnSearchYear
            // 
            this.btnSearchYear.Location = new System.Drawing.Point(305, 513);
            this.btnSearchYear.Name = "btnSearchYear";
            this.btnSearchYear.Size = new System.Drawing.Size(75, 23);
            this.btnSearchYear.TabIndex = 9;
            this.btnSearchYear.Text = "Search Year";
            this.btnSearchYear.UseVisualStyleBackColor = true;
            this.btnSearchYear.Click += new System.EventHandler(this.btnSearchYear_Click);
            // 
            // btnSortModel
            // 
            this.btnSortModel.Location = new System.Drawing.Point(386, 512);
            this.btnSortModel.Name = "btnSortModel";
            this.btnSortModel.Size = new System.Drawing.Size(75, 23);
            this.btnSortModel.TabIndex = 10;
            this.btnSortModel.Text = "SortbyModel";
            this.btnSortModel.UseVisualStyleBackColor = true;
            this.btnSortModel.Click += new System.EventHandler(this.btnSortModel_Click);
            // 
            // btnSortYear
            // 
            this.btnSortYear.Location = new System.Drawing.Point(467, 512);
            this.btnSortYear.Name = "btnSortYear";
            this.btnSortYear.Size = new System.Drawing.Size(75, 23);
            this.btnSortYear.TabIndex = 11;
            this.btnSortYear.Text = "SortbyYear";
            this.btnSortYear.UseVisualStyleBackColor = true;
            this.btnSortYear.Click += new System.EventHandler(this.btnSortYear_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1,
            this.toolStripTextBox1,
            this.toolStripComboBox2,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBox1.Enter += new System.EventHandler(this.toolStripComboBox1_Enter);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripComboBox2
            // 
            this.toolStripComboBox2.Name = "toolStripComboBox2";
            this.toolStripComboBox2.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(46, 22);
            this.toolStripButton1.Text = "Search";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnSortYear);
            this.Controls.Add(this.btnSortModel);
            this.Controls.Add(this.btnSearchYear);
            this.Controls.Add(this.txtSearchYear);
            this.Controls.Add(this.btnSearchModel);
            this.Controls.Add(this.txtSearchModel);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox txtSearchModel;
        private System.Windows.Forms.Button btnSearchModel;
        private System.Windows.Forms.TextBox txtSearchYear;
        private System.Windows.Forms.Button btnSearchYear;
        private System.Windows.Forms.Button btnSortModel; // Przycisk do sortowania po Model
        private System.Windows.Forms.Button btnSortYear; // Przycisk do sortowania po Year
        
        private ToolStrip toolStrip1;
        private ToolStripComboBox toolStripComboBox1;
        private ToolStripTextBox toolStripTextBox1;
        private ToolStripComboBox toolStripComboBox2;
        private ToolStripButton toolStripButton1;
    }
}

