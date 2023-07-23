﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ces.WinForm.UI.CesNotificationBox
{
    public static class CesNotification
    {
        /// <summary>
        /// [_NotificationHolder] is static list and store new notification
        /// data. but [_NotificationHolder] initialize with null value and 
        /// null value is notification data and will be set by [GetBlankLocation]
        /// static method which is run by static [Show] method
        /// </summary>
        public static List<CesNotificationHolder> _NotificationHolder = new List<CesNotificationHolder>()
        {
            new CesNotificationHolder(1),
            new CesNotificationHolder(2),
            new CesNotificationHolder(3),
            new CesNotificationHolder(4),
            new CesNotificationHolder(5),
            new CesNotificationHolder(6),
            new CesNotificationHolder(7),
            new CesNotificationHolder(8),
            new CesNotificationHolder(9),
            new CesNotificationHolder(10),
            new CesNotificationHolder(11),
            new CesNotificationHolder(12),
            new CesNotificationHolder(13),
            new CesNotificationHolder(14),
            new CesNotificationHolder(15),
            new CesNotificationHolder(16),
            new CesNotificationHolder(17),
            new CesNotificationHolder(18),
            new CesNotificationHolder(19),
            new CesNotificationHolder(20),
            new CesNotificationHolder(21),
            new CesNotificationHolder(22),
            new CesNotificationHolder(23),
            new CesNotificationHolder(24),
            new CesNotificationHolder(25),
            new CesNotificationHolder(26),
            new CesNotificationHolder(27),
            new CesNotificationHolder(28),
            new CesNotificationHolder(29),
            new CesNotificationHolder(30),
        };

        /// <summary>
        /// Static [Show] method is avaliable by end user to instantiate from notification
        /// and show on screen.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public static async Task Show(CesNotificationOptions? options = null)
        {
            if (options is not null && options.Type == CesNotificationTypeEnum.NotificationBox)
            {
                var frmBox = new CesNotificationBox(options);
                var getLocation = GetBlankLocation(frmBox, options.Position);

                options.Order = getLocation.Order;
                options.BlankLocation = getLocation.LastPoint;

                frmBox.Show();
            }

            if (options is not null && options.Type == CesNotificationTypeEnum.NotificationSrtip)
            {
                var frmStrip = new CesNotificationStrip(options);
                frmStrip.Show();
            }
        }

        /// <summary>
        /// Static [GetBlankLocation] method is called by [Show] method
        /// and before showing notification, this method get last blank
        /// place in [_NotificationHolder] list and return last used location
        /// then new notification shall adjust its location by last location.
        /// this adjustment is done in [FormLoading] event.
        /// Checking blank order is according to notification position
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public static CesNotificationHolder GetBlankLocation(Form notification, CesNotificationPositionEnum position)
        {
            CesNotificationHolder holder = new CesNotificationHolder(0);

            foreach (var item in _NotificationHolder.OrderBy(x => x.Order))
            {
                // Check current item has data, it shows that current order is used
                // and code shall inspect next item to find blank item
                if (item.Notification is not null && item.Position == position)
                {
                    // set location of used order to [holder] variable whish must be return to [Show] method
                    // by default [LastPoint] is null
                    holder.LastPoint = item.Notification.Location;
                    continue;
                }

                // if current order is not used, current notification object shall be set
                // to [Notification] proeprty of current item of [_NotificationHolder] list
                // then set [Order] property to current item of [_NotificationHolder] list
                item.Notification = notification;
                item.Position = position;
                holder.Order = item.Order;

                return holder;
            }

            return holder;
        }


        /// <summary>
        /// Sttaic [SetBlankLocation] is called by [FormClosed] event
        /// by notification and this method set current order to null
        /// till can be used by another new notification
        /// </summary>
        /// <param name="order"></param>
        public static void SetBlankLocation(int order)
        {
            foreach (var item in _NotificationHolder.OrderBy(x => x.Order))
            {
                if (item.Order == order)
                {
                    item.Notification = null;
                }
            }
        }
    }

    public class CesNotificationOptions
    {
        public CesNotificationOptions(CesNotificationOptions? options = null)
        {
            Id = Guid.NewGuid();

            if (options is null)
            {
                IssueDateTime = DateTime.Now;
                Duration = 5;
                Icon = CesNotificationIconEnum.None;
                Position = CesNotificationPositionEnum.BottomRight;
                BackColor = Color.BlueViolet;
                ShowTitleBar = true;
                ShowExitButton = true;
                ShowStatusBar = false;
                ShowIssueDateTime = true;
                ShowRemained = true;
                ShowIcon = true;
                Type = CesNotificationTypeEnum.NotificationBox;
                ShowStripBottom = true;
            }
        }

        public System.Guid Id { get; set; }
        public DateTime IssueDateTime { get; set; }
        public int Duration { get; set; } // in second
        public string? Title { get; set; }
        public string? Message { get; set; }
        public CesNotificationIconEnum Icon { get; set; }
        public CesNotificationPositionEnum Position { get; set; }
        public Color BackColor { get; set; }
        public bool ShowTitleBar { get; set; }
        public bool ShowExitButton { get; set; }
        public bool ShowStatusBar { get; set; }
        public bool ShowIssueDateTime { get; set; }
        public bool ShowRemained { get; set; }
        public bool ShowIcon { get; set; }
        public Size? Size { get; set; }
        public CesNotificationTypeEnum Type { get; set; }
        public bool ShowStripBottom { get; set; }
        public Point? BlankLocation { get; set; }
        public int Order { get; set; }

        public delegate void CesNotificationOnExitDelegate();
        public CesNotificationOnExitDelegate CesNotificationOnExitHandler;
    }

    public sealed class CesNotificationHolder
    {
        public CesNotificationHolder(
            int order,
            Form? frm = null,
            CesNotificationPositionEnum? position = null)
        {
            Order = order;
            LastPoint = frm?.Location;
            Notification = frm;
            Position = position;
        }

        public int Order { get; set; }
        public Point? LastPoint { get; set; }
        public Form? Notification { get; set; }
        public CesNotificationPositionEnum? Position { get; set; }
    }

    public enum CesNotificationPositionEnum
    {
        TopLeft,
        TopCenter,
        TopRight,
        BottomLeft,
        BottomCenter,
        BottomRight,
        ScreenCenter,
    }

    public enum CesNotificationIconEnum
    {
        None,
        NotificationCheck,
        NotificationEmail,
        NotificationInformation,
        NotificationQuestion,
        NotificationSecurity,
        NotificationSettings,
        NotificationUser,
        NotificationWarning,
        NotificationWeb,
    }

    public enum CesNotificationTypeEnum
    {
        NotificationBox,
        NotificationSrtip,
    }
}
