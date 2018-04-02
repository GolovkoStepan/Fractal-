using System;
using System.Drawing;
using System.Windows.Forms;
using FractalCore;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using FractalCore.Fractals;

namespace TestAppWinForms
{
    public partial class MainForm : Form
    {
        AbstractFractal fractalData = new FractalMandelbrot();
        GenerationSettings genSettings = new GenerationSettings();
        ColorSettings colorSettings = new ColorSettings();
        FractalCreator creator;

        AbstractFractal fractalMapData = new FractalMandelbrot();
        GenerationSettings genSetMap = new GenerationSettings();
        ColorSettings mapColorSettings = new ColorSettings();
        FractalCreator fractalMap;


        public MainForm()
        {
            InitializeComponent();
            creator = new FractalCreator(fractalData, genSettings, colorSettings);
            genSettings.Resolution = pbFractalImage.Size;

            // --------------- FractalMap -------------------------
            fractalMap = new FractalCreator(fractalMapData, genSetMap, mapColorSettings);
            genSetMap.Resolution = pbMapFractal.Size;
            
            pbMapFractal.Image = fractalMap.Create();
            // ----------------------------------------------------

            tbIterCount.Value = genSettings.IterationCount;
            tbR.Value = colorSettings.R;
            tbG.Value = colorSettings.G;
            tbB.Value = colorSettings.B;

            cbCalcAlg.SelectedIndex = 0;
            cbColorAlg.SelectedIndex = 0;
            cbQualFac.SelectedIndex = 0;
            cbFractalType.SelectedIndex = 0;
            cbResolutionForSave.SelectedIndex = 0;

            lblIterCount.Text = $"Число итераций = {genSettings.IterationCount}";
            lblPosXCenter.Text = $"Центр X: {fractalData.CenterX}";
            lblPosYCenter.Text = $"Центр Y: {fractalData.CenterY}";
            lblSizeArea.Text = $"Увеличение: {fractalData.SizeArea}";

            lblStatus.Text = "Готово";
        }

