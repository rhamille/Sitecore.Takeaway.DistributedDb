namespace Sitecore.Rocks.Plugin.Commands.DistributedDb
{
    using Sitecore.VisualStudio.Commands;
    using Sitecore.VisualStudio.ContentTrees;
    using Sitecore.VisualStudio.ContentTrees.Items;
    using Sitecore.VisualStudio.Data;
    using Sitecore.VisualStudio.Diagnostics;
    using System.Collections.Generic;
    using System.Linq;

    [Command(Submenu = "Distributed Databases")]
    public class DeprovisionCommand : CommandBase
    {
        #region Constructors and Destructors

        public DeprovisionCommand()
        {
            this.Text = "Deprovisioning";
            this.Group = "Deprovisioning";
            this.SortingValue = 3000;
        }

        #endregion Constructors and Destructors

        #region Public Methods

        public override bool CanExecute(object parameter)
        {
            ContentTreeContext contentTreeContext = parameter as ContentTreeContext;
            if (contentTreeContext == null || Enumerable.Count<BaseTreeViewItem>(contentTreeContext.SelectedItems) != 1)
                return false;
            SiteTreeViewItem siteTreeViewItem = Enumerable.FirstOrDefault<BaseTreeViewItem>(contentTreeContext.SelectedItems) as SiteTreeViewItem;
            return siteTreeViewItem != null;
        }

        public override IEnumerable<ICommand> GetSubmenuCommands(object parameter)
        {
            Assert.ArgumentNotNull(parameter, "parameter");
            if (!(parameter is IItemSelectionContext))
                return Enumerable.Empty<ICommand>();
            return CommandManager.GetCommands(parameter, "Deprovisioning");
        }

        public override void Execute(object parameter)
        {
        }

        #endregion Public Methods
    }
}