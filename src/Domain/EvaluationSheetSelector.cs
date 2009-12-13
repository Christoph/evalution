using System;
using Domain.Repositories;

namespace Domain
{
    public class EvaluationSheetSelector : IConfigurationProvider
    {
        //don't forget to change the setting also in the DatabaseInitializer.cs.
        private Configurations Config = Configurations.ThreeStepsSheet;

        public Configurations Configuration
        {
            get { return Config; }
        }
    }
}
