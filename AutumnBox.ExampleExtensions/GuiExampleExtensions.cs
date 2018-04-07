﻿/*************************************************
** auth： zsh2401@163.com
** date:  2018/3/6 17:52:46 (UTC +8:00)
** desc： ...
*************************************************/
using AutumnBox.Basic.Device;
using AutumnBox.ExampleExtensions.Windows;
using AutumnBox.OpenFramework;
using AutumnBox.OpenFramework.Extension;
using AutumnBox.OpenFramework.Open;
using System;
using System.IO;
using System.Net.Mail;
using System.Windows;

namespace AutumnBox.ExampleExtensions
{
    public class GuiExampleExtensions : AutumnBoxExtension
    {
        public override string Name => "带界面的拓展示例";
        public override string Auth => "zsh2401";
        public override Version Version => new Version("0.0.2");
        public override string Description => "AutumnBox拓展允许使用自定义窗口";
        public override MailAddress ContactMail => new MailAddress("zsh2401@163.com");
        public override DeviceState RequiredDeviceState => DeviceState.None;
        public override int? MinSdk => 5;
        public override int? TargetSdk => 5;
        public override bool InitAndCheck(InitArgs args)
        {
            OpenApi.Gui.ShowDebugWindow(this);
            return base.InitAndCheck(args);
        }
        public override void OnStartCommand(StartArgs args)
        {
            Comp.RunMaybeMissingMethod(BuildInfo.SdkVersion  > 5,
                () =>
            {
                
            });
            Window expWin = null;
            RunOnUIThread(() =>
            {
                expWin = new ExampleWindow()
                {
                    Owner = OpenApi.Gui.GetMainWindow(this),
                    WindowStartupLocation = WindowStartupLocation.CenterOwner
                };
                expWin.Show();
            });
            bool isClosed = false;
            expWin.Closed += (s, e) => isClosed = true;
            while (!isClosed) ;
        }
        public override void OnDestory(DestoryArgs args)
        {
            base.OnDestory(args);
        }
    }
}
