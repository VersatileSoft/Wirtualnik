namespace Wirtualnik.Shared
{
    public static class CrudPaths
    {
        public const string ByIdPath = "{id}";
        public const string AllPath = "all";
        public const string CreatePath = "";
        public const string UpdatePath = "{id}";
        public const string DeletePath = "{id}";

        public static string ById<TModel>(int id)
        {
            return CrudPathByModel<TModel>(ByIdPath).Replace("{id}", id.ToString());
        }

        public static string All<TModel>()
        {
            return CrudPathByModel<TModel>(AllPath);
        }

        public static string Create<TModel>()
        {
            return CrudPathByModel<TModel>(CreatePath);
        }

        public static string Update<TModel>(int id)
        {
            return CrudPathByModel<TModel>(UpdatePath).Replace("{id}", id.ToString());
        }

        public static string Delete<TModel>(int id)
        {
            return CrudPathByModel<TModel>(DeletePath).Replace("{id}", id.ToString());
        }

        private static string CrudPathByModel<TModel>(string path)
        {
            string controllerName = "api/" + typeof(TModel).Name.Replace("Model", "").ToLower();
            return controllerName + "/" + path;
        }
    }

    public static class ProcessorPaths
    {
        public const string Name = "api/Processor";
    }
}
