using ApiEjemplo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ApiEjemplo.Data
{
    public class PersonaData
    {
        public static void Insert(Persona persona)
        {
            string sInsert = "Insert into personas (Nombre,FechaNac) values ('" + persona.Nombre + "','"+persona.FechaNac.ToString("yyyy-MM-dd HH:mm")+"')";
            DBHelper.EjecutarIUD(sInsert);
        }

        public static void Update(Persona persona)
        {
            string sUpdate = "update personas set Nombre='" + persona.Nombre + "',FechaNac='" + persona.FechaNac.ToString("yyyy-MM-dd HH:mm") + "' where id=" + persona.Id.ToString();
            DBHelper.EjecutarIUD(sUpdate);
        }

        public static void Delete(int id)
        {
            string sUpdate = "delete from personas where id=" + id.ToString();
            DBHelper.EjecutarIUD(sUpdate);
        }

        public static Persona ObtenerPorId(int id)
        {
            string select = "select * from personas where id=" + id.ToString();
            DataTable dt = DBHelper.EjecutarSelect(select);
            Persona p;
            if (dt.Rows.Count > 0)
            {
                p = ObtenerPorRow(dt.Rows[0]);
                return p;
            }
            return null;
        }

        public static List<Persona> ObtenerTodos()
        {
            string select = "select * from personas";
            DataTable dt = DBHelper.EjecutarSelect(select);
            List<Persona> lista = new List<Persona>();
            Persona p;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    p = ObtenerPorRow(row);
                    lista.Add(p);
                }
                p = ObtenerPorRow(dt.Rows[0]);                
            }
            return lista;
        }

        private static Persona ObtenerPorRow(DataRow row)
        {
            Persona p = new Persona();
            p.Id = row.Field<int>("id");
            p.Nombre = row.Field<string>("Nombre");
            p.FechaNac = row.Field<DateTime>("FechaNac");
            return p;
        }
    }
}