using System;

namespace Domain
{
    public interface ICurrentFormHolder
    {
        Form Form { get; set; }

        event Action<Form> OnChanged;

        void ResetWithNewForm();
    }
}