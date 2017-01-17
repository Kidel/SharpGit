using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SharpGit.UI
{
    static class WindowStatus
    {
        public static TextBlock ModalOutput { get; set; }
        public static Frame ModalFrame { get; set; }
        public static Button ModalFrameCloseButton { get; set; }

        public static void ShowModalFrame()
        {
            ModalFrame.Visibility = Visibility.Visible;
        }
        public static void HideModalFrame()
        {
            ModalFrame.Visibility = Visibility.Hidden;
        }
    }
}
