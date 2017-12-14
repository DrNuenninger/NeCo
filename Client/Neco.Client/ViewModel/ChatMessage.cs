﻿using System;

namespace Neco.Client.ViewModel
{
    public class ChatMessage : ViewModelBase
    {
        private string message;
        private DateTime time;
        private bool isForeign;

        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }
        public DateTime Time
        {
            get { return time; }
            set { SetProperty(ref time, value); }
        }
        public bool IsForeign
        {
            get { return isForeign; }
            set { SetProperty(ref isForeign, value); }
        }

        public string StringTime
        {
            get
            {
                return Time.ToShortTimeString();
            }
        }
    }
}
