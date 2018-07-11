//
// Copyright (c) 2010-2018 Antmicro
//
// This file is licensed under the MIT License.
// Full license text is available in 'licenses/MIT.txt'.
//
using System;
using System.Threading;
using AntShell.Terminal;
using Antmicro.Renode.UI;
using Xwt;

namespace Antmicro.Renode.UI
{
    public class TermsharpProvider : IConsoleBackendAnalyzerProvider
    {
        public bool TryOpen(string consoleName, out IIOSource ioSource)
        {
            TerminalWidget terminalWidget = null;
            ApplicationExtensions.InvokeInUIThreadAndWait(() =>
            {
                terminalWidget = new TerminalWidget(() => window.HasFocus);
            });
            ioSource = terminalWidget.IOSource;

            var mre = new ManualResetEventSlim();
            ApplicationExtensions.InvokeInUIThread(() =>
            {
                window = new Window();
                window.Title = consoleName == null ? "Renode" : consoleName;
                window.Width = 700;
                window.Height = 400;
                window.Location = WindowPositionProvider.Instance.GetNextPosition();
                window.Padding = new WidgetSpacing();
                window.Content = terminalWidget;
                terminalWidget.Initialized += mre.Set;
                window.Show();
                window.Closed += (sender, e) =>
                {
                    InnerOnClose();
                };
            });
            mre.Wait();

            return true;
        }

        public void Close()
        {
            var w = window;
            if(w != null)
            {
                ApplicationExtensions.InvokeInUIThreadAndWait(() =>
                {
                    w.Hide();
                });
                w = null;
                return;
            }
        }

        public event Action OnClose;

        private void InnerOnClose()
        {
            OnClose?.Invoke();
        }

        private Xwt.Window window;
    }
}
