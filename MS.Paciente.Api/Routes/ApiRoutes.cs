namespace MS.Paciente.Api.Routes
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class RoutePaciente
        {
            // Read
            public const string GetAll = Base + "/producto/all";
            public const string GetById = Base + "/producto/{id}";

            // Write
            public const string Create = Base + "/producto/create";
            public const string Update = Base + "/producto/update/{id}";
            public const string Delete = Base + "/producto/delete";

        }
    }
}
