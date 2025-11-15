using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using DBSQlite.Models;
using System.Threading.Tasks;

namespace DBSQlite.Data
{


    public class SQLiteHelper
    {

        SQLiteAsyncConnection db;
        //vamos a crear un constructor

        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Estudiante>().Wait();
            db.CreateTableAsync<Venta>().Wait();
        }
        public Task<int> GuardarEstudianteAsync(Estudiante Est)
        {
            if (Est.EstudianteId != 0)
            {
                return db.UpdateAsync(Est);
            }
            else
            {
                return db.InsertAsync(Est);
            }
        }
        /// <summary>
        /// Recupera todos los estudiantes
        /// </sumnary>
        // <returns></returns>
        //Para visualizar todos los estudiantes que tenemos guardados en la base de datos

        public Task<List<Estudiante>> GetEstudiantesAsync()
        {
            return db.Table<Estudiante>().ToListAsync();
        }
        //Recupera todos los estudiantes por EstudianteId

        public Task<Estudiante> GetEstudianteByIdAsync(int EstudianteId)
        {
            return db.Table<Estudiante>().Where(a => a.EstudianteId == EstudianteId).FirstOrDefaultAsync();
        }
        public Task<int> DeleteEstudianteAsync(Estudiante estudiante)
        {
            return db.DeleteAsync(estudiante);
        }

        // Métodos para la entidad Venta
        public Task<int> GuardarVentaAsync(Venta venta)
        {
            if (venta.VentaId != 0)
            {
                return db.UpdateAsync(venta);
            }
            else
            {
                return db.InsertAsync(venta);
            }
        }

        public Task<List<Venta>> GetVentasAsync()
        {
            return db.Table<Venta>().ToListAsync();
        }

        public Task<Venta> GetVentaByIdAsync(int ventaId)
        {
            return db.Table<Venta>().Where(v => v.VentaId == ventaId).FirstOrDefaultAsync();
        }

        public Task<int> DeleteVentaAsync(Venta venta)
        {
            return db.DeleteAsync(venta);
        }
    }
}