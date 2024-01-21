namespace DolphinCinema.Domain.Permissions
{
    public static class PermissionNames
    {
        public static class Seances
        {
            public const string groupName = "Сеансы";
            public const string delete = "Удалить сеанс";
            public const string add = "Добавить сеанс";
            public const string update = "Изменить сеанс";
            public const string buyTicket = "Купить билет";
            public const string view = @"Видимость ""Сеансы""";
        }

        public static class Movies
        {
            public const string groupName = "Фильмы";
            public const string add = "Добавить фильм";
            public const string update = "Изменить фильм";
            public const string delete = "Удалить фильм";
            public const string view = @"Видимость ""Фильмы""";
        }

        public static class Halls
        {
            public const string groupName = "Залы";
            public const string add = "Добавить зал";
            public const string update = "Изменить зал";
            public const string delete = "Удалить зал";
            public const string view = @"Видимость ""Залы""";
        }

        public static class Users
        {
            public const string groupName = "Пользователи";
            public const string add = "Добавить пользователя";
            public const string update = "Изменить пользователя";
            public const string delete = "Удалить пользователя";
            public const string view = @"Видимость ""Пользователи""";
        }
    }
}
