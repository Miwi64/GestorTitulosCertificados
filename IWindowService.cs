using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoApp
{
    public interface IWindowService
    {
        void CreateAboutWindow();
        void CreateMessageWindow(string message_title, string content, ISolidColorBrush window_color);
    }
}
