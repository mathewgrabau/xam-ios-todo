﻿// This file has been autogenerated from a class added in the UI designer.
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using SQLite;

namespace ToDoList
{
    internal class ApplicationDatabase : IDisposable
    {
        SQLiteConnection _connection;
        bool _isDisposed;

        internal ApplicationDatabase()
        {
            _connection = OpenDatabase();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }

            if (disposing)
            {
                _connection.Close();
                _connection.Dispose();
            }

            _isDisposed = true;
        }

        ~ApplicationDatabase()
        {
            Dispose(false);
        }

        static internal void CreateDatabase()
        {
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "todo.db3");
            var database = new SQLiteConnection(path);
            CreateTableResult createResult = database.CreateTable<ToDoItem>();
            System.Console.WriteLine(createResult);
            database.Close();
        }

        static internal SQLiteConnection OpenDatabase()
        {

            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "todo.db3");
            SQLiteConnection database = new SQLiteConnection(path);
            CreateTableResult createResult = database.CreateTable<ToDoItem>();
            return database;
        }

        internal void Close()
        {
            _connection.Close();
        }

        internal void Open()
        {
            _connection = OpenDatabase();
        }

        internal IEnumerable<ToDoItem> GetToDoItems()
        {
            var itemsTable = _connection.Table<ToDoItem>();
            return itemsTable.OrderBy(item => item.Id);
        }

        internal int Add(ToDoItem newItem)
        {
            return _connection.Insert(newItem);
        }

        internal int Delete(ToDoItem toRemove)
        {
            return _connection.Delete<ToDoItem>(toRemove.Id);
        }
    }
}