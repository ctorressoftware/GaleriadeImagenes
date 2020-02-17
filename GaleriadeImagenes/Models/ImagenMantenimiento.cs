using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace GaleriadeImagenes.Models
{
    public class ImagenMantenimiento
    {
        private SqlConnection conn;

        private void Conectar()
        {
            string cs = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            conn = new SqlConnection(cs);
        }

        public List<Imagen> ObtenerTodasLasImagenes()
        {
            Conectar();

            SqlCommand comando = new SqlCommand("SELECT * FROM Imagen", conn);

            conn.Open();
            SqlDataReader sdr = comando.ExecuteReader();

            List<Imagen> imagenes = new List<Imagen>();

            foreach (var img in sdr)
            {
                Imagen imagen = new Imagen
                {
                    Nombre = sdr["Nombre"].ToString(),
                    ImagenUrl = sdr["ImagenUrl"].ToString()
                };

                imagenes.Add(imagen);
            }

            conn.Close();

            return imagenes;
        }

        public int AgregarImagen(Imagen imagen) {

            Conectar();

            SqlCommand comando = new SqlCommand("INSERT INTO Imagen (Nombre, ImagenUrl) VALUES (@nombre, @imagenurl)", conn);
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@imagenurl", SqlDbType.VarChar);

            comando.Parameters["@nombre"].Value = imagen.Nombre;
            comando.Parameters["@imagenurl"].Value = imagen.ImagenUrl;

            conn.Open();
            int filas = comando.ExecuteNonQuery();
            conn.Close();

            return filas;
        }
    }
}