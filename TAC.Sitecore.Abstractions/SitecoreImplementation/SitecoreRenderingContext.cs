
using TAC.Sitecore.Abstractions.Interfaces;
using System;
using Sitecore;
using Sitecore.Mvc.Presentation;

namespace TAC.Sitecore.Abstractions.SitecoreImplementation
{
    public class SitecoreRenderingContext : IRenderingContext
    {
        private SitecoreRenderingContext () {}
        
        public static IRenderingContext Create()
        {
            return new SitecoreRenderingContext();
        }

        public IItem HomeItem => new SitecoreItem(Context.Site.StartPath, Context.Database.Name);

        public IItem DatasourceOrContextItem => new SitecoreItem(RenderingContext.Current.Rendering.Item);

        public IItem ContextItem => new SitecoreItem(RenderingContext.Current.ContextItem);

        public bool IsExperienceEditorEditing => Context.PageMode.IsExperienceEditorEditing;

        public string Parameter(string key)
        {
            return RenderingContext.Current.Rendering.Parameters[key];
        }
    }
}
