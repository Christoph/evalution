using System;
using Domain.Repositories;

namespace Domain
{
    public class EvaluationSheetSelector : IConfigurationProvider
    {
        private Configurations Config = Configurations.TwoStepsSheet;

        public Configurations Configuration
        {
            get { return Config; }
        }
    }
}