        private GenerationAlgorithms GetGenerationAlgorithm()
        {
            switch(cbCalcAlg.SelectedIndex)
            {
                case 0:
                    {
                        return GenerationAlgorithms.OneThreadCalculation;
                    }
                case 1:
                    {
                        return GenerationAlgorithms.MultiThreadCalculation;
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }

        private ColorAlgorithms GetColorAlgorithm()
        {
            switch(cbColorAlg.SelectedIndex)
            {
                case 0:
                    {
                        return ColorAlgorithms.EscapeTimeAlgorithm;
                    }
                case 1:
                    {
                        return ColorAlgorithms.NormalizedIterationCountAlgorithm;
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }

        private int GetQualityFactor()
        {
            switch(cbQualFac.SelectedIndex)
            {
                case 0:
                    {
                        return 1;
                    }
                case 1:
                    {
                        return 2;
                    }
                case 2:
                    {
                        return 3;
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }

        private AbstractFractal GetFractalType()
        {
            switch(cbFractalType.SelectedIndex)
            {
                case 0:
                    {
                        return new FractalMandelbrot();
                    }
                case 1:
                    {
                        return new FractalJulia();
                    }
                case 2:
                    {
                        return new FractalLambda();
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }

        private Size GetResolution()
        {
            switch (cbResolutionForSave.SelectedIndex)
            {
                case 0:
                    {
                        return new Size(800, 800);
                    }
                case 1:
                    {
                        return new Size(1024, 1024);
                    }
                case 2:
                    {
                        return new Size(1280, 1280);
                    }
                case 3:
                    {
                        return new Size(1920, 1920);
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }

        private void ProgramStatusBusy()
        {
            formStatus.BackColor = Color.Coral;
            lblStatus.Text = "Выполнение...";
            progressBar.AnimationStart();
        }

        private void ProgramStatusDone()
        {
            formStatus.BackColor = Color.DodgerBlue;
            progressBar.AnimationStop();
            lblStatus.Text = "Готово";
        }

        // =========================================================================================================

        private void tbIterCount_Scroll(object sender, EventArgs e)
        {
            genSettings.IterationCount = tbIterCount.Value;
            lblIterCount.Text = $"Число итераций = {genSettings.IterationCount}";
        }

        private async void tbR_Scroll(object sender, EventArgs e)
        {
            colorSettings.R = (byte)tbR.Value;

            pbFractalImage.Image = await creator.ReDrawAsync();
        }

        private async void tbG_Scroll(object sender, EventArgs e)
        {
            colorSettings.G = (byte)tbG.Value;

            pbFractalImage.Image = await creator.ReDrawAsync();
        }

        private async void tbB_Scroll(object sender, EventArgs e)
        {
            colorSettings.B = (byte)tbB.Value;

            pbFractalImage.Image = await creator.ReDrawAsync();
        }

        private void cbCalcAlg_SelectedIndexChanged(object sender, EventArgs e)
        {
            genSettings.Algorithm = GetGenerationAlgorithm();
        }

        private async void cbQualFac_SelectedIndexChanged(object sender, EventArgs e)
        {
            genSettings.QualityFactor = GetQualityFactor();

            ProgramStatusBusy();

            pbFractalImage.Image = await creator.CreateAsync();

            ProgramStatusDone();
        }

        private async void cbColorAlg_SelectedIndexChanged(object sender, EventArgs e)
        {
            colorSettings.Algorithm = GetColorAlgorithm();

            ProgramStatusBusy();

            pbFractalImage.Image = await creator.ReDrawAsync();

            ProgramStatusDone();
        }

        private async void btnColorIsNotFractalPoints_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog()
            {
                Color = colorSettings.NotFractalPointsColor
            };

            if (cd.ShowDialog() == DialogResult.OK)
            {
                colorSettings.NotFractalPointsColor = cd.Color;

                ProgramStatusBusy();

                pbFractalImage.Image = await creator.ReDrawAsync();
            }

            ProgramStatusDone();
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            ProgramStatusBusy();

            pbFractalImage.Image = await creator.CreateAsync();

            ProgramStatusDone();
        }

        private async void btnReDraw_Click(object sender, EventArgs e)
        {
            ProgramStatusBusy();

            pbFractalImage.Image = await creator.ReDrawAsync();

            ProgramStatusDone();
        }

        private void pbFractalImage_MouseMove(object sender, MouseEventArgs e)
        {
            lblPosX.Text = Convert.ToString(creator.PositionXFractalCoord(e.X));
            lblPosY.Text = Convert.ToString(creator.PositionYFractalCoord(e.Y));
        }

        private void pbFractalImage_MouseLeave(object sender, EventArgs e)
        {
            lblPosX.Text = "- - -";
            lblPosY.Text = "- - -";
        }

        private async void cbFractalType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fractalData = GetFractalType();

            lblPosXCenter.Text = $"Центр X: {fractalData.CenterX}";
            lblPosYCenter.Text = $"Центр Y: {fractalData.CenterY}";
            lblSizeArea.Text = $"Увеличение: {fractalData.SizeArea}";

            ProgramStatusBusy();

            creator = new FractalCreator(fractalData, genSettings, colorSettings);

            pbFractalImage.Image = await creator.CreateAsync();

            // --------------- FractalMap --------------------
            fractalMapData = GetFractalType();

            fractalMap = new FractalCreator(fractalMapData, genSetMap, mapColorSettings);

            pbMapFractal.Image = fractalMap.Create();
            // -----------------------------------------------

            ProgramStatusDone();
        }

        private async void pbFractalImage_MouseClick(object sender, MouseEventArgs e)
        {
            if (pbFractalImage.Image != null)
            {
                fractalData.CenterX = creator.PositionXFractalCoord(e.X);
                fractalData.CenterY = creator.PositionYFractalCoord(e.Y);

                switch (e.Button)
                {
                    case MouseButtons.Left:
                        {
                            fractalData.ZoomPlus();
                            break;
                        }
                    case MouseButtons.Middle:
                        {
                            fractalData.Reset();
                            break;
                        }
                    case MouseButtons.Right:
                        {
                            fractalData.ZoomMinus();
                            break;
                        }
                }

                ProgramStatusBusy();

                pbFractalImage.Image = await creator.CreateAsync();

                ProgramStatusDone();

                lblPosXCenter.Text = $"Центр X: {fractalData.CenterX}";
                lblPosYCenter.Text = $"Центр Y: {fractalData.CenterY}";
                lblSizeArea.Text = $"Увеличение: {fractalData.SizeArea}";
            }
        }

        private void btnSaveFractalData_Click(object sender, EventArgs e)
        {
            var sd = new SaveFileDialog()
            {
                FileName = "fractalData.fd",
                Filter = "FractalData files(*.fd) | *.fd",
                RestoreDirectory = true
            };

            if (sd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            creator.SaveFractalInfo(sd.FileName);

            MessageBox.Show($"Данные генерации текущего изображения сохранены: {sd.FileName}", "Fractal #");
        }

        private async void btnSaveImage_Click(object sender, EventArgs e)
        {
            var sd = new SaveFileDialog()
            {
                FileName = "fractalImage.bmp",
                Filter = "BMP files(*.bmp) | *.bmp | All files(*.*) | *.* ",
                RestoreDirectory = true
            };

            if (sd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            ProgramStatusBusy();

            await creator.SaveImageAsync(GetResolution(), sd.FileName);

            ProgramStatusDone();

            MessageBox.Show($"Изображение сохранено: {sd.FileName}", "Fractal #");
        }

        private async void btnOpenFractalData_ClickAsync(object sender, EventArgs e)
        {
            var od = new OpenFileDialog()
            {
                FileName = "fractalData.fd",
                Filter = "FractalData files(*.fd) | *.fd",
                RestoreDirectory = true
            };

            if (od.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                fractalData = null;
                pbFractalImage.Image = null;

                using (FileStream fs = new FileStream(od.FileName, FileMode.Open))
                {
                    fractalData = (AbstractFractal)formatter.Deserialize(fs);
                }
            }
            catch
            {
                MessageBox.Show($"Произошла ошибка открытия файла. Возможно, файл имеет неверный формат.", "Fractal #", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            creator = new FractalCreator(fractalData, genSettings, colorSettings);

            AbstractFractal bufMapData = (AbstractFractal)fractalData.Clone();
            bufMapData.Reset();

            fractalMap = new FractalCreator(bufMapData, genSetMap, mapColorSettings);

            lblPosXCenter.Text = $"Центр X: {fractalData.CenterX}";
            lblPosYCenter.Text = $"Центр Y: {fractalData.CenterY}";
            lblSizeArea.Text = $"Увеличение: {fractalData.SizeArea}";

            switch(fractalData.FractalType)
            {
                case "Mandelbrot":
                    {
                        cbFractalType.SelectedIndex = 0;
                        break;
                    }
                case "Julia":
                    {
                        cbFractalType.SelectedIndex = 1;
                        break;
                    }
                case "Lambda":
                    {
                        cbFractalType.SelectedIndex = 2;
                        break;
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }

            ProgramStatusBusy();

            pbFractalImage.Image = await creator.CreateAsync();
            pbMapFractal.Image = await fractalMap.CreateAsync();

            ProgramStatusDone();

            MessageBox.Show($"Файл успешно открыт.", "Fractal #");
        }
    }
}