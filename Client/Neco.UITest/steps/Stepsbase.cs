﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xamarin.UITest;

namespace Neco.UITest.steps
{
    public class StepsBase
    {
        protected readonly IApp app;

        public StepsBase()
        {
            app = AppInitializer.StartApp(Platform.Android);
            FeatureContext.Current.Add("App", app);

            app = FeatureContext.Current.Get<IApp>("App");
        }
    }
}