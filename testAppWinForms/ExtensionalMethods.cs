using System.Windows.Forms;

namespace TestAppWinForms
{
    public static class ExtensionalMethods
    {
        public static void AnimationStart(this ToolStripProgressBar pb)
        {
            pb.Visible = true;
            pb.Style = ProgressBarStyle.Marquee;
            pb.MarqueeAnimationSpeed = 30;
        }

        public static void AnimationStop(this ToolStripProgressBar pb)
        {
            pb.Visible = false;
            pb.Style = ProgressBarStyle.Blocks;
            pb.Value = 0;
        }
    }
}
