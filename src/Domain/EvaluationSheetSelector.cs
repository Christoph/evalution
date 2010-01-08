using System;
using Domain.Repositories;

namespace Domain
{
    public class EvaluationSheetSelector : IConfigurationProvider
    {
        private Configurations Config = Configurations.TwoStepsSheetTwo;

        public Configurations Configuration
        {
            get { return Config; }
        }
    }
}
