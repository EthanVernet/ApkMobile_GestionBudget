namespace Application_Gestion.Interfaces
{
    public static class ResourceHelper
    {
        public static object FindResource(this VisualElement o, string key)
        {
            while (o != null)
            {
                if (o.Resources.TryGetValue(key, out var r1)) return r1;
                if (o is Page) break;
                if (o is IElement e) o = e.Parent as VisualElement;
            }
            if (Application.Current.Resources.TryGetValue(key, out var r2)) return r2;
            return null;
        }
    }
}
