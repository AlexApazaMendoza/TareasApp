using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TareasApp.Models;

namespace TareasApp.Data
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Tarea>().Wait();

        }

        public Task<int> SaveTarea(Tarea tarea)
        {
            if (tarea.Id == 0)
            {
                return db.InsertAsync(tarea);
            }
            else
            {
                return null;
            }
        }
        public Task<int> UpdateTarea(Tarea tarea)
        {
            if (tarea.Id != 0)
            {
                return db.UpdateAsync(tarea);
            }
            else
            {
                return null;
            }
        }
        public Task<int> DeleteTarea(Tarea tarea)
        {
            return db.DeleteAsync(tarea);
        }
        public Task<List<Tarea>> GetTareas()
        {
            return db.Table<Tarea>().ToListAsync();
        }
        public Task<Tarea> GetTareaById(int id)
        {
            return db.Table<Tarea>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task<List<Tarea>> GetTareasOrdered()
        {
            return db.Table<Tarea>().OrderBy(x => x.FechaHora).ToListAsync();
        }

    }
}
