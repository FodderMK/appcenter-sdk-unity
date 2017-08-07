﻿// Copyright (c) Microsoft Corporation. All rights reserved.
//
// Licensed under the MIT license.

#if UNITY_ANDROID && !UNITY_EDITOR
using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Microsoft.Azure.Mobile.Unity.Push.Internal
{
    class PushDelegate : AndroidJavaProxy
    {
        private PushDelegate() : base("com.microsoft.azure.mobile.push.PushListener")
        {
        }

        public static void SetDelegate()
        {
            var push = new AndroidJavaClass("com.microsoft.azure.mobile.push.Push");
            push.CallStatic("setListener", new PushDelegate());
        }

        void onPushNotificationReceived(AndroidJavaObject activity, AndroidJavaObject pushNotification)
        {
            var eventArgs = PushNotificationHelper.PushConvert(pushNotification);
            Push.NotifyPushNotificationReceived(eventArgs);
        }
    }
}
#endif
