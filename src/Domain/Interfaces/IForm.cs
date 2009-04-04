namespace Domain
{
    public interface IForm
    {
        int Id { get; }

        string Name { get; set; }

        string School { get; set; }

        string Email { get; set; }

        int? Age { get; set; }

        bool? Gender { get; set; }

        int? Grade { get; set; }

        string Instrument { get; set; }
    }
}