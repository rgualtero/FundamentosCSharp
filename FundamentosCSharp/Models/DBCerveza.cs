using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace FundamentosCSharp.Models
{
    class DBCerveza
    {
        private string ConnectionStrings = "Data Source=localhost; Initial Catalog=FundamentosCSharp;User=sa;Password=Tecnologia.4";

        #region Metodo GET SQLConnection
        public List<Cervezas> Get()
        {
            List<Cervezas> ObjBebidasAlcoholica = new List<Cervezas>();

            string Query = "select * from [dbo].[Bebidas] where Alcohol > 0";

            using(SqlConnection cnx = new SqlConnection(ConnectionStrings))
            {
                SqlCommand cmd = new SqlCommand(Query, cnx);

                cnx.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int Cantidad = reader.GetInt32(4);
                    string Nombre = reader.GetString(1);
                    Cervezas cerveza = new Cervezas(Cantidad, Nombre);
                    cerveza.Alcohol = reader.GetInt32(3);
                    cerveza.Marca = reader.GetString(2);

                    ObjBebidasAlcoholica.Add(cerveza);

                }
                reader.Close();
                cnx.Close();
            }

            return ObjBebidasAlcoholica;
        }
        #endregion

        #region Metodo POST SQLConnection
        public void Add(Cervezas cerveza)
        {
            string Query = "INSERT INTO Bebidas (Nombre,Marca,Alcohol,Cantidad)  VALUES (@Nombre,@Marca,@Alcohol,@Cantidad)";

            using(SqlConnection cnx = new SqlConnection(ConnectionStrings))
            {
                SqlCommand cmd = new SqlCommand(Query, cnx);
                cmd.Parameters.AddWithValue("@Nombre", cerveza.Nombre);
                cmd.Parameters.AddWithValue("@Marca", cerveza.Marca);
                cmd.Parameters.AddWithValue("@Alcohol", cerveza.Alcohol);
                cmd.Parameters.AddWithValue("@Cantidad", cerveza.Cantidad);

                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();
            }
        }
        #endregion

        #region Metodo PUT SQLConnection
        public void Edit(Cervezas cerveza, int Id)
        {
            string Query = "UPDATE Bebidas SET Nombre = @Nombre, Marca = @Marca, Alcohol = @Alcohol, Cantidad = @Cantidad WHERE Id = @Id";

            using (SqlConnection cnx = new SqlConnection(ConnectionStrings))
            {
                SqlCommand cmd = new SqlCommand(Query, cnx);
                cmd.Parameters.AddWithValue("@Nombre", cerveza.Nombre);
                cmd.Parameters.AddWithValue("@Marca", cerveza.Marca);
                cmd.Parameters.AddWithValue("@Alcohol", cerveza.Alcohol);
                cmd.Parameters.AddWithValue("@Cantidad", cerveza.Cantidad);
                cmd.Parameters.AddWithValue("@Id", Id);

                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();
            }
        }
        #endregion

        #region Metodo DELETE SQLConnection
        public void Delete(int Id)
        {
            string Query = "DELETE Bebidas WHERE Id = @Id";

            using (SqlConnection cnx = new SqlConnection(ConnectionStrings))
            {
                SqlCommand cmd = new SqlCommand(Query, cnx);
                cmd.Parameters.AddWithValue("@Id", Id);

                cnx.Open();
                cmd.ExecuteNonQuery();
                cnx.Close();
            }
        }
        #endregion
    }
}
