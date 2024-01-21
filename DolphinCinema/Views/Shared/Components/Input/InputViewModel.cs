namespace DolphinCinema.Views.Shared.Components.Input
{
    public class InputViewModel
    {
        public string Id { get; set; }
        public string ClassName { get; set; }
        public string Type { get; set; }

        public string Placeholder { get; set; }

        public InputViewModel(string id, string className, string type, string placeholder)
        {
            Id = id;
            ClassName = className;
            Type = type;
            Placeholder = placeholder;
        }
    }
}
