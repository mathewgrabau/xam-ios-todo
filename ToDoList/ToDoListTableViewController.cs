// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace ToDoList
{





    public partial class ToDoListTableViewController : UITableViewController
	{
        public List<ToDoItem> ToDoItems { get; private set; } = new List<ToDoItem>();
        private ApplicationDatabase _database;

		public ToDoListTableViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _database = new ApplicationDatabase();

            ToDoItems = _database.GetToDoItems().ToList();
        }
            
        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return ToDoItems.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
			var cell = new UITableViewCell();
            ToDoItem item = ToDoItems[indexPath.Row];
            if (item != null)
            {
                if (item.Important)
                {
                    cell.TextLabel.Text = $"{item.Name} (!)";
                }
                else
                {
                    cell.TextLabel.Text = item.Name;
                }
            }

			return cell;
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            if (segue.DestinationViewController is NewItemViewController newItemViewController)
            {
                newItemViewController.TableViewController = this;
            }
            else if (segue.DestinationViewController is UpdateItemViewController updateItemViewController && sender is NSObjectWrapper<ToDoItem> wrappedSelection)
            {
                updateItemViewController.Item = wrappedSelection.Context;
                updateItemViewController.TableViewController = this;
            }
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var selectedPath = indexPath.Row;
            var selectedItem = ToDoItems[selectedPath];
            PerformSegue("GoToUpdateItem", NSObjectWrapper<ToDoItem>.Wrap(ref selectedItem));
        }

        public void ReloadItems()
        {
            _database.Open();
            ToDoItems.Clear();
            ToDoItems.AddRange(_database.GetToDoItems());
            TableView.ReloadData();
        }
    }
}