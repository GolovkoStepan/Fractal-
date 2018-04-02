namespace TestAppWinForms
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pbFractalImage = new System.Windows.Forms.PictureBox();
            this.gbGenSettings = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbQualFac = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCalcAlg = new System.Windows.Forms.ComboBox();
            this.lblIterCount = new System.Windows.Forms.Label();
            this.tbIterCount = new System.Windows.Forms.TrackBar();
            this.gbColorSettings = new System.Windows.Forms.GroupBox();
            this.btnColorIsNotFractalPoints = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbColorAlg = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbB = new System.Windows.Forms.TrackBar();
            this.tbG = new System.Windows.Forms.TrackBar();
            this.tbR = new System.Windows.Forms.TrackBar();
            this.formStatus = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.formToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnCreate = new System.Windows.Forms.ToolStripButton();
            this.btnReDraw = new System.Windows.Forms.ToolStripButton();
            this.btnOpenFractalData = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPosY = new System.Windows.Forms.Label();
            this.lblPosX = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gbFractalData = new System.Windows.Forms.GroupBox();
            this.pbMapFractal = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbFractalType = new System.Windows.Forms.ComboBox();
            this.lblSizeArea = new System.Windows.Forms.Label();
            this.lblPosYCenter = new System.Windows.Forms.Label();
            this.lblPosXCenter = new System.Windows.Forms.Label();
            this.gbSaveFiles = new System.Windows.Forms.GroupBox();
            this.btnSaveFractalData = new System.Windows.Forms.Button();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbResolutionForSave = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbFractalImage)).BeginInit();
            this.gbGenSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbIterCount)).BeginInit();
            this.gbColorSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbR)).BeginInit();
            this.formStatus.SuspendLayout();
            this.formToolStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbFractalData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapFractal)).BeginInit();
            this.gbSaveFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbFractalImage
            // 
            this.pbFractalImage.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pbFractalImage.Location = new System.Drawing.Point(378, 35);
            this.pbFractalImage.Name = "pbFractalImage";
            this.pbFractalImage.Size = new System.Drawing.Size(500, 500);
            this.pbFractalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFractalImage.TabIndex = 1;
            this.pbFractalImage.TabStop = false;
            this.pbFractalImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbFractalImage_MouseClick);
            this.pbFractalImage.MouseLeave += new System.EventHandler(this.pbFractalImage_MouseLeave);
            this.pbFractalImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbFractalImage_MouseMove);
            // 
            // gbGenSettings
            // 
            this.gbGenSettings.BackColor = System.Drawing.Color.White;
            this.gbGenSettings.Controls.Add(this.label3);
            this.gbGenSettings.Controls.Add(this.cbQualFac);
            this.gbGenSettings.Controls.Add(this.label2);
            this.gbGenSettings.Controls.Add(this.cbCalcAlg);
            this.gbGenSettings.Controls.Add(this.lblIterCount);
            this.gbGenSettings.Controls.Add(this.tbIterCount);
            this.gbGenSettings.Location = new System.Drawing.Point(12, 35);
            this.gbGenSettings.Name = "gbGenSettings";
            this.gbGenSettings.Size = new System.Drawing.Size(350, 178);
            this.gbGenSettings.TabIndex = 2;
            this.gbGenSettings.TabStop = false;
            this.gbGenSettings.Text = "Настройки генерации";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Качество изображения";
            // 
            // cbQualFac
            // 
            this.cbQualFac.BackColor = System.Drawing.Color.White;
            this.cbQualFac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQualFac.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbQualFac.FormattingEnabled = true;
            this.cbQualFac.Items.AddRange(new object[] {
            "Максимальное",
            "Высокое",
            "Среднее"});
            this.cbQualFac.Location = new System.Drawing.Point(24, 135);
            this.cbQualFac.Name = "cbQualFac";
            this.cbQualFac.Size = new System.Drawing.Size(304, 21);
            this.cbQualFac.TabIndex = 4;
            this.cbQualFac.SelectedIndexChanged += new System.EventHandler(this.cbQualFac_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Алгоритм расчетов:";
            // 
            // cbCalcAlg
            // 
            this.cbCalcAlg.BackColor = System.Drawing.Color.White;
            this.cbCalcAlg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCalcAlg.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbCalcAlg.FormattingEnabled = true;
            this.cbCalcAlg.Items.AddRange(new object[] {
            "Однопоточный режим расчетов",
            "Многопоточный режим расчетов"});
            this.cbCalcAlg.Location = new System.Drawing.Point(24, 91);
            this.cbCalcAlg.Name = "cbCalcAlg";
            this.cbCalcAlg.Size = new System.Drawing.Size(304, 21);
            this.cbCalcAlg.TabIndex = 2;
            this.cbCalcAlg.SelectedIndexChanged += new System.EventHandler(this.cbCalcAlg_SelectedIndexChanged);
            // 
            // lblIterCount
            // 
            this.lblIterCount.AutoSize = true;
            this.lblIterCount.Location = new System.Drawing.Point(22, 24);
            this.lblIterCount.Name = "lblIterCount";
            this.lblIterCount.Size = new System.Drawing.Size(25, 13);
            this.lblIterCount.TabIndex = 1;
            this.lblIterCount.Text = "qqq";
            // 
            // tbIterCount
            // 
            this.tbIterCount.Location = new System.Drawing.Point(24, 40);
            this.tbIterCount.Maximum = 25000;
            this.tbIterCount.Minimum = 200;
            this.tbIterCount.Name = "tbIterCount";
            this.tbIterCount.Size = new System.Drawing.Size(304, 45);
            this.tbIterCount.TabIndex = 0;
            this.tbIterCount.TickFrequency = 1000;
            this.tbIterCount.Value = 350;
            this.tbIterCount.Scroll += new System.EventHandler(this.tbIterCount_Scroll);
            // 
            // gbColorSettings
            // 
            this.gbColorSettings.Controls.Add(this.btnColorIsNotFractalPoints);
            this.gbColorSettings.Controls.Add(this.label7);
            this.gbColorSettings.Controls.Add(this.cbColorAlg);
            this.gbColorSettings.Controls.Add(this.label6);
            this.gbColorSettings.Controls.Add(this.label5);
            this.gbColorSettings.Controls.Add(this.label4);
            this.gbColorSettings.Controls.Add(this.tbB);
            this.gbColorSettings.Controls.Add(this.tbG);
            this.gbColorSettings.Controls.Add(this.tbR);
            this.gbColorSettings.Location = new System.Drawing.Point(12, 222);
            this.gbColorSettings.Name = "gbColorSettings";
            this.gbColorSettings.Size = new System.Drawing.Size(350, 313);
            this.gbColorSettings.TabIndex = 3;
            this.gbColorSettings.TabStop = false;
            this.gbColorSettings.Text = "Настройки цветовой схемы";
            // 
            // btnColorIsNotFractalPoints
            // 
            this.btnColorIsNotFractalPoints.BackColor = System.Drawing.Color.Turquoise;
            this.btnColorIsNotFractalPoints.FlatAppearance.BorderColor = System.Drawing.Color.Turquoise;
            this.btnColorIsNotFractalPoints.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen;
            this.btnColorIsNotFractalPoints.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btnColorIsNotFractalPoints.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColorIsNotFractalPoints.Location = new System.Drawing.Point(24, 261);
            this.btnColorIsNotFractalPoints.Name = "btnColorIsNotFractalPoints";
            this.btnColorIsNotFractalPoints.Size = new System.Drawing.Size(302, 30);
            this.btnColorIsNotFractalPoints.TabIndex = 9;
            this.btnColorIsNotFractalPoints.Text = "Цвет не входящих в множество точек";
            this.btnColorIsNotFractalPoints.UseVisualStyleBackColor = false;
            this.btnColorIsNotFractalPoints.Click += new System.EventHandler(this.btnColorIsNotFractalPoints_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 218);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Алгоритм определения цвета:";
            // 
            // cbColorAlg
            // 
            this.cbColorAlg.BackColor = System.Drawing.Color.White;
            this.cbColorAlg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColorAlg.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbColorAlg.FormattingEnabled = true;
            this.cbColorAlg.Items.AddRange(new object[] {
            "Escape Time Algorithm",
            "Normalized Iteration Count Algorithm"});
            this.cbColorAlg.Location = new System.Drawing.Point(24, 234);
            this.cbColorAlg.Name = "cbColorAlg";
            this.cbColorAlg.Size = new System.Drawing.Size(302, 21);
            this.cbColorAlg.TabIndex = 7;
            this.cbColorAlg.SelectedIndexChanged += new System.EventHandler(this.cbColorAlg_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Синий цвет:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Зеленый цвет:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Красный цвет:";
            // 
            // tbB
            // 
            this.tbB.Location = new System.Drawing.Point(24, 174);
            this.tbB.Maximum = 255;
            this.tbB.Minimum = 1;
            this.tbB.Name = "tbB";
            this.tbB.Size = new System.Drawing.Size(304, 45);
            this.tbB.TabIndex = 2;
            this.tbB.TickFrequency = 20;
            this.tbB.Value = 1;
            this.tbB.Scroll += new System.EventHandler(this.tbB_Scroll);
            // 
            // tbG
            // 
            this.tbG.Location = new System.Drawing.Point(24, 110);
            this.tbG.Maximum = 255;
            this.tbG.Minimum = 1;
            this.tbG.Name = "tbG";
            this.tbG.Size = new System.Drawing.Size(304, 45);
            this.tbG.TabIndex = 1;
            this.tbG.TickFrequency = 20;
            this.tbG.Value = 1;
            this.tbG.Scroll += new System.EventHandler(this.tbG_Scroll);
            // 
            // tbR
            // 
            this.tbR.Location = new System.Drawing.Point(24, 46);
            this.tbR.Maximum = 255;
            this.tbR.Minimum = 1;
            this.tbR.Name = "tbR";
            this.tbR.Size = new System.Drawing.Size(304, 45);
            this.tbR.TabIndex = 0;
            this.tbR.TickFrequency = 20;
            this.tbR.Value = 1;
            this.tbR.Scroll += new System.EventHandler(this.tbR_Scroll);
            // 
            // formStatus
            // 
            this.formStatus.BackColor = System.Drawing.Color.Transparent;
            this.formStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.progressBar});
            this.formStatus.Location = new System.Drawing.Point(0, 545);
            this.formStatus.Name = "formStatus";
            this.formStatus.Size = new System.Drawing.Size(1249, 22);
            this.formStatus.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 16);
            this.progressBar.Visible = false;
            // 
            // formToolStrip
            // 
            this.formToolStrip.BackColor = System.Drawing.Color.Transparent;
            this.formToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCreate,
            this.btnReDraw,
            this.btnOpenFractalData});
            this.formToolStrip.Location = new System.Drawing.Point(0, 0);
            this.formToolStrip.Name = "formToolStrip";
            this.formToolStrip.Size = new System.Drawing.Size(1249, 25);
            this.formToolStrip.TabIndex = 5;
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.Beige;
            this.btnCreate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCreate.Image = ((System.Drawing.Image)(resources.GetObject("btnCreate.Image")));
            this.btnCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(54, 22);
            this.btnCreate.Text = "Создать";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnReDraw
            // 
            this.btnReDraw.BackColor = System.Drawing.Color.PaleGreen;
            this.btnReDraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnReDraw.Image = ((System.Drawing.Image)(resources.GetObject("btnReDraw.Image")));
            this.btnReDraw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReDraw.Name = "btnReDraw";
            this.btnReDraw.Size = new System.Drawing.Size(89, 22);
            this.btnReDraw.Text = "Перерисовать";
            this.btnReDraw.Click += new System.EventHandler(this.btnReDraw_Click);
            // 
            // btnOpenFractalData
            // 
            this.btnOpenFractalData.BackColor = System.Drawing.Color.Aqua;
            this.btnOpenFractalData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOpenFractalData.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenFractalData.Image")));
            this.btnOpenFractalData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenFractalData.Name = "btnOpenFractalData";
            this.btnOpenFractalData.Size = new System.Drawing.Size(90, 22);
            this.btnOpenFractalData.Text = "Открыть файл";
            this.btnOpenFractalData.Click += new System.EventHandler(this.btnOpenFractalData_ClickAsync);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPosY);
            this.groupBox1.Controls.Add(this.lblPosX);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(893, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 94);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Позиция курсора относительно системы координат фрактала";
            // 
            // lblPosY
            // 
            this.lblPosY.AutoSize = true;
            this.lblPosY.Location = new System.Drawing.Point(39, 57);
            this.lblPosY.Name = "lblPosY";
            this.lblPosY.Size = new System.Drawing.Size(22, 13);
            this.lblPosY.TabIndex = 3;
            this.lblPosY.Text = "- - -";
            // 
            // lblPosX
            // 
            this.lblPosX.AutoSize = true;
            this.lblPosX.Location = new System.Drawing.Point(39, 35);
            this.lblPosX.Name = "lblPosX";
            this.lblPosX.Size = new System.Drawing.Size(22, 13);
            this.lblPosX.TabIndex = 2;
            this.lblPosX.Text = "- - -";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Y:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "X:";
            // 
            // gbFractalData
            // 
            this.gbFractalData.Controls.Add(this.pbMapFractal);
            this.gbFractalData.Controls.Add(this.label10);
            this.gbFractalData.Controls.Add(this.cbFractalType);
            this.gbFractalData.Controls.Add(this.lblSizeArea);
            this.gbFractalData.Controls.Add(this.lblPosYCenter);
            this.gbFractalData.Controls.Add(this.lblPosXCenter);
            this.gbFractalData.Location = new System.Drawing.Point(893, 135);
            this.gbFractalData.Name = "gbFractalData";
            this.gbFractalData.Size = new System.Drawing.Size(344, 211);
            this.gbFractalData.TabIndex = 7;
            this.gbFractalData.TabStop = false;
            this.gbFractalData.Text = "Данные фрактала";
            // 
            // pbMapFractal
            // 
            this.pbMapFractal.BackColor = System.Drawing.Color.DarkGray;
            this.pbMapFractal.Location = new System.Drawing.Point(231, 87);
            this.pbMapFractal.Name = "pbMapFractal";
            this.pbMapFractal.Size = new System.Drawing.Size(100, 100);
            this.pbMapFractal.TabIndex = 9;
            this.pbMapFractal.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Тип фрактала:";
            // 
            // cbFractalType
            // 
            this.cbFractalType.BackColor = System.Drawing.Color.White;
            this.cbFractalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFractalType.FormattingEnabled = true;
            this.cbFractalType.Items.AddRange(new object[] {
            "Мн. Мандельброта",
            "Мн. Жюлиа",
            "Лямбда - фрактал"});
            this.cbFractalType.Location = new System.Drawing.Point(19, 51);
            this.cbFractalType.Name = "cbFractalType";
            this.cbFractalType.Size = new System.Drawing.Size(312, 21);
            this.cbFractalType.TabIndex = 3;
            this.cbFractalType.SelectionChangeCommitted += new System.EventHandler(this.cbFractalType_SelectionChangeCommitted);
            // 
            // lblSizeArea
            // 
            this.lblSizeArea.AutoSize = true;
            this.lblSizeArea.Location = new System.Drawing.Point(20, 165);
            this.lblSizeArea.Name = "lblSizeArea";
            this.lblSizeArea.Size = new System.Drawing.Size(41, 13);
            this.lblSizeArea.TabIndex = 2;
            this.lblSizeArea.Text = "label12";
            // 
            // lblPosYCenter
            // 
            this.lblPosYCenter.AutoSize = true;
            this.lblPosYCenter.Location = new System.Drawing.Point(20, 133);
            this.lblPosYCenter.Name = "lblPosYCenter";
            this.lblPosYCenter.Size = new System.Drawing.Size(41, 13);
            this.lblPosYCenter.TabIndex = 1;
            this.lblPosYCenter.Text = "label11";
            // 
            // lblPosXCenter
            // 
            this.lblPosXCenter.AutoSize = true;
            this.lblPosXCenter.Location = new System.Drawing.Point(20, 99);
            this.lblPosXCenter.Name = "lblPosXCenter";
            this.lblPosXCenter.Size = new System.Drawing.Size(41, 13);
            this.lblPosXCenter.TabIndex = 0;
            this.lblPosXCenter.Text = "label10";
            // 
            // gbSaveFiles
            // 
            this.gbSaveFiles.Controls.Add(this.btnSaveFractalData);
            this.gbSaveFiles.Controls.Add(this.btnSaveImage);
            this.gbSaveFiles.Controls.Add(this.label1);
            this.gbSaveFiles.Controls.Add(this.cbResolutionForSave);
            this.gbSaveFiles.Location = new System.Drawing.Point(893, 352);
            this.gbSaveFiles.Name = "gbSaveFiles";
            this.gbSaveFiles.Size = new System.Drawing.Size(344, 116);
            this.gbSaveFiles.TabIndex = 8;
            this.gbSaveFiles.TabStop = false;
            this.gbSaveFiles.Text = "Сохранение файлов";
            // 
            // btnSaveFractalData
            // 
            this.btnSaveFractalData.BackColor = System.Drawing.Color.Orange;
            this.btnSaveFractalData.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.btnSaveFractalData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.btnSaveFractalData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SandyBrown;
            this.btnSaveFractalData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveFractalData.Location = new System.Drawing.Point(19, 73);
            this.btnSaveFractalData.Name = "btnSaveFractalData";
            this.btnSaveFractalData.Size = new System.Drawing.Size(154, 29);
            this.btnSaveFractalData.TabIndex = 3;
            this.btnSaveFractalData.Text = "Сохранить данные";
            this.btnSaveFractalData.UseVisualStyleBackColor = false;
            this.btnSaveFractalData.Click += new System.EventHandler(this.btnSaveFractalData_Click);
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSaveImage.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSaveImage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnSaveImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btnSaveImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveImage.Location = new System.Drawing.Point(179, 73);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(154, 29);
            this.btnSaveImage.TabIndex = 2;
            this.btnSaveImage.Text = "Сохранить изображение";
            this.btnSaveImage.UseVisualStyleBackColor = false;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Разрешение изображения:";
            // 
            // cbResolutionForSave
            // 
            this.cbResolutionForSave.BackColor = System.Drawing.Color.White;
            this.cbResolutionForSave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbResolutionForSave.FormattingEnabled = true;
            this.cbResolutionForSave.Items.AddRange(new object[] {
            "800 x 800",
            "1024 x 1024",
            "1280 x 1280",
            "1920 x 1920"});
            this.cbResolutionForSave.Location = new System.Drawing.Point(19, 44);
            this.cbResolutionForSave.Name = "cbResolutionForSave";
            this.cbResolutionForSave.Size = new System.Drawing.Size(312, 21);
            this.cbResolutionForSave.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1249, 567);
            this.Controls.Add(this.gbSaveFiles);
            this.Controls.Add(this.gbFractalData);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.formToolStrip);
            this.Controls.Add(this.formStatus);
            this.Controls.Add(this.gbColorSettings);
            this.Controls.Add(this.gbGenSettings);
            this.Controls.Add(this.pbFractalImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fractal #";
            ((System.ComponentModel.ISupportInitialize)(this.pbFractalImage)).EndInit();
            this.gbGenSettings.ResumeLayout(false);
            this.gbGenSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbIterCount)).EndInit();
            this.gbColorSettings.ResumeLayout(false);
            this.gbColorSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbR)).EndInit();
            this.formStatus.ResumeLayout(false);
            this.formStatus.PerformLayout();
            this.formToolStrip.ResumeLayout(false);
            this.formToolStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbFractalData.ResumeLayout(false);
            this.gbFractalData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapFractal)).EndInit();
            this.gbSaveFiles.ResumeLayout(false);
            this.gbSaveFiles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbFractalImage;
        private System.Windows.Forms.GroupBox gbGenSettings;
        private System.Windows.Forms.Label lblIterCount;
        private System.Windows.Forms.TrackBar tbIterCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbQualFac;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCalcAlg;
        private System.Windows.Forms.GroupBox gbColorSettings;
        private System.Windows.Forms.Button btnColorIsNotFractalPoints;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbColorAlg;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar tbB;
        private System.Windows.Forms.TrackBar tbG;
        private System.Windows.Forms.TrackBar tbR;
        private System.Windows.Forms.StatusStrip formStatus;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStrip formToolStrip;
        private System.Windows.Forms.ToolStripButton btnCreate;
        private System.Windows.Forms.ToolStripButton btnReDraw;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPosY;
        private System.Windows.Forms.Label lblPosX;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gbFractalData;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbFractalType;
        private System.Windows.Forms.Label lblSizeArea;
        private System.Windows.Forms.Label lblPosYCenter;
        private System.Windows.Forms.Label lblPosXCenter;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.GroupBox gbSaveFiles;
        private System.Windows.Forms.Button btnSaveFractalData;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbResolutionForSave;
        private System.Windows.Forms.ToolStripButton btnOpenFractalData;
        private System.Windows.Forms.PictureBox pbMapFractal;
    }
}

