namespace HW_2
{
    partial class BotanicalGardenForm
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
            topPanel = new Panel();
            loadXmlButton = new Button();
            loadJsonButton = new Button();
            openDetailsButton = new Button();
            mainSplitContainer = new SplitContainer();
            plantTreeView = new TreeView();
            rightSplitContainer = new SplitContainer();
            plantsDataGridView = new DataGridView();
            plantPictureBox = new PictureBox();
            openGardenFileDialog = new OpenFileDialog();
            topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainSplitContainer).BeginInit();
            mainSplitContainer.Panel1.SuspendLayout();
            mainSplitContainer.Panel2.SuspendLayout();
            mainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)rightSplitContainer).BeginInit();
            rightSplitContainer.Panel1.SuspendLayout();
            rightSplitContainer.Panel2.SuspendLayout();
            rightSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)plantsDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)plantPictureBox).BeginInit();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.Controls.Add(loadXmlButton);
            topPanel.Controls.Add(loadJsonButton);
            topPanel.Controls.Add(openDetailsButton);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Padding = new Padding(10);
            topPanel.Size = new Size(1084, 62);
            topPanel.TabIndex = 0;
            // 
            // loadXmlButton
            // 
            loadXmlButton.Location = new Point(10, 13);
            loadXmlButton.Name = "loadXmlButton";
            loadXmlButton.Size = new Size(140, 36);
            loadXmlButton.TabIndex = 0;
            loadXmlButton.Text = "Загрузить XML";
            loadXmlButton.UseVisualStyleBackColor = true;
            loadXmlButton.Click += LoadXmlButton_Click;
            // 
            // loadJsonButton
            // 
            loadJsonButton.Location = new Point(156, 13);
            loadJsonButton.Name = "loadJsonButton";
            loadJsonButton.Size = new Size(140, 36);
            loadJsonButton.TabIndex = 1;
            loadJsonButton.Text = "Загрузить JSON";
            loadJsonButton.UseVisualStyleBackColor = true;
            loadJsonButton.Click += LoadJsonButton_Click;
            // 
            // openDetailsButton
            // 
            openDetailsButton.Enabled = false;
            openDetailsButton.Location = new Point(302, 13);
            openDetailsButton.Name = "openDetailsButton";
            openDetailsButton.Size = new Size(170, 36);
            openDetailsButton.TabIndex = 2;
            openDetailsButton.Text = "Открыть карточку";
            openDetailsButton.UseVisualStyleBackColor = true;
            openDetailsButton.Click += OpenDetailsButton_Click;
            // 
            // mainSplitContainer
            // 
            mainSplitContainer.Dock = DockStyle.Fill;
            mainSplitContainer.Location = new Point(0, 62);
            mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            mainSplitContainer.Panel1.Controls.Add(plantTreeView);
            mainSplitContainer.Panel1MinSize = 220;
            // 
            // mainSplitContainer.Panel2
            // 
            mainSplitContainer.Panel2.Controls.Add(rightSplitContainer);
            mainSplitContainer.Panel2MinSize = 420;
            mainSplitContainer.Size = new Size(1084, 599);
            mainSplitContainer.SplitterDistance = 275;
            mainSplitContainer.TabIndex = 1;
            // 
            // plantTreeView
            // 
            plantTreeView.Dock = DockStyle.Fill;
            plantTreeView.HideSelection = false;
            plantTreeView.Location = new Point(0, 0);
            plantTreeView.Name = "plantTreeView";
            plantTreeView.Size = new Size(275, 599);
            plantTreeView.TabIndex = 0;
            plantTreeView.AfterSelect += PlantTreeView_AfterSelect;
            // 
            // rightSplitContainer
            // 
            rightSplitContainer.Dock = DockStyle.Fill;
            rightSplitContainer.Location = new Point(0, 0);
            rightSplitContainer.Name = "rightSplitContainer";
            rightSplitContainer.Orientation = Orientation.Horizontal;
            // 
            // rightSplitContainer.Panel1
            // 
            rightSplitContainer.Panel1.Controls.Add(plantsDataGridView);
            rightSplitContainer.Panel1MinSize = 220;
            // 
            // rightSplitContainer.Panel2
            // 
            rightSplitContainer.Panel2.Controls.Add(plantPictureBox);
            rightSplitContainer.Panel2MinSize = 180;
            rightSplitContainer.Size = new Size(805, 599);
            rightSplitContainer.SplitterDistance = 300;
            rightSplitContainer.TabIndex = 0;
            // 
            // plantsDataGridView
            // 
            plantsDataGridView.AllowUserToAddRows = false;
            plantsDataGridView.AllowUserToDeleteRows = false;
            plantsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            plantsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            plantsDataGridView.Dock = DockStyle.Fill;
            plantsDataGridView.Location = new Point(0, 0);
            plantsDataGridView.MultiSelect = false;
            plantsDataGridView.Name = "plantsDataGridView";
            plantsDataGridView.ReadOnly = true;
            plantsDataGridView.RowHeadersWidth = 51;
            plantsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            plantsDataGridView.Size = new Size(805, 300);
            plantsDataGridView.TabIndex = 0;
            plantsDataGridView.SelectionChanged += PlantsDataGridView_SelectionChanged;
            // 
            // plantPictureBox
            // 
            plantPictureBox.BackColor = Color.White;
            plantPictureBox.Dock = DockStyle.Fill;
            plantPictureBox.Location = new Point(0, 0);
            plantPictureBox.Name = "plantPictureBox";
            plantPictureBox.Size = new Size(805, 295);
            plantPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            plantPictureBox.TabIndex = 0;
            plantPictureBox.TabStop = false;
            // 
            // openGardenFileDialog
            // 
            openGardenFileDialog.Title = "Выберите файл ботанического сада";
            // 
            // BotanicalGardenForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 661);
            Controls.Add(mainSplitContainer);
            Controls.Add(topPanel);
            MinimumSize = new Size(900, 600);
            Name = "BotanicalGardenForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ботанический сад - десериализация XML и JSON";
            topPanel.ResumeLayout(false);
            mainSplitContainer.Panel1.ResumeLayout(false);
            mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainSplitContainer).EndInit();
            mainSplitContainer.ResumeLayout(false);
            rightSplitContainer.Panel1.ResumeLayout(false);
            rightSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)rightSplitContainer).EndInit();
            rightSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)plantsDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)plantPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel topPanel;
        private Button loadXmlButton;
        private Button loadJsonButton;
        private Button openDetailsButton;
        private SplitContainer mainSplitContainer;
        private TreeView plantTreeView;
        private SplitContainer rightSplitContainer;
        private DataGridView plantsDataGridView;
        private PictureBox plantPictureBox;
        private OpenFileDialog openGardenFileDialog;
    }
}
